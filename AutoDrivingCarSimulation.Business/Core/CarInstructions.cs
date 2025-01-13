using AutoDrivingCarSimulation.Business.Constants;

namespace AutoDrivingCarSimulation.Business.Core;

public class CarInstructions
{
    private Queue<InstructionType> instructions;
    private Car _car;
    public string CarId { get; private set; }
    
    public Car Car
    {
        private get { return _car; }
        set
        {
            _car = value;
            CarId = value.Id;
        }
    }
    
    public CarInstructions(List<InstructionType> instructions, string carId)
    {
        this.instructions = new Queue<InstructionType>(instructions);
        this.CarId = carId;
    }

    public bool HasMoreInstructions()
    {
        return this.instructions.Count > 0;
    }

    public InstructionType PeekNextInstruction()
    {
        return this.instructions.Peek();
    }

    public InstructionType ConsumeNextInstruction()
    {
        return this.instructions.Dequeue();
    }
}