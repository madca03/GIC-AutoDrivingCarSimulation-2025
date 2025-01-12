using AutoDrivingCarSimulation.Solution.App;
using AutoDrivingCarSimulation.Solution.Util;

namespace AutoDrivingCarSimulation.Solution;

public class Program
{
    public static void Main(string[] args)
    {
        string line1 = Console.ReadLine();
        Field field = InputParserUtil.ParseFieldLine(line1);
        string line2 = Console.ReadLine();
        Car car = InputParserUtil.ParseCarLine(line2, field);
        string line3 = Console.ReadLine();
        InstructionProcessor processor = new InstructionProcessor(InputParserUtil.ParseInstructionLine(line3));
        processor.ProcessInstructions(car);
        Console.WriteLine(car.PrintCurrentPosition());
    }

    public static (int xCoordinate, int yCoordinate, char direction) GetOutput(string line1, string line2, string line3)
    {
        Field field = InputParserUtil.ParseFieldLine(line1);
        Car car = InputParserUtil.ParseCarLine(line2, field);
        InstructionProcessor processor = new InstructionProcessor(InputParserUtil.ParseInstructionLine(line3));
        processor.ProcessInstructions(car);
        string[] tokens = car.PrintCurrentPosition().Split(" ");
        return (int.Parse(tokens[0]), int.Parse(tokens[1]), tokens[2][0]);
    }
}