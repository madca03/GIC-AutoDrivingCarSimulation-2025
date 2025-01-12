using AutoDrivingCarSimulation.Business.Constants;

namespace AutoDrivingCarSimulation.Business.Core;

public class CarInstructions
{
    private Queue<InstructionType> instructions;
    private Car _car;
    
    public Car Car
    {
        private get { return _car; }
        set { _car = value; }
    }
    
    public CarInstructions(List<InstructionType> instructions)
    {
        this.instructions = new Queue<InstructionType>(instructions);
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