using NIF;

namespace Tests
{
    [TestClass]
    public class NifValidatorTest
    {
        [TestMethod]
        public void ValidateNIFTestTrue()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("32700667A");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNIFTestFalse()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("32700667B");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateNIETestTrue()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("Y2910565K");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNIETestFalse()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("Y2910565Q");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateCIFTestTrue()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("F86988169");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateCIFTestFalse()
        {
            NifValidator validator = new NifValidator();
            bool result = validator.Validate("Q21109526");
            Assert.IsFalse(result);
        }
    }
}