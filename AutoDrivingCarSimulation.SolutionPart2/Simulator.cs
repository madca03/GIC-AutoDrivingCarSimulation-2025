using AutoDrivingCarSimulation.Business.Constants;
using AutoDrivingCarSimulation.Business.Core;
using AutoDrivingCarSimulation.Business.Extensions;

namespace AutoDrivingCarSimulation.SolutionPart2;

public class Simulator
{
    private Field field;
    private List<Car> cars;
    private Dictionary<string, CarInstructions> carInstructionMap;

    public Simulator(Field field, List<Car> cars, List<CarInstructions> carInstructions)
    {
        this.field = field;
        this.cars = cars;

        foreach (var car in this.cars)
        {
            car.Field = field;
        }
        
        this.carInstructionMap = carInstructions.ToDictionary(x => x.CarId);
    }

    public SimulationResult RunSimulation()
    {
        int step = 1;
        var res = new SimulationResult();
        
        while (AnyCarHasInstructions())
        {
            // Get the new car positions
            Dictionary<Car, Position> nextPositions = new Dictionary<Car, Position>();

            foreach (var car in cars)
            {
                CarInstructions carInstructions = carInstructionMap[car.Id];
                
                // If no more instructions, the car stays in place.
                if (carInstructions == null || !carInstructions.HasMoreInstructions())
                {
                    nextPositions.Add(car, new Position(car.X, car.Y));
                    continue;
                }
                
                // Get the next instruction but don't process it yet.
                InstructionType nextInstruction = carInstructions.PeekNextInstruction();

                switch (nextInstruction)
                {
                    case InstructionType.FORWARD:
                        // Compute new position
                        int nx = car.X + car.Orientation.DeltaX();
                        int ny = car.Y + car.Orientation.DeltaY();
                        nextPositions.Add(car, new Position(nx, ny));
                        break;
                    case InstructionType.TURN_LEFT:
                    case InstructionType.TURN_RIGHT:
                    default:
                        // Position stays the same, orientation would change.
                        nextPositions.Add(car, new Position(car.X, car.Y));
                        break;
                }
            }
            
            // Check for collisions among the nextPositions
            Position collisionPosition = DetectCollision(nextPositions);
            if (collisionPosition != null)
            {
                List<Car> collidedCars = FindCarsAtPosition(nextPositions, collisionPosition);

                res.CollidedCars = FormatCarNames(collidedCars);
                res.CollisionPosition = $"{collisionPosition.X} {collisionPosition.Y}";
                res.Step = step;
                res.HasCollision = true;
                return res;
            }
            
            // No collision found. Finalize each car's move.
            foreach (var car in cars)
            {
                CarInstructions instructions = carInstructionMap[car.Id];
                if (instructions != null && instructions.HasMoreInstructions())
                {
                    InstructionType instruction = instructions.ConsumeNextInstruction();

                    switch (instruction)
                    {
                        case InstructionType.FORWARD:
                            car.MoveForward();
                            break;
                        case InstructionType.TURN_LEFT:
                            car.TurnLeft();
                            break;
                        case InstructionType.TURN_RIGHT:
                            car.TurnRight();
                            break;
                    }
                }
            }

            step++;
        }

        return res;
    }
    
    public string FormatCarNames(List<Car> cars)
    {
        // E.g., "A B"
        return cars
            .Select(car => car.Name)  // Select the name of each car
            .OrderBy(name => name)    // Sort the names alphabetically
            .Aggregate((a, b) => a + " " + b);  // Concatenate the names with a space in between
    }
    
    /// <summary>
    /// Find the cars at a given position.
    /// </summary>
    /// <param name="carPositionMap">Car to Position mapping.</param>
    /// <param name="position">Desired position.</param>
    /// <returns>List of cars.</returns>
    public List<Car> FindCarsAtPosition(Dictionary<Car, Position> carPositionMap, Position position)
    {
        List<Car> result = new List<Car>();
        foreach (var entry in carPositionMap)
        {
            if (entry.Value.Equals(position))
            {
                result.Add(entry.Key);
            }
        }
        return result;
    }
    
    /// <summary>
    /// Checks whether any car has instructions left.
    /// </summary>
    /// <returns>Returns true if a car has instructions left otherwise false.</returns>
    private bool AnyCarHasInstructions()
    {
        foreach (var car in cars)
        {
            CarInstructions carInstructions = carInstructionMap[car.Id];
            if (carInstructions != null && carInstructions.HasMoreInstructions())
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Detects if there is a possible collision in the computed next positions.
    /// </summary>
    /// <param name="nextPositions">Calculated nextPositions.</param>
    /// <returns>Returns the position of the detected collision.</returns>
    private Position DetectCollision(Dictionary<Car, Position> nextPositions)
    {
        // Count how many cars want to occupy each position.
        Dictionary<Position, int> posCount = new Dictionary<Position, int>();

        foreach (var position in nextPositions.Values)
        {
            if (!posCount.ContainsKey(position)) posCount[position] = 1;
            else posCount[position] += 1;
        }
        
        // If any position is occupied by 2+ cars, then there is a collision
        foreach (var (positionKey,count) in posCount)
        {
            if (count > 1) return positionKey;
        }

        return null;
    }
}