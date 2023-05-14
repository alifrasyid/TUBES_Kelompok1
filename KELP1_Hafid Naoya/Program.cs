using System;

class Program
{
    // enum untuk state state machine
    enum BookState
    {
        Title,
        Author,
        Year,
        Confirmation,
        Finish
    }

    static void Main(string[] args)
    {
        // inisialisasi objek buku baru
        Book newBook = new Book();

        // inisialisasi state awal state machine
        BookState state = BookState.Title;

        // state machine untuk mengatur input data buku
        while (state != BookState.Finish)
        {
            switch (state)
            {
                case BookState.Title:
                    Console.Write("Masukkan judul buku: ");
                    newBook.Title = Console.ReadLine();
                    state = BookState.Author;
                    break;

                case BookState.Author:
                    Console.Write("Masukkan nama pengarang buku: ");
                    newBook.Author = Console.ReadLine();
                    state = BookState.Year;
                    break;

                case BookState.Year:
                    Console.Write("Masukkan tahun terbit buku: ");
                    int year = 0;
                    if (int.TryParse(Console.ReadLine(), out year))
                    {
                        newBook.Year = year;
                        state = BookState.Confirmation;
                    }
                    else
                    {
                        Console.WriteLine("Input tahun terbit buku tidak valid!");
                    }
                    break;

                case BookState.Confirmation:
                    Console.WriteLine("Apakah data buku sudah benar? (y/n)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToLower() == "y")
                    {
                        state = BookState.Finish;
                    }
                    else if (confirmation.ToLower() == "n")
                    {
                        state = BookState.Title;
                    }
                    else
                    {
                        Console.WriteLine("Input tidak valid!");
                    }
                    break;
            }
        }

        // menambahkan buku baru ke dalam sistem
        Console.WriteLine("Buku baru berhasil ditambahkan ke dalam sistem:");
        Console.WriteLine("Judul: " + newBook.Title);
        Console.WriteLine("Pengarang: " + newBook.Author);
        Console.WriteLine("Tahun terbit: " + newBook.Year);
        Console.ReadLine();
    }
}

// class untuk menyimpan data buku
class Book
{
    public string Title;
    public string Author;
    public int Year;
}
