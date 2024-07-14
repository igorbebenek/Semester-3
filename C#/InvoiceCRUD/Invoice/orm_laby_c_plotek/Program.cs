using orm_laby_c_plotek;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Baza1Context();

            try
            {
                //dodawania faktur
                Console.WriteLine("\n--- Dodawanie i wyświetlanie faktur ---");
                AddInvoice(db, "1", 500);
                PrintAllInvoices(db);

                //aktualizacja faktur
                Console.WriteLine("\n--- Aktualizacja i wyświetlanie faktur ---");
                UpdateInvoice(db, 11, 691);
                PrintAllInvoices(db);

                //dodawanie pozycji faktur 
                Console.WriteLine("\n--- Dodawanie i wyświetlanie pozycji faktur ---");
                AddInvoicePosition(db, 8, "Produkt A", 100);
                PrintAllInvoicePositions(db);

                //aktualizacja faktur
                Console.WriteLine("\n--- Aktualizacja i wyświetlanie pozycji faktur ---");
                UpdateInvoicePosition(db, 10, "Zakt. Produkt A", 123);
                PrintAllInvoicePositions(db);

                //usuwanie
                DeleteInvoice(db, 36);
                PrintAllInvoices(db);
               DeleteInvoicePosition(db, 14);
                PrintAllInvoicePositions(db);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Szczegóły wyjątku wewnętrznego: {ex.InnerException.Message}");
                }
            }
        }


        private static void AddInvoice(Baza1Context db, string number, decimal value)
        {
            Console.WriteLine("Wprowadzamy fakturę");
            db.Add(new Invoice { Number = number, Value = value });
            db.SaveChanges();
        }

        private static void UpdateInvoice(Baza1Context db, int invoiceId, decimal newValue)
        {
            Console.WriteLine($"Aktualizujemy fakturę z ID: {invoiceId}");
            var invoice = db.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                invoice.Value = newValue;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Nie znaleziono faktury do aktualizacji.");
            }
        }

        private static void DeleteInvoice(Baza1Context db, int invoiceId)
        {
            Console.WriteLine($"Usuwamy fakturę z ID: {invoiceId}");
            var invoice = db.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                db.Remove(invoice);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Nie znaleziono faktury do usunięcia.");
            }
        }

        private static void PrintAllInvoices(Baza1Context db)
        {
            Console.WriteLine("Lista wszystkich faktur:");
            var invoices = db.Invoices.ToList();
            foreach (var invoice in invoices)
            {
                Console.WriteLine($"ID: {invoice.InvoiceId}, Numer: {invoice.Number}, Wartość: {invoice.Value}");
            }
        }

        private static void AddInvoicePosition(Baza1Context db, decimal invoiceId, string name, decimal value)
        {
            db.Add(new InvoicePo { InvoiceId = invoiceId, Name = name, Value = value });
            db.SaveChanges();
            Console.WriteLine("Dodano pozycję faktury.");
        }

        private static void UpdateInvoicePosition(Baza1Context db, decimal invoicePosId, string newName, decimal? newValue)
        {
            var invoicePos = db.InvoicePos.FirstOrDefault(ip => ip.InvoicePosId == invoicePosId);
            if (invoicePos != null)
            {
                invoicePos.Name = newName;
                invoicePos.Value = newValue;
                db.SaveChanges();
                Console.WriteLine("Zaktualizowano pozycję faktury.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono pozycji faktury do aktualizacji.");
            }
        }




        private static void DeleteInvoicePosition(Baza1Context db, decimal invoicePosId)
        {
            var invoicePos = db.InvoicePos.FirstOrDefault(ip => ip.InvoicePosId == invoicePosId);
            if (invoicePos != null)
            {
                db.Remove(invoicePos);
                db.SaveChanges();
                Console.WriteLine("Usunięto pozycję faktury.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono pozycji faktury do usunięcia.");
            }
        }

        private static void PrintAllInvoicePositions(Baza1Context db)
        {
            Console.WriteLine("Lista wszystkich pozycji faktur:");
            var invoicePositions = db.InvoicePos.ToList();
            foreach (var pos in invoicePositions)
            {
                Console.WriteLine($"ID: {pos.InvoicePosId}, Faktura ID: {pos.InvoiceId}, Nazwa: {pos.Name}, Wartość: {pos.Value}");
            }
        }
    
    }
}


