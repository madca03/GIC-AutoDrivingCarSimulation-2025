using AutoDrivingCarSimulation.Business.Core;
using AutoDrivingCarSimulation.Business.Util;

namespace AutoDrivingCarSimulation.SolutionPart1;

public class Program
{
    static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        parser.GetInput();
        
        Field field = InputParserUtil.ParseFieldLine(parser.Line1);
        Car car = InputParserUtil.ParseCarLine(parser.Line2);
        CarInstructions instructions = InputParserUtil.ParseInstructionLine(parser.Line3);

        Simulator simulator = new Simulator(field, car, instructions);
        simulator.RunSimulation();
        
        Console.WriteLine(car.PrintCurrentPosition());
    }
    
    public static (int xCoordinate, int yCoordinate, char direction) GetOutput(string line1, string line2, string line3)
    {
        Field field = InputParserUtil.ParseFieldLine(line1);
        Car car = InputParserUtil.ParseCarLine(line2);
        CarInstructions instructions = InputParserUtil.ParseInstructionLine(line3);
        
        Simulator simulator = new Simulator(field, car, instructions);
        simulator.RunSimulation();
        
        string[] tokens = car.PrintCurrentPosition().Split(" ");
        return (int.Parse(tokens[0]), int.Parse(tokens[1]), tokens[2][0]);
    }
}