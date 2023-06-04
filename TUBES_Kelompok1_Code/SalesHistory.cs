using System;
using System.Collections.Generic;
using System.Net;


namespace SistemTokoBuku
{
    public enum BookType
    {
        BookA = 1,
        BookB = 2,
        BookC = 3
    }

    public class SalesHistory
    {
        public List<SaleRecord> salesHistory;
        public Dictionary<BookType, string> bookDictionary;

        public SalesHistory()
        {
            salesHistory = new List<SaleRecord>();
            bookDictionary = new Dictionary<BookType, string>
            {
                { BookType.BookA, "Book A" },
                { BookType.BookB, "Book B" },
                { BookType.BookC, "Book C" }
            };
        }

        public void AddSale(BookType bookType, int quantity, decimal totalPrice)
        {
            // Pre-kondisi: Item penjualan tidak boleh null
            if (!bookDictionary.ContainsKey(bookType))
                throw new ArgumentException("ID Buku tidak valid.");

            SaleRecord saleRecord = new SaleRecord
            {
                SaleDate = DateTime.Now,
                BookType = bookType,
                SoldBook = bookDictionary[bookType],
                Quantity = quantity,
                TotalPrice = totalPrice
            };

            // Menambahkan item penjualan ke dalam riwayat
            salesHistory.Add(saleRecord);

            // Post-kondisi: Item penjualan harus berhasil ditambahkan ke dalam riwayat
            // Verifikasi post-kondisi
            if (!salesHistory.Contains(saleRecord))
                throw new Exception("Gagal menambahkan item penjualan ke dalam riwayat.");
        }

        public void DisplaySalesHistory()
        {
            Console.WriteLine("Sales History:");
            foreach (var saleRecord in salesHistory)
            {
                Console.WriteLine($"Sale Date: {saleRecord.SaleDate}, Book: {saleRecord.SoldBook}, " +
                    $"Quantity: {saleRecord.Quantity}, Total Price: {saleRecord.TotalPrice}");
            }
        }
    }

    public class SaleRecord
    {
        public DateTime SaleDate { get; set; }
        public BookType BookType { get; set; }
        public string SoldBook { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}