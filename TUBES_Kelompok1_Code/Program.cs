using SistemTokoBuku;
using System;


public class Program
{
    static void Main(string[] args)
    {
        // Memuat konfigurasi saat runtime
        bool enableOrderHistory = GetConfigurationValue("EnableOrderHistory");

        if (enableOrderHistory)
        {
            // Membuat instance OrderHistory
            OrderHistory orderHistory = new OrderHistory();

            // Simulasi menambahkan pesanan
            orderHistory.AddOrder("Book A");
            orderHistory.AddOrder("Book B");
            orderHistory.AddOrder("Book C");

            // Menampilkan riwayat pemesanan
            orderHistory.DisplayOrderHistory();
        }
        else
        {
            Console.WriteLine("Fitur riwayat pemesanan dinonaktifkan");
        }

        Console.WriteLine();

        // Membuat instance SalesHistory
        SalesHistory salesHistory = new SalesHistory();

        // Simulasi menambahkan penjualan
        salesHistory.AddSale(BookType.BookA, 2, 50);
        salesHistory.AddSale(BookType.BookB, 1, 20);

        // Menampilkan riwayat penjualan
        salesHistory.DisplaySalesHistory();
    }

    // Metode simulasi konfigurasi saat runtime
    private static bool GetConfigurationValue(string key)
    {
        // Pada aplikasi nyata, nilai konfigurasi akan diambil dari berkas konfigurasi atau database
        // Untuk tujuan kesederhanaan, nilai hard-coded digunakan di sini
        if (key == "EnableOrderHistory")
            return true;
        else
            return false;
    }
}
