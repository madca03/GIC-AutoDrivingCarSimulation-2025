using AutoDrivingCarSimulation.Business.Constants;

namespace AutoDrivingCarSimulation.Business.Extensions;

public static class OrientationExtensions
{
    public static Orientation TurnLeft(this Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.NORTH: return Orientation.WEST;
            case Orientation.WEST:  return Orientation.SOUTH;
            case Orientation.SOUTH: return Orientation.EAST;
            case Orientation.EAST:  return Orientation.NORTH;
            default:                return Orientation.NORTH;
        }
    }

    public static Orientation TurnRight(this Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.NORTH: return Orientation.EAST;
            case Orientation.EAST:  return Orientation.SOUTH;
            case Orientation.SOUTH: return Orientation.WEST;
            case Orientation.WEST:  return Orientation.NORTH;
            default:                return Orientation.NORTH;
        }
    }

    public static int DeltaX(this Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.EAST:  return 1;
            case Orientation.WEST:  return -1;
            default:                return 0;
        }
    }

    public static int DeltaY(this Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.NORTH: return 1;
            case Orientation.SOUTH: return -1;
            default:                return 0;
        }
    }
}