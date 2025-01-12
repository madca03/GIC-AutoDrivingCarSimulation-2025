namespace AutoDrivingCarSimulation.Solution.App;

public class Field
{
    private int width;
    private int height;

    /// <summary>
    /// Initializes a new instance of the <see cref="Field"/> class.
    /// </summary>
    /// <param name="width">Width of the field.</param>
    /// <param name="height">Height of the field.</param>
    public Field(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Validates that a given (x,y) is within the field boundaries.
    /// </summary>
    /// <param name="x">x coordinate.</param>
    /// <param name="y">y coordinate.</param>
    /// <returns>Returns true if the supplied coordinates is valid.</returns>
    public bool IsValidPosition(int x, int y)
    {
        bool isValidXCoordinate = (x >= 0) && (x < width);
        bool isValidYCoordinate = (y >= 0) && (y < height);
        return isValidXCoordinate && isValidYCoordinate;
    }
}