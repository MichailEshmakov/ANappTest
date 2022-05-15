using ComputersTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    /// <summary>
    /// Тестирование случая 1. "Включение/перезагрузка компьютера"
    /// </summary>
    [TestClass]
    public class ComputerSwitchingTest
    {
        [TestMethod]
        public void WhenSwitchOff_AndComputerIsOn_ThenComputerSwitchingOff()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: true);

            // Act.
            computer.SwitchOff();

            // Assert.
            Assert.IsFalse(computer.IsOn);
        }

        [TestMethod]
        public void WhenSwitchOff_AndComputerIsOff_ThenThrowingException()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: false);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => computer.SwitchOff());
        }

        [TestMethod]
        public void WhenSwitchOn_AndComputerIsOff_ThenComputerSwitchingOn()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: false);

            // Act.
            computer.SwitchOn();

            // Assert.
            Assert.IsTrue(computer.IsOn);
        }

        [TestMethod]
        public void WhenSwitchOn_AndComputerIsOn_ThenThrowingException()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: true);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => computer.SwitchOn());
        }

        [TestMethod]
        public void WhenReboot_AndComputerIsOff_ThenThrowingException()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: false);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => computer.Reboot());
        }

        [TestMethod]
        public void WhenReboot_AndComputerIsOn_ThenComputerSwitchingOffAndThenSwitchingOn()
        {
            // Arrange.
            ISwitchable computer = new Computer(isOn: true);
            bool wasComputerSwitchedOff = false;

            void OnCoputerSwitchedOff()
            {
                wasComputerSwitchedOff = true;
            }

            computer.SwitchedOff += OnCoputerSwitchedOff;

            // Act.
            computer.Reboot();
            computer.SwitchedOff -= OnCoputerSwitchedOff;

            // Assert.
            Assert.IsTrue(wasComputerSwitchedOff && computer.IsOn);
        }
    }
}
