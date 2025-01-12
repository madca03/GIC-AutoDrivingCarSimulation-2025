namespace AutoDrivingCarSimulation.SolutionPart1;

public class InputParser
{
    public string Line1 { get; private set; }
    public string Line2 { get; private set; }
    public string Line3 { get; private set; }

    public void GetInput()
    {
        string line;
        int i = 0;
        
        while ((line = Console.ReadLine()) != null)
        {
            if (i == 0) Line1 = line;
            if (i == 1) Line2 = line;
            if (i == 2) Line3 = line;
            i++;
        }
    }
}