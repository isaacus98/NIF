namespace NIF.Test
{
    [TestFixture]
    public class NIFValidatorTest
    {
        [Test]
        public void ValidateNIFTestTrue()
        {
            bool result = NIFValidator.Validate("32700667A");
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateNIFTestFalse()
        {
            bool result = NIFValidator.Validate("32700667B");
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateNIETestTrue()
        {
            bool result = NIFValidator.Validate("Y2910565K");
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateNIETestFalse()
        {
            bool result = NIFValidator.Validate("Y2910565Q");
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCIFTestTrue()
        {
            bool result = NIFValidator.Validate("P9508997E");
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateCIFTestFalse()
        {
            bool result = NIFValidator.Validate("Q21109526");
            Assert.IsFalse(result);
        }
    }
}