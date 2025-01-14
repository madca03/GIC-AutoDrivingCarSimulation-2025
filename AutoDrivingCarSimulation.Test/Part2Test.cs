using AutoDrivingCarSimulation.Business.Model;

namespace AutoDrivingCarSimulation.Test;

public static class SimulationData
{
    public static IEnumerable<object[]> GetSimulationDataWithoutCollision()
    {
        yield return new object[]
        {
            "10 10",
            new List<CarInputModel>
            {
                new CarInputModel
                {
                    NameLine = "A",
                    CoordinateLine = "1 2 N",
                    InstructionLine = "FFRFFFFRRL"
                },
                new CarInputModel
                {
                    NameLine = "B",
                    CoordinateLine = "7 8 W",
                    InstructionLine = "FFLF"
                }
            },
            "A B",
            "5 4",
            7
        };
    }
    
    public static IEnumerable<object[]> GetSimulationDataWithCollision()
    {
        yield return new object[]
        {
            "10 10",
            new List<CarInputModel>
            {
                new CarInputModel
                {
                    NameLine = "A",
                    CoordinateLine = "1 2 N",
                    InstructionLine = "FFRFFFFRRL"
                },
                new CarInputModel
                {
                    NameLine = "B",
                    CoordinateLine = "7 8 W",
                    InstructionLine = "FFLFFFFFFF"
                }
            },
            "A B",
            "5 4",
            7
        };
    }
}

public class Part2Test
{
    [Theory]
    [MemberData(nameof(SimulationData.GetSimulationDataWithCollision), MemberType = typeof(SimulationData))]
    public void ShouldReturnHasCollision(string fieldLine, List<CarInputModel> carInputs, string collidedCars, string collisionPosition, int step)
    {
        // Act
        var simulationResult = SolutionPart2.Program.StartSimulation(fieldLine, carInputs);
        
        Assert.Equal(true, simulationResult.HasCollision);
        Assert.Equal(collidedCars, simulationResult.CollidedCars);
        Assert.Equal(collisionPosition, simulationResult.CollisionPosition);
        Assert.Equal(step, simulationResult.Step);
    }
    
    [Theory]
    [MemberData(nameof(SimulationData.GetSimulationDataWithoutCollision), MemberType = typeof(SimulationData))]
    public void ShouldReturnHasNoCollision(string fieldLine, List<CarInputModel> carInputs, string collidedCars, string collisionPosition, int step)
    {
        // Act
        var simulationResult = SolutionPart2.Program.StartSimulation(fieldLine, carInputs);
        
        Assert.Equal(false, simulationResult.HasCollision);
    }
}