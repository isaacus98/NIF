using NIF;

namespace Tests
{
    [TestClass]
    public class NifValidatorTest
    {
        [TestMethod]
        public void ValidateNIFTestTrue()
        {
            bool result = NifValidator.Validate("32700667A");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNIFTestFalse()
        {
            bool result = NifValidator.Validate("32700667B");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateNIETestTrue()
        {
            bool result = NifValidator.Validate("Y2910565K");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNIETestFalse()
        {
            bool result = NifValidator.Validate("Y2910565Q");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateCIFTestTrue()
        {
            bool result = NifValidator.Validate("P9508997E");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateCIFTestFalse()
        {
            bool result = NifValidator.Validate("Q21109526");
            Assert.IsFalse(result);
        }
    }
}