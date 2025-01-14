namespace AutoDrivingCarSimulation.SolutionPart2;

public class SimulationResult
{
    public string CollidedCars { get; set; }
    public string CollisionPosition { get; set; }
    public int Step { get; set; }
    public bool HasCollision { get; set; }
}