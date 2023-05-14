using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiturpembayaranteknikcodereuse
{
    internal class Program
    {
        public interface PaymentMethod
        {
            void processPayment(double amount);
        }

        public class CashPayment : PaymentMethod
        {
            public void processPayment(double amount)
            {
                Console.WriteLine("Pembayaran tunai sebesar " + amount + " diterima.");
            }
        }

        public class CreditCardPayment : PaymentMethod
        {
            private string cardNumber;
            private string expirationDate;
            private string cvvCode;

            public CreditCardPayment(string cardNumber, string expirationDate, string cvvCode)
            {
                this.cardNumber = cardNumber;
                this.expirationDate = expirationDate;
                this.cvvCode = cvvCode;
            }

            public void processPayment(double amount)
            {
                Console.WriteLine("Pembayaran dengan kartu kredit sebesar " + amount + " akan diproses.");
                Console.WriteLine("Nomor kartu kredit: " + cardNumber);
                Console.WriteLine("Tanggal kadaluarsa: " + expirationDate);
                Console.WriteLine("CVV code: " + cvvCode);
            }
        }

        public class BookStore
        {
            private PaymentMethod paymentMethod;

            public BookStore(PaymentMethod paymentMethod)
            {
                this.paymentMethod = paymentMethod;
            }

            public void checkout(double amount)
            {
                paymentMethod.processPayment(amount);
            }
        }

        public static void Main(string[] args)
        {
            PaymentMethod cashPayment = new CashPayment();
            PaymentMethod creditCardPayment = new CreditCardPayment("1234567890123456", "12/25", "123");

            BookStore bookStore = new BookStore(cashPayment);
            bookStore.checkout(100.00);

            bookStore = new BookStore(creditCardPayment);
            bookStore.checkout(200.00);
        }
    }
}
