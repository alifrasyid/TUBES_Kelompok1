using System;
using System.Collections.Generic;


namespace SistemTokoBuku
{
    public class OrderHistory
    {
        public List<string> orderHistory;

        public OrderHistory()
        {
            orderHistory = new List<string>();
        }

        public void AddOrder(string book)
        {
            // Pre-kondisi: ID Pemesanan tidak boleh null atau kosong
            if (string.IsNullOrEmpty(book))
                throw new ArgumentException("ID Pemesanan tidak valid.");

            // Menambahkan pemesanan ke dalam riwayat
            orderHistory.Add(book);

            // Post-kondisi: Pemesanan harus berhasil ditambahkan ke dalam riwayat
            // Verifikasi post-kondisi
            if (!orderHistory.Contains(book))
                throw new Exception("Gagal menambahkan pemesanan ke dalam riwayat.");
        }

        public void DisplayOrderHistory()
        {
            Console.WriteLine("Order History:");
            foreach (var book in orderHistory)
            {
                Console.WriteLine(book);
            }
        }
    }
}
