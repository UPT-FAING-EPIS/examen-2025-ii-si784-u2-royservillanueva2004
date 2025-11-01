using Xunit;

namespace ComputerBuilder.BDDTests
{
    public class ComputerBuilderBDDTests
    {
        private ComputerShop _shop = null!;
        private GamingComputerBuilder _builder = null!;
        private Computer _computer = null!;

        [Fact]
        public void Scenario_BuildingCompleteGamingComputer()
        {
            // Given a computer shop and a gaming computer builder
            _shop = new ComputerShop();
            _builder = new GamingComputerBuilder();

            // When the shop constructs a complete gaming computer
            _shop.ConstructComputer(_builder);
            _computer = _builder.GetComputer();

            // Then the computer should have high performance components
            Assert.Equal("High Performance CPU", _computer.CPU);
            Assert.Equal("16 GB DDR4", _computer.RAM);
            Assert.Equal("1 TB SSD", _computer.HardDrive);
            Assert.Equal("High-end Graphics Card", _computer.GraphicsCard);
            Assert.Equal("7.1 Surround Sound Card", _computer.SoundCard);

            // And the specifications should be displayed correctly
            var specs = _computer.DisplaySpecifications();
            Assert.Contains($"CPU: {_computer.CPU}", specs);
            Assert.Contains($"RAM: {_computer.RAM}", specs);
            Assert.Contains($"Hard Drive: {_computer.HardDrive}", specs);
            Assert.Contains($"Graphics Card: {_computer.GraphicsCard}", specs);
            Assert.Contains($"Sound Card: {_computer.SoundCard}", specs);
        }

        [Fact]
        public void Scenario_BuildingBasicComputerWithoutOptionalComponents()
        {
            // Given a computer shop and a gaming computer builder
            _shop = new ComputerShop();
            _builder = new GamingComputerBuilder();

            // When the shop constructs a basic computer without optional components
            _shop.ConstructBasicComputer(_builder);
            _computer = _builder.GetComputer();

            // Then the computer should have only essential components
            Assert.Equal("High Performance CPU", _computer.CPU);
            Assert.Equal("16 GB DDR4", _computer.RAM);
            Assert.Equal("1 TB SSD", _computer.HardDrive);
            Assert.Null(_computer.GraphicsCard);
            Assert.Null(_computer.SoundCard);

            // And the specifications should be displayed correctly
            var specs = _computer.DisplaySpecifications();
            Assert.Contains($"CPU: {_computer.CPU}", specs);
            Assert.Contains($"RAM: {_computer.RAM}", specs);
            Assert.Contains($"Hard Drive: {_computer.HardDrive}", specs);
            Assert.Contains("Graphics Card: Not present", specs);
            Assert.Contains("Sound Card: Not present", specs);
        }
    }
}