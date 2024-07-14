namespace czaspoprawiony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Czas_Click(object sender, EventArgs e)
        {

        }

        private void Data_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Czas.Text=DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Czas.Text=DateTime.Now.ToLongTimeString();
            Data.Text=DateTime.Now.ToLongDateString();
        }
    }
}