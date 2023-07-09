using StoneridgeTaskIljaSokolov;

const int rows = 10;
const int columns = 10;

if (args.Length == 0)
{
    Console.WriteLine("Command line argument is invalid");
    return;
}

string path = args[0];
if (!File.Exists(path))
{
    Console.WriteLine("File on this path does not exist");
    return;
}

if (Path.GetExtension(path).ToLower() != ".txt")
{
    Console.WriteLine("Invalid format of text file");
    return;
}

string[] words = File.ReadAllLines(path);
if (words.Length == 0)
{
    Console.WriteLine("No text in file");
    return;
}

bool isTooLong = false;
foreach (string word in words)
{
    if (word.Length > columns)
    {
        isTooLong = true;
        break;
    }
}

if (isTooLong)
{
    Console.WriteLine("Some words in the file are too long to fit in the matrix");
    return;
}

Array.Sort(words, (a, b) => b.Length.CompareTo(a.Length));
char[,] matrix = new char[rows, columns];
int matrixRows = matrix.GetUpperBound(0) + 1;
int matrixColumns = matrix.Length / rows;

for (int i = 0; i < matrixRows; i++)
{
    for (int j = 0; j < matrixColumns; j++)
    {
        matrix[i, j] = '+';
    }
}

foreach (string oneWord in words)
{
    bool isPlacedWord = false;
    for (int i = matrixRows - 1; i >= 0; i--)
    {
        for (int j = 0; j <= matrixColumns - oneWord.Length; j++)
        {
            if (Utils.IsAvailablePlace(matrix, i, j, oneWord.Length))
            {
                Utils.PutWordsToMatrix(matrix, i, j, oneWord);
                isPlacedWord = true;
                break;
            }
        }

        if (isPlacedWord)
        {
            break;
        }
    }
}

Utils.PrintMatrix(matrix);