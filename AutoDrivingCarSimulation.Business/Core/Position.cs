namespace AutoDrivingCarSimulation.Business.Core;

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }
    
    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    /// <summary>
    /// This is used for key comparison in Dictionary
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (!(obj is Position)) return false;
        Position other = (Position)obj;
        return this.X == other.X && this.Y == other.Y;
    }

    /// <summary>
    /// This is used for using this object as key in a Dictionary
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return 31 * this.X + this.Y;
    }
}