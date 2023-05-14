using System;
using Bookstore

namespace BookstoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookId = 123; // ID buku yang akan dihapus
            var bookstore = new Bookstore();
            var isSuccess = bookstore.DeleteBook(bookId); // Panggil method untuk menghapus buku
            if (isSuccess)
            {
                Console.WriteLine($"Buku dengan ID {bookId} berhasil dihapus dari sistem.");
            }
            else
            {
                Console.WriteLine($"Gagal menghapus buku dengan ID {bookId}.");
            }
        }
    }
}