using ComputersTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Тестирование случая 2. "Установка пользовательского приложения в компьютерном классе"
    /// </summary>
    [TestClass]
    public class ComputerClassTest
    {
        [TestMethod]
        public void WhenInstallApp_AndCopmuterThereIsInClassAndSwitchedOn_ThenAppBecomingInstalled()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: true);
            IComputerClass computerClass = new ComputerClass(
                computers: new List<IInstallingSuitable>() { computer });
            IApplication application = new Application();

            // Act.
            computerClass.Install(computerIndex: 0, application: application);

            // Assert.
            Assert.IsTrue(computer.HasApplication(application));
        }

        [TestMethod]
        public void WhenCheckAppInComputer_AndThereWasntInstalling_ThenAppIsntBeingOnComputer()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: true);
            IComputerClass computerClass = new ComputerClass(
                computers: new List<IInstallingSuitable>() { computer });
            IApplication application = new Application();

            // Act.
            bool result = computer.HasApplication(application);

            // Assert.
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInstallApp_AndCopmuterAlreadyHaveThisApp_ThenThrowingException()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: true);
            IComputerClass computerClass = new ComputerClass(
                computers: new List<IInstallingSuitable>() { computer });
            IApplication application = new Application();
            computerClass.Install(computerIndex: 0, application: application);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => computerClass.Install(computerIndex: 0, application: application));
        }

        [TestMethod]
        public void WhenInstallApp_AndCopmuterThereIsNotInClass_ThenThrowingException()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: true);
            IComputerClass computerClass = new ComputerClass(
                computers: new List<IInstallingSuitable>() { computer });
            IApplication application = new Application();

            // Act.
            
            // Assert.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => computerClass.Install(computerIndex: 1, application: application));
        }

        [TestMethod]
        public void WhenInstallApp_AndCopmuterIsSwitchedOff_ThenThrowingException()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: false);
            IComputerClass computerClass = new ComputerClass(
                computers: new List<IInstallingSuitable>() { computer });
            IApplication application = new Application();

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => computerClass.Install(computerIndex: 0, application: application));
        }

        [TestMethod]
        public void WhenCreateComputerClass_AndCopmutersAreSame_ThenThrowingException()
        {
            // Assert.
            IInstallingSuitable computer = new Computer(isOn: false);

            // Act.

            // Assert.
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IComputerClass computerClass = new ComputerClass(
                    computers: new List<IInstallingSuitable>() { computer, computer, computer });
            });
        }

        [TestMethod]
        public void WhenCreateComputerClass_AndCopmutersAreNotSame_ThenCreatingComputerClassWithThatComputers()
        {
            // Assert.
            List<IInstallingSuitable> computers = new List<IInstallingSuitable>()
            {
                new Computer(isOn: false),
                new Computer(isOn: true)
            };

            // Act.
            IComputerClass computerClass = new ComputerClass(computers);

            // Assert.
            Assert.IsTrue(computerClass.Computers.ToHashSet().SetEquals(computers));
        }
    }
}
