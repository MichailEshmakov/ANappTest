using ComputersTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    /// <summary>
    /// Тестирование случая 5. "Сбор металлолома"
    /// </summary>
    [TestClass]
    public class ComputerDetailMeltingTest
    {
        [TestMethod]
        public void WhenMeltDetail_AndDetailHasMetal_ThenGettingThatMetal()
        {
            // Arrange.
            int expectedMetal = 10;
            IMeltable detail = new ComputerDetail(detailType: ComputerDetailType.AllOtherDetails, metal: expectedMetal);

            // Act.
            int meltedMetal = detail.Melt();

            // Assert.
            Assert.AreEqual(expectedMetal, meltedMetal);
        }

        [TestMethod]
        public void WhenSetDetailInComputer_AndDetailIsMelt_ThenThrowingException()
        {
            // Arrange.
            ComputerDetail detail = new ComputerDetail(detailType: ComputerDetailType.AllOtherDetails);
            IAssemblableComputer computer = new Computer(hasToCreateDetails: false);
            detail.Melt();

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => detail.SetInComputer(computer));
        }

        [TestMethod]
        public void WhenMeltingDetail_AndDetailIsMelt_ThenThrowingException()
        {
            // Arrange.
            ComputerDetail detail = new ComputerDetail(detailType: ComputerDetailType.AllOtherDetails);
            detail.Melt();

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => detail.Melt());
        }

        [TestMethod]
        public void WhenMeltingDetail_AndDetailIsSetInComputer_ThenThrowingException()
        {
            // Arrange.
            IAssemblableComputer computer = new Computer(hasToCreateDetails: false);
            ComputerDetail detail = new ComputerDetail(detailType: ComputerDetailType.AllOtherDetails, computer: computer);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => detail.Melt());
        }

        [TestMethod]
        public void WhenCreatingDetail_AndMetalIsLessZero_ThenThrowingException()
        {
            // Arrange.

            // Act.

            // Assert.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new ComputerDetail(detailType: ComputerDetailType.AllOtherDetails, metal: -1));
        }
    }
}
