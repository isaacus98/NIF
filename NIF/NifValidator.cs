namespace NIF
{
    public class NifValidator
    {
        private enum TypeNif
        {
            NIF,
            NIE,
            CIF
        }

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

        #endregion
    }
}