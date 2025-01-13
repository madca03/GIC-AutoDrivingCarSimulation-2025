using AutoDrivingCarSimulation.Business.Core;
using AutoDrivingCarSimulation.Business.Util;

namespace AutoDrivingCarSimulation.SolutionPart2;

class Program
{
    static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        parser.GetInput();

        /*
        string fieldLine = "10 10";
        List<CarInput> carInputs = new List<CarInput>();
        carInputs.Add(new CarInput
        {
            NameLine = "A",
            CoordinateLine = "1 2 N",
            InstructionLine = "FFRFFFFRRL"
        });
        carInputs.Add(new CarInput
        {
            NameLine = "B",
            CoordinateLine = "7 8 W",
            InstructionLine = "FFLFFFFFFF"
        });
        StartSimulation(fieldLine, carInputs);
        */
        
        StartSimulation(parser.FieldDimensionLine, parser.CarInputs);
    }

    public static void StartSimulation(string fieldLine, List<CarInput> carInputs)
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
        simulator.RunSimulation();
    }
}