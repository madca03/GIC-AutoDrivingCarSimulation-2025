using AutoDrivingCarSimulation.Business.Constants;
using AutoDrivingCarSimulation.Business.Core;

namespace AutoDrivingCarSimulation.SolutionPart1;

public class Simulator
{
    private Field field;
    private Car car;
    private CarInstructions carInstructions;

    public Simulator(Field field, Car car, CarInstructions carInstructions)
    {
        this.field = field;
        this.car = car;
        this.car.Field = field;
        this.carInstructions = carInstructions;
        this.carInstructions.Car = car;
    }
    
    public void RunSimulation()
    {
        while (carInstructions.HasMoreInstructions())
        {
            InstructionType instruction = carInstructions.ConsumeNextInstruction();
            
            switch (instruction)
            {
                case InstructionType.FORWARD:
                    car.MoveForward();
                    break;
                case InstructionType.TURN_LEFT:
                    car.TurnLeft();
                    break;
                case InstructionType.TURN_RIGHT:
                    car.TurnRight();
                    break;
            }
        }
    }
}