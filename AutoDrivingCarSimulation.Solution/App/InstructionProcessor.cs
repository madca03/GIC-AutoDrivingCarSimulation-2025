using AutoDrivingCarSimulation.Solution.Constants;

namespace AutoDrivingCarSimulation.Solution.App;

public class InstructionProcessor
{
    private List<InstructionType> instructions;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructionProcessor"/> class.
    /// </summary>
    /// <param name="instructions"></param>
    public InstructionProcessor(List<InstructionType> instructions)
    {
        this.instructions = instructions;
    }

    /// <summary>
    /// Applies each instruction to the Car in sequence.
    /// </summary>
    /// <param name="car">Car.</param>
    public void ProcessInstructions(Car car)
    {
        foreach (var instruction in this.instructions)
        {
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
}