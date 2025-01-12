namespace AutoDrivingCarSimulation.Test;

public class UnitTest1
{
    [Fact]
    public void Test1_Simple_Movement()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "1 1 N", "FFRFF");
        
        // Assert
        Assert.Equal(3, result.xCoordinate);
        Assert.Equal(3, result.yCoordinate);
        Assert.Equal('E', result.direction);
    }
    
    [Fact]
    public void Test2_Car_Moves_Outside_Boundary()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "2 2 N", "FFFF");
        
        // Assert
        Assert.Equal(2, result.xCoordinate);
        Assert.Equal(4, result.yCoordinate);
        Assert.Equal('N', result.direction);
    }
    
    [Fact]
    public void Test3_Car_Tries_To_Move_Outside_Boundary()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "0 0 S", "F");
        
        // Assert
        Assert.Equal(0, result.xCoordinate);
        Assert.Equal(0, result.yCoordinate);
        Assert.Equal('S', result.direction);
    }
    
    [Fact]
    public void Test4_Moving_East_And_Right_Turns()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "1 1 E", "RFRFF");
        
        // Assert
        Assert.Equal(3, result.xCoordinate);
        Assert.Equal(2, result.yCoordinate);
        Assert.Equal('S', result.direction);
    }
    
    [Fact]
    public void Test5_Car_Starts_Outside_Boundary()
    {
        // Act
        var exception = Assert.Throws<Exception>(() =>
            AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "6 6 N", "FFRFF"));

        Assert.Equal("Out of bounds", exception.Message);
    }
    
    [Fact]
    public void Test6_Full_Movement()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("10 10", "3 3 E", "FFFFRFFLF");
        
        // Assert
        Assert.Equal(4, result.xCoordinate);
        Assert.Equal(7, result.yCoordinate);
        Assert.Equal('N', result.direction);
    }
    
    [Fact]
    public void Test7_All_Turns_Only()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "1 1 N", "LLLL");
        
        // Assert
        Assert.Equal(1, result.xCoordinate);
        Assert.Equal(1, result.yCoordinate);
        Assert.Equal('S', result.direction);
    }
    
    [Fact]
    public void Test8_Turn_Without_Movement()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "3 3 N", "LFRLF");
        
        // Assert
        Assert.Equal(2, result.xCoordinate);
        Assert.Equal(4, result.yCoordinate);
        Assert.Equal('W', result.direction);
    }
    
    [Fact]
    public void Test9_Moving_North_Then_South()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "3 3 N", "FFRFFRFF");
        
        // Assert
        Assert.Equal(3, result.xCoordinate);
        Assert.Equal(2, result.yCoordinate);
        Assert.Equal('W', result.direction);
    }
    
    [Fact]
    public void Test10_No_Movement_Only_Turns()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "2 2 S", "RLRLRL");
        
        // Assert
        Assert.Equal(2, result.xCoordinate);
        Assert.Equal(2, result.yCoordinate);
        Assert.Equal('N', result.direction);
    }
    
    [Fact]
    public void Test11_Car_Moves_To_Upper_Boundary()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "2 4 N", "FFF");
        
        // Assert
        Assert.Equal(2, result.xCoordinate);
        Assert.Equal(5, result.yCoordinate);
        Assert.Equal('N', result.direction);
    }
    
    [Fact]
    public void Test12_Moving_East_With_Boundary_Check()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "4 2 E", "FFF");
        
        // Assert
        Assert.Equal(5, result.xCoordinate);
        Assert.Equal(2, result.yCoordinate);
        Assert.Equal('E', result.direction);
    }
    
    [Fact]
    public void Test13_Boundary_Hit_On_North_Move()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "2 4 N", "F");
        
        // Assert
        Assert.Equal(2, result.xCoordinate);
        Assert.Equal(5, result.yCoordinate);
        Assert.Equal('N', result.direction);
    }
    
    [Fact]
    public void Test14_Car_Tries_To_Move_Outside_Right()
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "4 2 E", "F");
        
        // Assert
        Assert.Equal(5, result.xCoordinate);
        Assert.Equal(2, result.yCoordinate);
        Assert.Equal('E', result.direction);
    }
    
    [Fact]
    public void Test19_Left_Boundaries()
    {
        // Act
        var exception = Assert.Throws<Exception>(() => AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput("5 5", "0 3 W", "F"));
        
        Assert.Equal("Out of bounds", exception.Message);
    }
    
    [Theory]
    [InlineData("5 5", "1 1 E", "", 1, 1, 'E')] // No Command (Car Stays In Place)
    [InlineData("10 10", "1 1 N", "FFRFFFRRLFF", 4, 1, 'S')] // Full Exploration (Overstepping Boundary)
    [InlineData("5 5", "4 3 E", "F", 4, 3, 'E')]
    [InlineData("5 5", "4 4 N", "FFRFFRFF", 4, 2, 'S')] // Multiple boundary hit scenario
    [InlineData("5 5", "4 0 S", "FFRLFF", 4, 0, 'S')] // Starting on boundary and turning
    public void ShouldReturnCorrectCoordinates(string line1, string line2, string line3, int xFinalCoordinate, int yFinalCoordinate, char finalDirection)
    {
        // Act
        var result = AutoDrivingCarSimulation.SolutionPart1.Program.GetOutput(line1, line2, line3);
        
        // Assert
        Assert.Equal(xFinalCoordinate, result.xCoordinate);
        Assert.Equal(yFinalCoordinate, result.yCoordinate);
        Assert.Equal(finalDirection, result.direction);
    }
}