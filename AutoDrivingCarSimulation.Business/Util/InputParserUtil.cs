using AutoDrivingCarSimulation.Business.Constants;
using AutoDrivingCarSimulation.Business.Core;

namespace AutoDrivingCarSimulation.Business.Util;

public static class InputParserUtil
{
    /// <summary>
    /// Parses the input line containing the Field's width and height.
    /// </summary>
    /// <param name="fieldLine">Input string containing the field's width and height.</param>
    /// <returns>Returns Field object.</returns>
    /// <exception cref="Exception"></exception>
    public static Field ParseFieldLine(string fieldLine)
    {
        string[] tokens = fieldLine.Split(" ");
        if (tokens.Length != 2) throw new Exception($"Invalid input for the field's width & height: {fieldLine}");

        int width;
        int height;

        if (!int.TryParse(tokens[0], out width))
            throw new Exception($"Invalid value for the field's width: {fieldLine}");
        if (!int.TryParse(tokens[1], out height))
            throw new Exception($"Invalid value for the field's height: {fieldLine}");
        
        return new Field(width, height);
    }

    /// <summary>
    /// Parses the input line containing the car's initial position.
    /// </summary>
    /// <param name="carLine">Input string containing the car's initial position.</param>
    /// <returns>Returns Car object.</returns>
    /// <exception cref="Exception"></exception>
    public static Car ParseCarLine(string carLine)
    {
        string[] tokens = carLine.Split(" ");
        if (tokens.Length != 3) throw new Exception($"Invalid input for the car's initial position: {carLine}");

        int xCoordinate;
        int yCoordinate;
        Orientation orientation;

        if (!int.TryParse(tokens[0], out xCoordinate))
            throw new Exception($"Invalid value for the car's x coordinate: {carLine}");
        if (!int.TryParse(tokens[1], out yCoordinate))
            throw new Exception($"Invalid value for the car's y coordinate: {carLine}");
        if (tokens[2].Length > 1)
            throw new Exception($"Invalid value for the car's orientation. Must be one of the following: N E W S - {carLine}");

        string orientationString = tokens[2].ToUpper();
        
        switch (orientationString)
        {
            case "N":
                orientation = Orientation.NORTH;
                break;
            case "E":
                orientation = Orientation.EAST;
                break;
            case "W":
                orientation = Orientation.WEST;
                break;
            case "S":
                orientation = Orientation.SOUTH;
                break;
            default:
                throw new Exception($"Invalid value for the car's orientation. Must be one of the following: N E W S - {carLine}");
        }

        return new Car(xCoordinate, yCoordinate, orientation);
    }

    /// <summary>
    /// Parses the input line containing the list of car movements.
    /// </summary>
    /// <param name="line">Input line.</param>
    /// <returns>List of car movement instructions.</returns>
    public static CarInstructions ParseInstructionLine(string line)
    {
        List<InstructionType> instructions = new List<InstructionType>();

        foreach (char c in line)
        {
            switch (c)
            {
                case 'F':
                    instructions.Add(InstructionType.FORWARD);
                    break;
                case 'R':
                    instructions.Add(InstructionType.TURN_RIGHT);
                    break;
                case 'L':
                    instructions.Add(InstructionType.TURN_LEFT);
                    break;
            } 
        }
        
        return new CarInstructions(instructions);
    }
}