using AutoDrivingCarSimulation.Business.Constants;
using AutoDrivingCarSimulation.Business.Extensions;

namespace AutoDrivingCarSimulation.Business.Core;

public class Car
{
    public string Id { get; } // Cars can have same names so create a unique Id per car.
    public string Name { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public Orientation Orientation { get; private set; }
    private Field _field;

    public Field Field
    {
        private get { return _field; }
        set
        {
            if (!value.IsValidPosition(this.X, this.Y)) throw new Exception("Out of bounds");
            _field = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Car"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="orientation"></param>
    /// <param name="field"></param>
    public Car(string name, int x, int y, Orientation orientation)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
        this.X = x;
        this.Y = y;
        this.Orientation = orientation;
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
        this.X = x;
        this.Y = y;
        this.Orientation = orientation;
    }

    /// <summary>
    /// Moves the car forward.
    /// </summary>
    public void MoveForward()
    {
        int newXPosition = this.X + this.Orientation.DeltaX();
        int newYPosition = this.Y + this.Orientation.DeltaY();

        if (this._field.IsValidPosition(newXPosition, newYPosition))
        {
            this.X = newXPosition;
            this.Y = newYPosition;
        }
    }
    
    /// <summary>
    /// Turns the car 90 degrees to the left.
    /// </summary>
    public void TurnLeft()
    {
        this.Orientation = this.Orientation.TurnLeft();
    }

    /// <summary>
    /// Turns the car 90 degrees to the right.
    /// </summary>
    public void TurnRight()
    {
        this.Orientation = this.Orientation.TurnRight();
    }

    /// <summary>
    /// Gets the car's current position in string format.
    /// </summary>
    /// <returns></returns>
    public string PrintCurrentPosition()
    {
        return $"{this.X} {this.Y} {(char)this.Orientation}";
    }
    
    /// <summary>
    /// This is used for key comparison in Dictionary
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (!(obj is Car)) return false;
        Car other = (Car)obj;
        return this.Id == other.Id;
    }

    /// <summary>
    /// This is used for using this object as key in a Dictionary
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}