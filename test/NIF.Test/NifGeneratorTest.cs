using NIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class NifGeneratorTest
    {
        [TestMethod]
        public void GenerateDNITrue()
        {
            String dni = NifGenerator.GenerateDNI();
            bool result = NifValidator.Validate(dni);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GenerateMultipleDNITrue()
        {
            String[] dni = NifGenerator.GenerateDNI(5);

            for (int i = 0; i < dni.Length; i++)
            {
                bool result = NifValidator.Validate(dni[i]);
                Assert.IsTrue(result);
            }
            
        }

        [TestMethod]
        public void GenerateNIETrue()
        {
            String nie = NifGenerator.GenerateNIE();
            bool result = NifValidator.Validate(nie);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GenerateMultipleNIETrue()
        {
            String[] nie = NifGenerator.GenerateNIE(5);

            for (int i = 0; i < nie.Length; i++)
            {
                bool result = NifValidator.Validate(nie[i]);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void GenerateCIFTrue()
        {
            String cif = NifGenerator.GenerateCIF();
            bool result = NifValidator.Validate(cif);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GenerateMultipleCIFTrue()
        {
            String[] cif = NifGenerator.GenerateNIE(5);

            for (int i = 0; i < cif.Length; i++)
            {
                bool result = NifValidator.Validate(cif[i]);
                Assert.IsTrue(result);
            }
        }
    }
}
