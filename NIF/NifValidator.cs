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

        #endregion
    }
}