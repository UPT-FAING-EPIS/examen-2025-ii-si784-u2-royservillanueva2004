using Xunit;

namespace ComputerBuilder.UnitTests
{
    public class ComputerTests
    {
        [Fact]
        public void DisplaySpecifications_ShouldReturnCorrectFormat()
        {
            // Arrange
            var computer = new Computer
            {
                CPU = "Test CPU",
                RAM = "8 GB",
                HardDrive = "500 GB HDD"
            };

            // Act
            var result = computer.DisplaySpecifications();

            // Assert
            Assert.Contains("CPU: Test CPU", result);
            Assert.Contains("RAM: 8 GB", result);
            Assert.Contains("Hard Drive: 500 GB HDD", result);
            Assert.Contains("Graphics Card: Not present", result);
            Assert.Contains("Sound Card: Not present", result);
        }

        [Fact]
        public void DisplaySpecifications_WithOptionalComponents_ShouldIncludeThem()
        {
            // Arrange
            var computer = new Computer
            {
                CPU = "Test CPU",
                RAM = "8 GB",
                HardDrive = "500 GB HDD",
                GraphicsCard = "Test GPU",
                SoundCard = "Test Sound"
            };

            // Act
            var result = computer.DisplaySpecifications();

            // Assert
            Assert.Contains("Graphics Card: Test GPU", result);
            Assert.Contains("Sound Card: Test Sound", result);
        }
    }

    public class GamingComputerBuilderTests
    {
        [Fact]
        public void SetCPU_ShouldSetHighPerformanceCPU()
        {
            // Arrange
            var builder = new GamingComputerBuilder();

            // Act
            builder.SetCPU();
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("High Performance CPU", computer.CPU);
        }

        [Fact]
        public void SetRAM_ShouldSet16GBDDR4()
        {
            // Arrange
            var builder = new GamingComputerBuilder();

            // Act
            builder.SetRAM();
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("16 GB DDR4", computer.RAM);
        }

        [Fact]
        public void SetHardDrive_ShouldSet1TBSSD()
        {
            // Arrange
            var builder = new GamingComputerBuilder();

            // Act
            builder.SetHardDrive();
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("1 TB SSD", computer.HardDrive);
        }

        [Fact]
        public void SetGraphicsCard_ShouldSetHighEndGraphicsCard()
        {
            // Arrange
            var builder = new GamingComputerBuilder();

            // Act
            builder.SetGraphicsCard();
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("High-end Graphics Card", computer.GraphicsCard);
        }

        [Fact]
        public void SetSoundCard_ShouldSetSurroundSoundCard()
        {
            // Arrange
            var builder = new GamingComputerBuilder();

            // Act
            builder.SetSoundCard();
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("7.1 Surround Sound Card", computer.SoundCard);
        }

        [Fact]
        public void Reset_ShouldCreateNewComputerInstance()
        {
            // Arrange
            var builder = new GamingComputerBuilder();
            builder.SetCPU();
            var originalComputer = builder.GetComputer();

            // Act
            builder.Reset();
            var newComputer = builder.GetComputer();

            // Assert
            Assert.NotSame(originalComputer, newComputer);
            Assert.Null(newComputer.CPU);
        }
    }

    public class ComputerShopTests
    {
        [Fact]
        public void ConstructComputer_ShouldBuildCompleteComputer()
        {
            // Arrange
            var shop = new ComputerShop();
            var builder = new GamingComputerBuilder();

            // Act
            shop.ConstructComputer(builder);
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("High Performance CPU", computer.CPU);
            Assert.Equal("16 GB DDR4", computer.RAM);
            Assert.Equal("1 TB SSD", computer.HardDrive);
            Assert.Equal("High-end Graphics Card", computer.GraphicsCard);
            Assert.Equal("7.1 Surround Sound Card", computer.SoundCard);
        }

        [Fact]
        public void ConstructBasicComputer_ShouldBuildWithoutOptionalComponents()
        {
            // Arrange
            var shop = new ComputerShop();
            var builder = new GamingComputerBuilder();

            // Act
            shop.ConstructBasicComputer(builder);
            var computer = builder.GetComputer();

            // Assert
            Assert.Equal("High Performance CPU", computer.CPU);
            Assert.Equal("16 GB DDR4", computer.RAM);
            Assert.Equal("1 TB SSD", computer.HardDrive);
            Assert.Null(computer.GraphicsCard); // No se configuró
            Assert.Null(computer.SoundCard);    // No se configuró
        }
    }
}