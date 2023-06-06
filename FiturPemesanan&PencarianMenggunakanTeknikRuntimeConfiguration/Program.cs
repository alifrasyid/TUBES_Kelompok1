using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FiturPemesanan_PencarianMenggunakanTeknikRuntimeConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Implementasi Teknik Konfigurasi Runtime
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var setting = configuration.AppSettings.Settings["DatabaseConnectionString"];

            if (setting != null)
            {
                // Melakukan koneksi ke database dengan connection string yang telah saya simpan di konfigurasi runtime
                Console.WriteLine("Menggunakan Connection String: {0}", setting.Value);
            }
            else
            {
                Console.WriteLine("Connection String tidak ditemukan.");
            }

            // Implementasi pada fitur pencarian buku
            Console.WriteLine("Masukkan judul buku yang akan dicari:");
            string judulBuku = Console.ReadLine();

            // Melakukan pencarian buku pada database dengan menggunakan judul buku yang dimasukkan dan menampilan hasil pencarian
            Console.WriteLine("Hasil Pencarian:");
            Console.WriteLine(" - Buku 1");
            Console.WriteLine(" - Buku 2");
            Console.WriteLine(" - Buku 3");

            // Meminta pengguna untuk memilih buku yang akan dipesan
            Console.WriteLine("Masukkan nomor buku yang akan dipesan:");
            int nomorBuku = int.Parse(Console.ReadLine());

            // Meminta pengguna untuk memasukkan jumlah buku yang akan dipesan
            Console.WriteLine("Masukkan jumlah buku yang akan dipesan:");
            int jumlahBuku = int.Parse(Console.ReadLine());

            // Menampilkan rincian pesanan dan total harga pemesanan pengguna
            Console.WriteLine("Rincian Pesanan:");
            Console.WriteLine(" - Judul Buku: Buku {0}", nomorBuku);
            Console.WriteLine(" - Jumlah Buku: {0}", jumlahBuku);
            Console.WriteLine(" - Harga Total: {0}", jumlahBuku * 100000);

            // Meminta pengguna untuk melakukan konfirmasi pada pemesanan
            Console.WriteLine("Apakah Anda yakin ingin memesan buku ini? (Y/N)");
            string konfirmasi = Console.ReadLine();

            if (konfirmasi.ToUpper() == "Y")
            {
                // Melakukan proses pemesanan dan pencatatan riwayat pemesanan ke dalam database
                Console.WriteLine("Pesanan Anda berhasil dicatat.");
            }
            else
            {
                Console.WriteLine("Pesanan Anda dibatalkan.");
            }

            Console.ReadLine();
        }
    }
}
