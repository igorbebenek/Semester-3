using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace daneosobowe
{
    public partial class Form1 : Form
    {
        List<Osoba> osoby = new List<Osoba>();
        public Form1()
        {
            InitializeComponent();


            //  formatowanie DateTimePicker 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.MaxDate = DateTime.Today;
        }
        private void UpdateListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = osoby;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osoba nowaOsoba = new Osoba
            {
                Imi� = textBox1.Text,
                Nazwisko = textBox2.Text,
                DataUrodzenia = dateTimePicker1.Value,
                P�e� = radioButton1.Checked ? "Kobieta" : "M�czyzna"
            };

            osoby.Add(nowaOsoba);
            UpdateListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Osoba wybranaOsoba)
            {
                textBox1.Text = wybranaOsoba.Imi�;
                textBox2.Text = wybranaOsoba.Nazwisko;
                dateTimePicker1.Value = wybranaOsoba.DataUrodzenia;
                radioButton1.Checked = wybranaOsoba.P�e� == "Kobieta";
                radioButton2.Checked = wybranaOsoba.P�e� == "M�czyzna";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Osoba wybranaOsoba)
            {
                osoby.Remove(wybranaOsoba);
                UpdateListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem is Osoba wybranaOsoba)
            {
                // znajdujemy osobe w liscie ktora ma tak samo na imiei nazwisko
                var osobaDoAktualizacji = osoby.FirstOrDefault(o => o.Imi� == wybranaOsoba.Imi� && o.Nazwisko == wybranaOsoba.Nazwisko);

                if (osobaDoAktualizacji != null)
                {
                    // Aktualizuj dane
                    osobaDoAktualizacji.Imi� = textBox1.Text;
                    osobaDoAktualizacji.Nazwisko = textBox2.Text;
                    osobaDoAktualizacji.DataUrodzenia = dateTimePicker1.Value;
                    osobaDoAktualizacji.P�e� = radioButton1.Checked ? "Kobieta" : "M�czyzna";

                    // Od�wie� ListBox
                    UpdateListBox();
                }
            }
        }
    }

    public class Osoba
    {
        public string Imi� { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string P�e� { get; set; }

        //wyswietlanie w listbox
        public override string ToString()
        {
            return $"{Imi�} {Nazwisko} - {DataUrodzenia.ToShortDateString()} - {P�e�}";
        }
    }
}
