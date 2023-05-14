using System;
using System.Collections.Generic;
using System.Net;


namespace SistemTokoBuku
{
    public class SalesHistory
    {
        public List<SaleRecord> salesHistory;
        public Dictionary<int, string> bookDictionary;

        public SalesHistory()
        {
            salesHistory = new List<SaleRecord>();
            bookDictionary = new Dictionary<int, string>
            {
                { 1, "Book A" },
                { 2, "Book B" },
                { 3, "Book C" }
            };
        }

        public void AddSale(int bookId, int quantity, decimal totalPrice)
        {
            // Pre-kondisi: Item penjualan tidak boleh null
            if (!bookDictionary.ContainsKey(bookId))
                throw new ArgumentException("ID Buku tidak valid.");

            SaleRecord saleRecord = new SaleRecord
            {
                SaleDate = DateTime.Now,
                BookId = bookId,
                SoldBook = bookDictionary[bookId],
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
        public int BookId { get; set; }
        public string SoldBook { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}