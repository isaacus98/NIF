using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIF
{
    public class NifGenerator
    {
        private enum TypeNif
        {
            NIF,
            NIE
        }

        public NifGenerator()
        {

        }

        #region "Helpers"

        private String CalculateLetter(int number)
        {
            String[] letters = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            return letters[number % 23];
        }

        private String GenerateNifNumber(TypeNif nif)
        {
            String number = "";
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                if (i == 0 && nif == TypeNif.NIE)
                {
                    number += random.Next(0, 2).ToString();
                }
                else
                {
                    number += random.Next(0, 9).ToString();
                }
                
            }

            return number;

        }

        #endregion

        public String GenerateDNI()
        {
            String dni = GenerateNifNumber(TypeNif.NIF);
            dni += CalculateLetter(Convert.ToInt32(dni));

            return dni;
        }

        public String[] GenerateDNI(int quantity)
        {
            String[] dni = new string[quantity];
            String number;

            for(int i = 0; i < dni.Length; i++)
            {
                number = GenerateNifNumber(TypeNif.NIF);
                dni[i] = number + CalculateLetter(Convert.ToInt32(number));
            }

            return dni;

        }

        public String GenerateNIE()
        {
            String nie = GenerateNifNumber(TypeNif.NIE);
            nie += CalculateLetter(Convert.ToInt32(nie));

            //Change first number to letter X,Y,Z 
            if (nie.Substring(0, 1) == "0")
            {
                nie = nie.Remove(0, 1);
                nie = nie.Insert(0, "X");
            }
            else if (nie.Substring(0, 1) == "1")
            {
                nie = nie.Remove(0, 1);
                nie = nie.Insert(0, "Y");
            }
            else
            {
                nie = nie.Remove(0, 1);
                nie = nie.Insert(0, "Z");
            }

            return nie;
        }

        public String[] GenerateNIE(int quantity)
        {
            String[] nie = new String[quantity];
            String number;

            for (int i = 0; i < nie.Length; i++)
            {
                number = GenerateNifNumber(TypeNif.NIE);
                number += CalculateLetter(Convert.ToInt32(nie));

                //Change first number to letter X,Y,Z 
                if (number.Substring(0, 1) == "0")
                {
                    number = number.Remove(0, 1);
                    number = number.Insert(0, "X");
                }
                else if (number.Substring(0, 1) == "1")
                {
                    number = number.Remove(0, 1);
                    number = number.Insert(0, "Y");
                }
                else
                {
                    number = number.Remove(0, 1);
                    number = number.Insert(0, "Z");
                }

                nie[i] = number;
            }

            return nie;
        }
    }
}
