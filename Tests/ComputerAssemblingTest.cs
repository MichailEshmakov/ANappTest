using ComputersTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Тестирование случая 4. "Замена материнской платы"
    /// </summary>
    [TestClass]
    public class ComputerAssemblingTest
    {
        [TestMethod]
        public void WhenChangeDetail_AndSetOtherSameType_ThenSettingNewDetail()
        {
            // Arrange.
            IComputerDetail motherboard = new ComputerDetail(ComputerDetailType.Motherboard);
            IComputerDetail allOtherDetails = new ComputerDetail(ComputerDetailType.AllOtherDetails);
            IAssemblableComputer computer = new Computer(
                details: new HashSet<IComputerDetail> { motherboard, allOtherDetails });
            IComputerDetail otherMotherboard = new ComputerDetail(ComputerDetailType.Motherboard);

            // Act.
            motherboard.RemoveFromComputer();
            otherMotherboard.SetInComputer(computer);

            // Arrange.
            Assert.IsTrue(computer.Details.Contains(otherMotherboard));
        }

        [TestMethod]
        public void WhenChangeDetail_AndSetOtherSameType_ThenOldDetailIsBecomingNotSet()
        {
            // Arrange.
            IComputerDetail motherboard = new ComputerDetail(ComputerDetailType.Motherboard);
            IComputerDetail allOtherDetails = new ComputerDetail(ComputerDetailType.AllOtherDetails);
            IAssemblableComputer computer = new Computer(
                details: new HashSet<IComputerDetail> { motherboard, allOtherDetails });
            IComputerDetail otherMotherboard = new ComputerDetail(ComputerDetailType.Motherboard);

            // Act.
            motherboard.RemoveFromComputer();
            otherMotherboard.SetInComputer(computer);

            // Arrange.
            Assert.IsFalse(computer.Details.Contains(motherboard));
        }

        [TestMethod]
        public void WhenSetDetail_AndItIsSetOnOtherComputer_ThenThrowingException()
        {
            // Arrange.
            IAssemblableComputer firstComputer = new Computer(haveToCreateDetails: true);
            IAssemblableComputer secondComputer = new Computer(haveToCreateDetails: false);
            
            // Act.

            // Arrange.
            Assert.ThrowsException<InvalidOperationException>(() => firstComputer.Details.First().SetInComputer(secondComputer));
        }

        [TestMethod]
        public void WhenSetDetail_AndItIsAlreadySet_ThenThrowingException()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: true);

            // Act.

            // Arrange.
            Assert.ThrowsException<InvalidOperationException>(() => computer.Details.First().SetInComputer(computer));
        }

        [TestMethod]
        public void WhenSetDetail_AndItsTypeIsAlreadySet_ThenThrowingException()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: true);
            IComputerDetail detail = new ComputerDetail(ComputerDetailType.Motherboard);

            // Act.

            // Arrange.
            Assert.ThrowsException<ArgumentException>(() => detail.SetInComputer(computer));
        }

        [TestMethod]
        public void WhenCheckAssembling_AndThereAreNotAllDetailsInComputer_ThenComputerIsNotAssembled()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: false);

            // Act.
            bool isComputerAssembled = computer.IsAssembled();

            // Arrange.
            Assert.IsFalse(isComputerAssembled);
        }

        [TestMethod]
        public void WhenCheckAssembling_AndThereAreAllDetailsInComputer_ThenComputerIsAssembled()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: true);

            // Act.
            bool isComputerAssembled = computer.IsAssembled();

            // Arrange.
            Assert.IsTrue(isComputerAssembled);
        }

        [TestMethod]
        public void WhenSwitchComputerOn_AndComputerIsNotAssembled_ThenThrowingException()
        {
            // Arrange.
            Computer computer = new Computer(haveToCreateDetails: false);

            // Act.

            // Arrange.
            Assert.ThrowsException<InvalidOperationException>(() => computer.SwitchOn());
        }

        [TestMethod]
        public void WhenSwitchComputerOn_AndComputerIsAssembled_ThenComputerIsSwitchingOn()
        {
            // Arrange.
            Computer computer = new Computer(haveToCreateDetails: true);

            // Act.
            computer.SwitchOn();

            // Arrange.
            Assert.IsTrue(computer.IsOn);
        }

        [TestMethod]
        public void WhenDetailRemoveFromComputer_AndComputerIsOn_ThenComputerIsSwitchingOff()
        {
            // Arrange.
            Computer computer = new Computer(isOn: true, haveToCreateDetails: true);

            // Act.
            computer.Details.First().RemoveFromComputer();

            // Arrange.
            Assert.IsTrue(computer.IsOn);
        }

        [TestMethod]
        public void WhenDetailRemoveFromComputer_AndDetailIsSetInIt_ThenDetailsComputerBecomingNull()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: true);
            IComputerDetail detail = computer.Details.First();

            // Act.
            detail.RemoveFromComputer();

            // Arrange.
            Assert.IsNull(detail.Computer);
        }

        [TestMethod]
        public void WhenDetailSetInComputer_AndDetailIsNotSetInIt_ThenDetailsComputerBecomingThis()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(haveToCreateDetails: false);
            IComputerDetail detail = new ComputerDetail(ComputerDetailType.Motherboard);

            // Act.
            detail.SetInComputer(computer);

            // Arrange.
            Assert.AreSame(computer, detail.Computer);
        }
    }
}
