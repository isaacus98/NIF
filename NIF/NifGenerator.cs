using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIF
{
    public class NifGenerator
    {
        public NifGenerator()
        {

        }

        #region "Helpers"

        private String CalculateLetter(int number)
        {
            String[] letters = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            return letters[number % 23];
        }

        private String GenerateNifNumber()
        {
            String number = "";
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                number += random.Next(0, 9).ToString();
            }

            return number;

        }

        #endregion
    }
}
