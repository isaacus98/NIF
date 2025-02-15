using NIF.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace NIF
{
    public class NIFValidator
    {
        public static bool Validate(string nif)
        {
            TypeNif typeNif;
            string letter;
            bool isValid = false;


            if (!string.IsNullOrEmpty(nif))
            {
                if (nif.Length == 9)
                {
                    nif = nif.ToUpper();
                    typeNif = GetTypeNif(nif);

                    switch (typeNif)
                    {
                        //DNI validation
                        case TypeNif.NIF:
                            letter = nif.Substring(8);

                            if (letter == CalculateLetter(int.Parse(nif.Substring(0, 8))))
                                isValid = true;
                            else
                                isValid = false;

                            break;

                        //NIE validation
                        case TypeNif.NIE:
                            letter = nif.Substring(8);

                            if (nif.Substring(0, 1) == "X")
                            {
                                nif = nif.Remove(0, 1);
                                nif = nif.Insert(0, "0");
                            }
                            else if (nif.Substring(0, 1) == "Y")
                            {
                                nif = nif.Remove(0, 1);
                                nif = nif.Insert(0, "1");
                            }
                            else
                            {
                                nif = nif.Remove(0, 1);
                                nif = nif.Insert(0, "2");
                            }

                            if (letter == CalculateLetter(int.Parse(nif.Substring(0, 8))))
                                isValid = true;
                            else
                                isValid = false;

                            break;

                        //CIF validation
                        case TypeNif.CIF:
                            isValid = ValidateCif(nif);
                            break;
                    }
                }
            }

            return isValid;
        }

        #region "Helpers"
        private static TypeNif GetTypeNif(String nif)
        {
            //DNI
            if (Regex.IsMatch(nif, @"[0-9]{8}[A-Z]{1}$"))
                return TypeNif.NIF;

            //NIE
            if (Regex.IsMatch(nif, @"[XYZ]{1}[0-9]{7}[A-Z]{1}$"))
                return TypeNif.NIE;

            //CIF
            if (Regex.IsMatch(nif, @"[ABCDEFGHJNPQRSUVW]{1}[0-9]{7}[0-9A-Z]{1}$"))
                return TypeNif.CIF;

            throw new InvalidNIFException("The NIF is not recognizable");
        }

        private static string CalculateLetter(int number)
        {
            string[] letters = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            return letters[number % 23];
        }

        private static bool ValidateCif(string cif)
        {
            bool isValid = false;
            bool regionCodeIsValid = false;
            string regionCodeCif;
            string letterCif;
            string number;
            string xxx;
            int addition;
            int counter;
            int controlDigit;
            int evenNumber = 0;
            int oddNumber = 0;
            string[] letter = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "N", "P", "Q", "R", "S", "U", "V", "W" };
            string[] regionCode = { "01", "02", "03", "53", "54", "04", "05", "06", "07", "57", "08", "58", "59", "60", "61", "62", "63", "64", "09", "10", "11", "72", "12", "13",
                                    "14", "56", "15", "70", "16", "17", "55", "18", "19", "20", "71", "21", "22", "23", "24", "25", "26", "27", "28", "78", "79", "80", "81", "82",
                                    "83", "84", "29", "92", "93", "30", "73", "31", "32", "33", "74", "34", "35", "76", "36", "94", "37", "38", "75", "39", "40", "41", "91", "42",
                                    "43", "77", "44", "45", "46", "96", "97", "98", "47", "48", "95", "49", "50", "99", "51", "52"};

            //verification of the region code
            regionCodeCif = cif.Substring(1, 2);

            for (int i = 0; i < regionCode.Length; i++)
            {
                if (regionCodeCif == regionCode[i])
                    regionCodeIsValid = true;
            }

            if (!regionCodeIsValid)
                return isValid;

            //Verification control digit
            letterCif = cif.Substring(0, 1);
            number = cif.Substring(8, 1);

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
            {
                if (number == letter[controlDigit - 1])
                    isValid = true;
                else
                    isValid = false;
            }
            else if (letterCif == "A" || letterCif == "B" || letterCif == "E" || letterCif == "H")
            {
                if (number == controlDigit.ToString())
                    isValid = true;
                else
                    isValid = false;
            }
            else
            {
                if (number == letter[controlDigit - 1] || number == controlDigit.ToString())
                    isValid = true;
                else
                    isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
