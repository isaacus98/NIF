﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIF
{
    public static class NifGenerator
    {
        private static string[] Letter = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "N", "P", "Q", "R", "S", "U", "V", "W" };
        private static string[] RegionCode = new string[] { "01", "02", "03", "53", "54", "04", "05", "06", "07", "57", "08", "58", "59", "60", "61", "62", "63", "64", "09", "10", "11", "72", "12", "13",
                                                "14", "56", "15", "70", "16", "17", "55", "18", "19", "20", "71", "21", "22", "23", "24", "25", "26", "27", "28", "78", "79", "80", "81", "82",
                                                "83", "84", "29", "92", "93", "30", "73", "31", "32", "33", "74", "34", "35", "76", "36", "94", "37", "38", "75", "39", "40", "41", "91", "42",
                                                "43", "77", "44", "45", "46", "96", "97", "98", "47", "48", "95", "49", "50", "99", "51", "52"};

        #region "Helpers"

        private static String CalculateLetter(int number)
        {
            String[] letters = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            return letters[number % 23];
        }

        private static String GenerateNifNumber(TypeNif nif)
        {
            String number = "";
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                if (i == 0 && nif == TypeNif.NIE)
                    number += random.Next(0, 3).ToString();
                else
                    number += random.Next(0, 10).ToString();
            }

            return number;
        }

        private static String CalculateControlDigit(String cif)
        {
            string letterCif;
            string xxx;
            int addition;
            int counter;
            int controlDigit;
            int evenNumber = 0;
            int oddNumber = 0;
            string[] letter = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "N", "P", "Q", "R", "S", "U", "V", "W" };

            letterCif = cif.Substring(0, 1);

            for (counter = 1; counter < 7; counter++)
            {
                xxx = (2 * int.Parse(cif.Substring(counter++, 1))) + "0";
                oddNumber += int.Parse(xxx.ToString().Substring(0, 1)) + int.Parse(xxx.ToString().Substring(1, 1));
                evenNumber += int.Parse(cif.Substring(counter, 1));
            }

            xxx = (2 * int.Parse(cif.Substring(counter, 1))) + "0";
            oddNumber += int.Parse(xxx.Substring(0, 1)) + int.Parse(xxx.Substring(1, 1));

            addition = evenNumber + oddNumber;

            controlDigit = int.Parse(addition.ToString().Substring(addition.ToString().Length - 1, 1));
            controlDigit = 10 - controlDigit;

            if (controlDigit == 10)
                controlDigit = 0;

            if (letterCif == "P" || letterCif == "Q" || letterCif == "R" || letterCif == "S" || letterCif == "W" || letterCif == "N")
                return letter[controlDigit - 1];
            else
                return controlDigit.ToString();
        }

        #endregion

        /// <summary>
        ///     Generates a random DNI
        /// </summary>
        /// <returns>A string containing the DNI</returns>
        public static String GenerateDNI()
        {
            String dni = GenerateNifNumber(TypeNif.NIF);
            dni += CalculateLetter(Convert.ToInt32(dni));

            return dni;
        }

        /// <summary>
        ///     Generates an array of strings that are randomly generated DNI
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>An array of strings that continues random DNI</returns>
        public static String[] GenerateDNI(int quantity)
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

        /// <summary>
        ///     Generates a random NIE
        /// </summary>
        /// <returns>A string containing the NIE</returns>
        public static String GenerateNIE()
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

        /// <summary>
        ///     Generates an array of strings that are randomly generated NIE
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>An array of strings that continues random NIE</returns>
        public static String[] GenerateNIE(int quantity)
        {
            String[] nie = new String[quantity];
            String number;

            for (int i = 0; i < nie.Length; i++)
            {
                number = GenerateNifNumber(TypeNif.NIE);
                number += CalculateLetter(Convert.ToInt32(number));

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

        /// <summary>
        ///     Generates a random CIF
        /// </summary>
        /// <returns>A string containing the CIF</returns>
        public static String GenerateCIF()
        {
            Random random = new Random();
            string cif = "";

            //Get Random letter
            cif += Letter[random.Next(0, Letter.Length)];
            //Get random region code
            cif += RegionCode[random.Next(0, RegionCode.Length)];

            //Generate 5 random numbers from 0 to 9
            for (int i = 0; i < 5; i++)
                cif += random.Next(0, 10).ToString();

            //Get control digit
            cif += CalculateControlDigit(cif);

            return cif;
        }

        /// <summary>
        ///     Generates an array of strings that are randomly generated CIF
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>An array of strings that continues random NIE</returns>
        public static String[] GenerateCIF(int quantity)
        {
            Random random = new Random();
            String[] cif = new String[quantity];
            string number = "";

            for (int i = 0; i < quantity; i++)
            {
                //Get Random letter
                number += Letter[random.Next(0, Letter.Length)];
                //Get random region code
                number += RegionCode[random.Next(0, RegionCode.Length)];

                //Generate 5 random numbers from 0 to 9
                for (int j = 0; j < 5; i++)
                    number += random.Next(0, 10).ToString();

                //Get control digit
                number += CalculateControlDigit(number);

                cif[i] = number;
            }

            return cif;
        }
    }
}
