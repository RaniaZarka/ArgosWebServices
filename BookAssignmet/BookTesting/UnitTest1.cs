using BookAssignmet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(TitleLenghtException))]
        public void TitleLengthTestException()
        {
            // Arrange
            Book b = new Book();
            string bookTitle = "b";

            // Act
            b.Title = bookTitle;

            //Assert
            Assert.AreEqual(bookTitle, b.Title);
        }
        [TestMethod]
        public void TitlePropertyTest()
        {
            // Arrange
            Book b = new Book();
            string bookTitle = "The prophet";

            // Act
            b.Title = bookTitle;

            //Assert
            Assert.AreEqual(bookTitle, b.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(IsbnLengthException))]
        public void IsbnLengthExceptionTest()
        {
            // Arrange
            Book b = new Book();
            string bookIsbn = "12345678987";

            // Act
            b.Isbn13 = bookIsbn;

            //Assert
            Assert.AreEqual(bookIsbn, b.Isbn13);
        }


        [TestMethod]

        public void IsbnPropertyTest()
        {
            // Arrange
            Book b = new Book();
            string bookIsbn = "1234567890123";

            // Act
            b.Isbn13 = bookIsbn;

            //Assert
            Assert.AreEqual(bookIsbn, b.Isbn13);
        }
        [TestMethod]
        [ExpectedException(typeof(PageNumberException))]

        public void NumberOfPagesTest()
        {
            // Arrange
            Book b = new Book();
            int bookPage = 9;

            // Act
            b.PageNumber = bookPage;

            //Assert
            Assert.AreEqual(bookPage, b.PageNumber);
        }

        [TestMethod]

        public void NumberOfPagesPropertyTest()
        {
            // Arrange
            Book b = new Book();
            int bookPage = 50;

            // Act
            b.PageNumber = bookPage;

            //Assert
            Assert.AreEqual(bookPage, b.PageNumber);
        }

        [TestMethod]

        public void AuthorPropertyTest()
        {
            // Arrange
            Book b = new Book();
            string name = "John";

            // Act
            b.Author = name;

            //Assert
            Assert.AreEqual(name, b.Author);
        }


    }
}
