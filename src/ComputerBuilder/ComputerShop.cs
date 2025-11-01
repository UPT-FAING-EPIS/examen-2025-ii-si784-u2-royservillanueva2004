public class ComputerShop
{
    public void ConstructComputer(ComputerBuilder builder)
    {
        builder.SetCPU();
        builder.SetRAM();
        builder.SetHardDrive();
        builder.SetGraphicsCard();
        builder.SetSoundCard();
    }
    
    // Método sobrecargado para construir sin componentes opcionales
    public void ConstructBasicComputer(ComputerBuilder builder)
    {
        builder.SetCPU();
        builder.SetRAM();
        builder.SetHardDrive();
    }
}