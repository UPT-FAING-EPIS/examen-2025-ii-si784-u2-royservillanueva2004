public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string HardDrive { get; set; }
    public string GraphicsCard { get; set; }
    public string SoundCard { get; set; }
    
    public string DisplaySpecifications()
    {
        string specs = $"CPU: {CPU} \n";
        specs += $"RAM: {RAM} \n";
        specs += $"Hard Drive: {HardDrive} \n";
        specs += $"Graphics Card: {GraphicsCard ?? "Not present"} \n";
        specs += $"Sound Card: {SoundCard ?? "Not present"} \n";
        return specs;
    }
}