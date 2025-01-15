using AutoDrivingCarSimulation.Business.Core;
using AutoDrivingCarSimulation.Business.Model;
using AutoDrivingCarSimulation.Business.Util;

namespace AutoDrivingCarSimulation.SolutionPart2;

public class Program
{
    static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        parser.GetInput();

        /*
        string fieldLine = "10 10";
        List<CarInputModel> carInputs = new List<CarInputModel>();
        carInputs.Add(new CarInputModel
        {
            NameLine = "A",
            CoordinateLine = "1 2 N",
            InstructionLine = "FFRFFFFRRL"
        });
        carInputs.Add(new CarInputModel
        {
            NameLine = "B",
            CoordinateLine = "7 8 W",
            InstructionLine = "FFLFFFFFFF"
        });
        StartSimulation(fieldLine, carInputs);
        */
        
        var simulationResult = StartSimulation(parser.FieldDimensionLine, parser.CarInputs);
        
        if (simulationResult.HasCollision)
        {
            Console.WriteLine(simulationResult.CollidedCars);
            Console.WriteLine(simulationResult.CollisionPosition);
            Console.WriteLine(simulationResult.Step);
        }
        else
        {
            Console.WriteLine("no collision");
        }
    }
    
    public static SimulationResult StartSimulation(string fieldLine, List<CarInputModel> carInputs)
    {
        Field field = InputParserUtil.ParseFieldLine(fieldLine);
        List<Car> cars = new List<Car>();
        List<CarInstructions> carInstructions = new List<CarInstructions>();

        foreach (var carInput in carInputs)
        {
            Car car = InputParserUtil.ParseCarLine(carInput.CoordinateLine, carInput.NameLine);
            cars.Add(car);
            CarInstructions instructions = InputParserUtil.ParseInstructionLine(carInput.InstructionLine, car.Id);
            carInstructions.Add(instructions);
        }

        Simulator simulator = new Simulator(field, cars, carInstructions);
        var simulationResult = simulator.RunSimulation();
        return simulationResult;
    }
}