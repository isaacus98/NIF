using NIF.Exceptions;
using System.Text.RegularExpressions;

namespace NIF
{
    public class NifValidator
    {
        public NifValidator() { }

        #region "Helpers"

        private String CalculateLetter(int number)
        {
            String[] letters = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            return letters[number % 23];
        }

        private bool ValidateCif(string cif)
        {
            bool isValid;
            string number;
            string xxx;
            int addition;
            int counter;
            int controlDigit;
            int evenNumber = 0;
            int oddNumber = 0;
            string[] letter = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "N", "P", "Q", "R", "S", "U", "V", "W" };

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


            if ((number == controlDigit.ToString()) || (number == letter[controlDigit - 1]))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
        private TypeNif GetTypeNif(String nif)
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

            throw new InvalidNifException("The nif is not recognizable");
        }

        #endregion

        public bool Validate(String nif)
        {
            TypeNif typeNif;
            String letter;
            bool isValid = false;

            if (!String.IsNullOrEmpty(nif))
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

                            if (letter == CalculateLetter(int.Parse(nif[..8])))
                            {
                                isValid = true;
                            }
                            else
                            {
                                isValid = false;
                            }

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

                            if (letter == CalculateLetter(int.Parse(nif[..8])))
                            {
                                isValid = true;
                            }
                            else
                            {
                                isValid = false;
                            }
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
    }
}