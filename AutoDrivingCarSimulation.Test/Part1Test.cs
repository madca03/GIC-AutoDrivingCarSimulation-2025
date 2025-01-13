namespace AutoDrivingCarSimulation.Test;

public class Part1Test
{
    [Fact]
    public void Car_Starts_Outside_Boundary()
    {
        // Act
        var exception = Assert.Throws<Exception>(() =>
            AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "6 6 N", "FFRFF"));

        Assert.Equal("Out of bounds", exception.Message);
    }
    
    [Theory]
    [InlineData("5 5", "0 3 W", "F", 0, 3, "W")] // Left Boundaries
    [InlineData("5 5", "1 1 N", "FFRFF", 3, 3, "E")] // Simple movement
    [InlineData("5 5", "2 2 N", "FFFF", 2, 4, "N")] // Car moves outside boundary
    [InlineData("5 5", "0 0 S", "F", 0, 0, "S")] // Car tries to move outside boundary
    [InlineData("5 5", "1 1 E", "RFRFF", 0, 0, "W")] // Moving east and right turns
    [InlineData("10 10", "3 3 E", "FFFFRFFLF", 8, 1, "E")] // Full movement
    [InlineData("5 5", "1 1 N", "LLLL", 1, 1, "N")] // All Turns Only
    [InlineData("5 5", "3 3 N", "LFRLF", 1, 3, "W")] // Turn without movement
    [InlineData("5 5", "3 3 N", "FFRFFRFF", 4, 2, "S")] // Moving north then south
    [InlineData("5 5", "2 2 S", "RLRLRL", 2, 2, "S")] // No Movement Only Turns
    [InlineData("5 5", "2 4 N", "FFF", 2, 4, "N")] // Car Moves to Upper Boundary
    [InlineData("5 5", "4 2 E", "FFF", 4, 2, "E")] // Car tries to move outside right
    [InlineData("10 10", "1 2 N", "FFRFFFRRLF", 4, 3, "S")]
    [InlineData("5 5", "1 1 E", "", 1, 1, "E")] // No Command (Car Stays In Place)
    [InlineData("10 10", "1 1 N", "FFRFFFRRLFF", 4, 1, "S")] // Full Exploration (Overstepping Boundary)
    [InlineData("5 5", "4 3 E", "F", 4, 3, "E")]
    [InlineData("5 5", "4 4 N", "FFRFFRFF", 4, 2, "S")] // Multiple boundary hit scenario
    [InlineData("5 5", "4 0 S", "FFRLFF", 4, 0, "S")] // Starting on boundary and turning
    public void ShouldReturnCorrectCoordinates(string line1, string line2, string line3, int xFinalCoordinate, int yFinalCoordinate, string finalDirection)
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.StartSimulation(line1, line2, line3);
        
        string[] tokens = result.Split(" ");
        int xCoordinate = int.Parse(tokens[0]);
        int yCoordinate = int.Parse(tokens[1]);
        string direction = tokens[2];
        
        // Assert
        Assert.Equal(xFinalCoordinate, xCoordinate);
        Assert.Equal(yFinalCoordinate, yCoordinate);
        Assert.Equal(finalDirection, direction);
    }
}