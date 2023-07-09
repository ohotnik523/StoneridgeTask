namespace StoneridgeTaskIljaSokolov
{
    public class Utils
    {
        public static void PrintMatrix(char[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsAvailablePlace(char[,] matrix, int rows, int columns, int length)
        {
            for (int i = columns; i < columns + length; i++)
            {
                if (matrix[rows, i] != '+')
                {
                    return false;
                }
            }
            return true;
        }
        public static void PutWordsToMatrix(char[,] matrix, int rows, int columns, string word)
        {
            for (int j = columns; j < columns + word.Length; j++)
            {
                matrix[rows, j] = word[j - columns];
            }
        }
    }
}
