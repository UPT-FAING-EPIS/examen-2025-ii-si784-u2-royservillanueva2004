public abstract class ComputerBuilder
{
    protected Computer Computer { get; private set; } = new Computer();
    
    public abstract void SetCPU();
    public abstract void SetRAM();
    public abstract void SetHardDrive();
    public virtual void SetGraphicsCard() { }
    public virtual void SetSoundCard() { }
    
    public Computer GetComputer() => Computer;
    
    // Método para resetear la computadora (útil para pruebas)
    public void Reset()
    {
        Computer = new Computer();
    }
}