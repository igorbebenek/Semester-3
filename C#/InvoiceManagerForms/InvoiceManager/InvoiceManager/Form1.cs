using InvoiceManager.Models;

namespace InvoiceManager
{
    public partial class Form1 : Form
    {
        private decimal? selectedInvoiceId = null;

        private decimal? selectedInvoicePosId = null;
        public Form1()
        {
            InitializeComponent();
            Invoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Invoice.CellClick += Invoice_CellClick;
            InvoicePos.CellClick += InvoicePos_CellClick;

        }

        private void DodajFakture_Click(object sender, EventArgs e)
        {
            using var db = new Baza1Context();
            var number = NumerFaktury.Text;

            if (!decimal.TryParse(WartoscFaktury.Text, out var invoiceValue))
            {
                MessageBox.Show("WprowadŸ prawid³ow¹ wartoœæ faktury.");
                return;
            }

            var newInvoice = new Invoice { Number = number, Value = invoiceValue };
            db.Add(newInvoice);
            db.SaveChanges();
            RefreshInvoicesGrid();
        }

        private void UsunFakture_Click(object sender, EventArgs e)
        {
            if (!selectedInvoiceId.HasValue)
            {
                MessageBox.Show("Proszê wybraæ fakturê do usuniêcia.");
                return;
            }

            using var db = new Baza1Context();
            var invoiceToDelete = db.Invoices.FirstOrDefault(i => i.InvoiceId == selectedInvoiceId.Value);

            if (invoiceToDelete != null)
            {
                db.Invoices.Remove(invoiceToDelete);
                db.SaveChanges();
                RefreshInvoicesGrid();

                selectedInvoiceId = null;
            }
            else
            {
                MessageBox.Show("Faktura nie zosta³a znaleziona.");
            }
        }

        private void DodajPozycje_Click(object sender, EventArgs e)
        {
            if (!selectedInvoiceId.HasValue)
            {
                MessageBox.Show("Proszê wybraæ fakturê.");
                return;
            }

            var name = NazwaPozycji.Text;
            if (!decimal.TryParse(WartoscPozycji.Text, out var value))
            {
                MessageBox.Show("WprowadŸ prawid³ow¹ wartoœæ.");
                return;
            }

            using var db = new Baza1Context();
            var newPosition = new InvoicePo { InvoiceId = selectedInvoiceId.Value, Name = name, Value = value };
            db.Add(newPosition);
            db.SaveChanges();
            RefreshInvoicePositionsGrid(selectedInvoiceId.Value);
        }


        private void AktualizujPozycje_Click(object sender, EventArgs e)
        {
            if (!selectedInvoicePosId.HasValue)
            {
                MessageBox.Show("Proszê wybraæ pozycjê faktury do aktualizacji.");
                return;
            }

            using var db = new Baza1Context();
            var positionToUpdate = db.InvoicePos.FirstOrDefault(ip => ip.InvoicePosId == selectedInvoicePosId.Value);
            if (positionToUpdate == null)
            {
                MessageBox.Show("Pozycja faktury nie zosta³a znaleziona.");
                return;
            }

            positionToUpdate.Name = NazwaPozycji.Text;
            if (!decimal.TryParse(WartoscPozycji.Text, out var newValue))
            {
                MessageBox.Show("WprowadŸ prawid³ow¹ wartoœæ.");
                return;
            }
            positionToUpdate.Value = newValue;

            db.SaveChanges();
            RefreshInvoicePositionsGrid(positionToUpdate.InvoiceId);
        }


        private void AktualizujFakture_Click(object sender, EventArgs e)
        {
            using var db = new Baza1Context();

            var selectedRow = Invoice.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Proszê wybraæ fakturê do aktualizacji.");
                return;
            }

            var invoiceId = (decimal)selectedRow.Cells["InvoiceId"].Value;

            var invoiceToUpdate = db.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoiceToUpdate == null)
            {
                MessageBox.Show("Faktura nie zosta³a znaleziona.");
                return;
            }

            invoiceToUpdate.Number = NumerFaktury.Text;

            if (decimal.TryParse(WartoscFaktury.Text, out var newInvoiceValue))
            {
                invoiceToUpdate.Value = newInvoiceValue;
            }
            else
            {
                MessageBox.Show("WprowadŸ prawid³ow¹ wartoœæ faktury.");
                return;
            }

            db.SaveChanges();

            RefreshInvoicesGrid();
        }


        private void UsunPozycje_Click(object sender, EventArgs e)
        {
            if (!selectedInvoicePosId.HasValue)
            {
                MessageBox.Show("Proszê wybraæ pozycjê faktury do usuniêcia.");
                return;
            }

            using var db = new Baza1Context();
            var positionToDelete = db.InvoicePos.FirstOrDefault(ip => ip.InvoicePosId == selectedInvoicePosId.Value);
            if (positionToDelete == null)
            {
                MessageBox.Show("Pozycja faktury nie zosta³a znaleziona.");
                return;
            }

            db.InvoicePos.Remove(positionToDelete);
            db.SaveChanges();
            RefreshInvoicePositionsGrid(positionToDelete.InvoiceId);
        }


        private void InvoicePos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NazwaPozycji_TextChanged(object sender, EventArgs e)
        {

        }

        private void WartoscPozycji_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshInvoicesGrid();


        }

        private void LabelNazwaPozycji_Click(object sender, EventArgs e)
        {

        }

        private void LabelWartoscPozycji_Click(object sender, EventArgs e)
        {

        }

        private void RefreshInvoicesGrid()
        {
            using var db = new Baza1Context();
            var invoiceList = db.Invoices
                                .Select(i => new
                                {
                                    InvoiceId = i.InvoiceId,
                                    Number = i.Number,
                                    Value = i.Value
                                })
                                .ToList();
            Invoice.DataSource = invoiceList;

        }


        private void RefreshInvoicePositionsGrid(decimal invoiceId)
        {
            using var db = new Baza1Context();
            var positionsList = db.InvoicePos
                                  .Where(ip => ip.InvoiceId == invoiceId)
                                  .Select(ip => new
                                  {
                                      InvoicePosId = ip.InvoicePosId,
                                      Name = ip.Name,
                                      Value = ip.Value
                                  })
                                  .ToList();
            InvoicePos.DataSource = positionsList;
        }



        private void WartoscFaktury_TextChanged(object sender, EventArgs e)
        {

        }


        private void Invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = Invoice.Rows[e.RowIndex];
                selectedInvoiceId = (decimal)row.Cells["InvoiceId"].Value;
                RefreshInvoicePositionsGrid(selectedInvoiceId.Value);
            }
        }


        private void InvoicePos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = InvoicePos.Rows[e.RowIndex];
                selectedInvoicePosId = (decimal)row.Cells["InvoicePosId"].Value;
            }
        }

        private void Invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
