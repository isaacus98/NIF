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
            NifValidator validator = new NifValidator();
            NifGenerator generator = new NifGenerator();
            String dni = generator.GenerateDNI();
            bool result = validator.Validate(dni);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GenerateMultipleDNITrue()
        {
            NifValidator validator = new NifValidator();
            NifGenerator generator = new NifGenerator();
            String[] dni = generator.GenerateDNI(5);

            for (int i = 0; i < dni.Length; i++)
            {
                bool result = validator.Validate(dni[i]);
                Assert.IsTrue(result);
            }
            
        }

        [TestMethod]
        public void GenerateNIETrue()
        {
            NifValidator validator = new NifValidator();
            NifGenerator generator = new NifGenerator();
            String nie = generator.GenerateNIE();
            bool result = validator.Validate(nie);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GenerateMultipleNIETrue()
        {
            NifValidator validator = new NifValidator();
            NifGenerator generator = new NifGenerator();
            String[] nie = generator.GenerateNIE(5);

            for (int i = 0; i < nie.Length; i++)
            {
                bool result = validator.Validate(nie[i]);
                Assert.IsTrue(result);
            }
        }
    }
}
