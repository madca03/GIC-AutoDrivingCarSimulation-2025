using AutoDrivingCarSimulation.Business.Model;

namespace AutoDrivingCarSimulation.SolutionPart2;

public class InputParser
{
    public string FieldDimensionLine { get; set; }
    public List<CarInputModel> CarInputs { get; set; }

    public InputParser()
    {
        CarInputs = new List<CarInputModel>();
    }

    public void GetInput()
    {
        var input = new List<string>();
        string line;
        
        while ((line = Console.ReadLine()) != null)
        {
            input.Add(line);
        }

        FieldDimensionLine = input[0];

        for (int i = 1; i < input.Count; i += 3)
        {
            CarInputModel carInput = new CarInputModel();
            carInput.NameLine = input[i];
            carInput.CoordinateLine = input[i + 1];
            carInput.InstructionLine = input[i + 2];
            CarInputs.Add(carInput);
        }
    }
}