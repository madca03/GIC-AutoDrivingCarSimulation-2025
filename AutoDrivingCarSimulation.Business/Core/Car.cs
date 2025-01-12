using AutoDrivingCarSimulation.Business.Constants;

namespace AutoDrivingCarSimulation.Business.Core;

public class Car
{
    public string Id { get; }
    private int x;
    private int y;
    private Orientation orientation;
    private Field _field;

    public Field Field
    {
        private get { return _field; }
        set
        {
            if (!value.IsValidPosition(x, y)) throw new Exception("Out of bounds");
            _field = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Car"/> class.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="orientation"></param>
    /// <param name="field"></param>
    public Car(int x, int y, Orientation orientation)
    {
        this.Id = Guid.NewGuid().ToString();
        this.x = x;
        this.y = y;
        this.orientation = orientation;
    }

    /// <summary>
    /// Moves the car forward.
    /// </summary>
    public void MoveForward()
    {
        int newXPosition = this.x;
        int newYPosition = this.y;

        switch (this.orientation)
        {
            case Orientation.NORTH:
                newYPosition += 1;
                break;
            case Orientation.EAST:
                newXPosition += 1;
                break;
            case Orientation.SOUTH:
                newYPosition -= 1;
                break;
            case Orientation.WEST:
                newXPosition -= 1;
                break;
        }

        if (this._field.IsValidPosition(newXPosition, newYPosition))
        {
            this.x = newXPosition;
            this.y = newYPosition;
        }
    }
    
    /// <summary>
    /// Turns the car 90 degrees to the left.
    /// </summary>
    public void TurnLeft()
    {
        Rotate(Rotation.COUNTERCLOCKWISE);
    }

    /// <summary>
    /// Turns the car 90 degrees to the right.
    /// </summary>
    public void TurnRight()
    {
        Rotate(Rotation.CLOCKWISE);
    }

    /// <summary>
    /// Gets the car's current position in string format.
    /// </summary>
    /// <returns></returns>
    public string PrintCurrentPosition()
    {
        return $"{this.x} {this.y} {(char)this.orientation}";
    }

    /// <summary>
    /// Changes the car's orientation either clockwise or counterclockwise.
    /// </summary>
    /// <param name="rotation">Rotation type which can be either clockwise or counterclockwise.</param>
    private void Rotate(Rotation rotation)
    {
        switch (this.orientation)
        {
            case Orientation.NORTH:
                if (rotation == Rotation.CLOCKWISE) this.orientation = Orientation.EAST;
                else if (rotation == Rotation.COUNTERCLOCKWISE) this.orientation = Orientation.WEST;
                break;
            case Orientation.EAST:
                if (rotation == Rotation.CLOCKWISE) this.orientation = Orientation.SOUTH;
                else if (rotation == Rotation.COUNTERCLOCKWISE) this.orientation = Orientation.NORTH;
                break;
            case Orientation.SOUTH:
                if (rotation == Rotation.CLOCKWISE) this.orientation = Orientation.WEST;
                else if (rotation == Rotation.COUNTERCLOCKWISE) this.orientation = Orientation.EAST;
                break;
            case Orientation.WEST:
                if (rotation == Rotation.CLOCKWISE) this.orientation = Orientation.NORTH;
                else if (rotation == Rotation.COUNTERCLOCKWISE) this.orientation = Orientation.SOUTH;
                break;
        }
    }
}