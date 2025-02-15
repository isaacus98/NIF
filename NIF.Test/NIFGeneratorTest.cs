using System.Reflection.Emit;

namespace NIF.Test
{
    [TestFixture]
    public class NIFGeneratorTest
    {
        [Test]
        public void GenerateDNITrue()
        {
            string dni = NIFGenerator.GenerateDNI();
            bool result = NIFValidator.Validate(dni);
            Assert.IsTrue(result);
        }

        [Test]
        public void GenerateMultipleDNITrue()
        {
            IList<string> dniList = NIFGenerator.GenerateDNI(5);

            foreach (string dni in dniList) 
            {
                bool result = NIFValidator.Validate(dni);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void GenerateNIETrue()
        {
            string nie = NIFGenerator.GenerateNIE();
            bool result = NIFValidator.Validate(nie);
            Assert.IsTrue(result);
        }

        [Test]
        public void GenerateMultipleNIETrue()
        {
            IList<string> nieList = NIFGenerator.GenerateNIE(5);

            foreach (string nie in nieList)
            {
                bool result = NIFValidator.Validate(nie);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void GenerateCIFTrue()
        {
            string cif = NIFGenerator.GenerateCIF();
            bool result = NIFValidator.Validate(cif);
            Assert.IsTrue(result);
        }

        [Test]
        public void GenerateMultipleCIFTrue()
        {
            IList<string> cifList = NIFGenerator.GenerateNIE(5);

            foreach (string cif in cifList)
            {
                bool result = NIFValidator.Validate(cif);
                Assert.IsTrue(result);
            }
        }
    }
}
