using AutoDrivingCarSimulation.Business.Core;
using AutoDrivingCarSimulation.Business.Util;

namespace AutoDrivingCarSimulation.SolutionPart1;

public class Program
{
    static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        parser.GetInput();

        string result = StartSimulation(parser.Line1, parser.Line2, parser.Line3);
        Console.WriteLine(result);
    }
    
    public static (int xCoordinate, int yCoordinate, char direction) GetOutput(string line1, string line2, string line3)
    {
        string result = StartSimulation(line1, line2, line3);
        string[] tokens = result.Split(" ");
        return (int.Parse(tokens[0]), int.Parse(tokens[1]), tokens[2][0]);
    }

    public static string StartSimulation(string line1, string line2, string line3)
    {
        Field field = InputParserUtil.ParseFieldLine(line1);
        Car car = InputParserUtil.ParseCarLine(line2);
        CarInstructions instructions = InputParserUtil.ParseInstructionLine(line3, car.Id);

        Simulator simulator = new Simulator(field, car, instructions);
        simulator.RunSimulation();

        return car.PrintCurrentPosition();
    }
}