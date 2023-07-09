using NUnit.Framework;

namespace StoneridgeTaskIljaSokolov.Tests
{
    [TestFixture]
    public class UtilsTests
    {
        [Test]
        public void IsAvailablePlace_ReturnsTrue_WhenPlaceIsAvailable()
        {
            char[,] matrix = new char[2, 5]
            {
                { '+', '+', '+', '+', '+' },
                { '+', '+', '+', '+', '+' }
            };
            int row = 0;
            int column = 1;
            int length = 3;

            bool result = Utils.IsAvailablePlace(matrix, row, column, length);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsAvailablePlace_ReturnsFalse_WhenPlaceIsNotAvailable()
        {

            char[,] matrix = new char[2, 5]
            {
                { '+', '+', '+', '+', '+' },
                { '+', '+', '+', '+', '+' }
            };
            matrix[0, 2] = 'A';
            int row = 0;
            int column = 1;
            int length = 3;

            bool result = Utils.IsAvailablePlace(matrix, row, column, length);

            Assert.IsFalse(result);
        }

        [Test]
        public void PutWordsToMatrix_PlacesWordCorrectly()
        {
            char[,] matrix = new char[2, 5]
            {
                { '+', '+', '+', '+', '+' },
                { '+', '+', '+', '+', '+' }
            };
            int row = 0;
            int column = 1;
            string word = "ABC";

            Utils.PutWordsToMatrix(matrix, row, column, word);

            Assert.AreEqual('A', matrix[row, column]);
            Assert.AreEqual('B', matrix[row, column + 1]);
            Assert.AreEqual('C', matrix[row, column + 2]);
        }
    }
}