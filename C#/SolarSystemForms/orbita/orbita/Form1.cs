namespace orbita
{
    public partial class Form1 : Form
    {
        private int centerX = 300;
        private int centerY = 200;
        private int radius1 = 100;
        private int radius2 = 200;
        private double angle1 = 0;
        private double angle2 = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox2.Location = new Point(centerX - pictureBox2.Width / 2, centerY - pictureBox2.Height / 2); //slonce na srodku orbity

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen orbitPen = new Pen(Color.Gray, 1);

            //wspolrzedne srodka slonca i orbit
            int centerX = 300;
            int centerY = 200;
            //promienie
            int radius1 = 100;
            int radius2 = 200;

            // mniejsza orbita
            g.DrawEllipse(orbitPen, centerX - radius1, centerY - radius1, 2 * radius1, 2 * radius1);

            // wieksza
            g.DrawEllipse(orbitPen, centerX - radius2, centerY - radius2, 2 * radius2, 2 * radius2);

            orbitPen.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle1 += 0.01; // zwiekszanie kata dla pierwszej planety
            angle2 += 0.005; // drugiej

            int planet1X = centerX + (int)(radius1 * Math.Cos(angle1));
            int planet1Y = centerY + (int)(radius1 * Math.Sin(angle1));

            int planet2X = centerX + (int)(radius2 * Math.Cos(angle2));
            int planet2Y = centerY + (int)(radius2 * Math.Sin(angle2));

            // polozenie planet
            pictureBox3.Location = new Point(planet1X - pictureBox3.Width / 2, planet1Y - pictureBox3.Height / 2);
            pictureBox1.Location = new Point(planet2X - pictureBox1.Width / 2, planet2Y - pictureBox1.Height / 2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}