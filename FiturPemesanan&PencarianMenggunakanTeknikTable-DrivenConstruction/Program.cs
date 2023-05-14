using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiturPemesanan_PencarianMenggunakanTeknikTable_DrivenConstruction;

namespace FiturPemesanan_PencarianMenggunakanTeknikTable_DrivenConstruction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selamat datang di Toko Buku ABC");
            Console.WriteLine("Silakan pilih menu:");
            Console.WriteLine("1. Pencarian Buku");
            Console.WriteLine("2. Pemesanan Buku");
            Console.WriteLine("3. Laporan Penjualan");
            Console.Write("Masukkan nomor menu: ");

            int menu;
            while (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 3)
            {
                Console.Write("Masukkan nomor menu yang benar (1-3): ");
            }

            switch (menu)
            {
                case 1:
                    SearchBook();
                    break;
                case 2:
                    OrderBook();
                    break;
                case 3:
                    SalesReport();
                    break;
            }

            Console.WriteLine("Terima kasih telah menggunakan layanan Toko Buku ABC");
            Console.ReadLine();
        }

        static void SearchBook()
        {
            Console.WriteLine("Pencarian Buku");
            Console.WriteLine("Silakan masukkan kata kunci pencarian: ");
            string keyword = Console.ReadLine();

            List<Book> books = GetBooks();

            Console.WriteLine("Hasil pencarian:");
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10}", "ID", "Judul Buku", "Penulis", "Harga");
            Console.WriteLine(new string('-', 55));

            bool found = false;
            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(keyword.ToLower()) ||
                    book.Author.ToLower().Contains(keyword.ToLower()))
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10}", book.Id, book.Title, book.Author, book.Price);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }

            Console.ReadLine();
        }

        static void OrderBook()
        {
            Console.WriteLine("Pemesanan Buku");
            Console.WriteLine("Silakan masukkan ID buku yang ingin dipesan: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId) || bookId <= 0)
            {
                Console.Write("Masukkan ID buku yang benar: ");
            }

            List<Book> books = GetBooks();

            Book selectedBook = null;
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    selectedBook = book;
                    break;
                }
            }

            if (selectedBook == null)
            {
                Console.WriteLine("Buku dengan ID tersebut tidak ditemukan.");
            }
            else
            {
                Console.WriteLine("Anda memilih buku: {0} - {1} karya {2}", selectedBook.Id, selectedBook.Title, selectedBook.Author);
                Console.WriteLine("Harga: {0}", selectedBook.Price);
                Console.WriteLine("Silakan masukkan jumlah yang ingin dipesan: ");

                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.Write("Masukkan jumlah yang benar: ");
                }

                double totalPrice = selectedBook.Price;
            }
        }
    }
}
