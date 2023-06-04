using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemTokoBuku;
using System;

namespace SistemTokoBuku.Tests
{
    [TestClass]
    public class OrderHistoryTests
    {
        [TestMethod]
        public void AddOrder_ValidBook_SuccessfullyAddedToHistory()
        {
            // Arrange
            OrderHistory orderHistory = new OrderHistory();
            string book = "Book A";

            // Act
            orderHistory.AddOrder(book);

            // Assert
            CollectionAssert.Contains(orderHistory.orderHistory, book);
        }

        [TestMethod]
        public void AddOrder_NullBook_ThrowsArgumentException()
        {
            // Arrange
            OrderHistory orderHistory = new OrderHistory();
            string book = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => orderHistory.AddOrder(book));
        }
    }

    [TestClass]
    public class SalesHistoryTests
    {
        [TestMethod]
        public void AddSale_ValidSale_SuccessfullyAdded()
        {
            // Arrange
            SalesHistory salesHistory = new SalesHistory();

            // Act
            salesHistory.AddSale(BookType.BookA, 2, 50);

            // Assert
            SaleRecord expectedSaleRecord = new SaleRecord
            {
                SaleDate = salesHistory.salesHistory[0].SaleDate,
                BookType = BookType.BookA,
                SoldBook = "Book A",
                Quantity = 2,
                TotalPrice = 50
            };
            SaleRecord actualSaleRecord = salesHistory.salesHistory[0];
            Assert.AreEqual(expectedSaleRecord.SaleDate, actualSaleRecord.SaleDate);
            Assert.AreEqual(expectedSaleRecord.BookType, actualSaleRecord.BookType);
            Assert.AreEqual(expectedSaleRecord.SoldBook, actualSaleRecord.SoldBook);
            Assert.AreEqual(expectedSaleRecord.Quantity, actualSaleRecord.Quantity);
            Assert.AreEqual(expectedSaleRecord.TotalPrice, actualSaleRecord.TotalPrice);
        }

        [TestMethod]
        public void AddSale_InvalidBookId_ThrowsException()
        {
            // Arrange
            SalesHistory salesHistory = new SalesHistory();

            // Assert
            Assert.ThrowsException<ArgumentException>(() => salesHistory.AddSale((BookType)4, 1, 20));
        }
    }

}
