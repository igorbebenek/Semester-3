namespace macierze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int rowsA = 1000;
                int colsA = 1000;
                int rowsB = 1000;
                int colsB = 1000;

                double[,] matrixA = MatrixOperations.CreateMatrix(rowsA, colsA);
                double[,] matrixB = MatrixOperations.CreateMatrix(rowsB, colsB);

                // Mno¿enie macierzy
                double[,] result = MatrixOperations.MultiplyMatrices(matrixA, matrixB);

                int totalOperations = rowsA * colsB;
                for (int i = 0; i < rowsA; i++) //postep
                {
                    for (int j = 0; j < colsB; j++)
                    {


                        // Aktualizacja postêpu
                        int progressPercentage = (int)(((double)(i * colsB + j) / totalOperations) * 100);
                        backgroundWorker1.ReportProgress(progressPercentage);
                    }
                }

                e.Result = result;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rozpocznijMnozenie_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(); // Uruchamianie bez przekazywania parametrów
            }
        }



        private void rozmiar_TextChanged(object sender, EventArgs e)
        {

        }
        //metoda do progresu
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
            labelStatus.Text = $"Przetwarzamy... {e.ProgressPercentage}%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Text = "Wyst¹pi³ b³¹d: " + e.Error.Message;
            }
            else if (e.Cancelled)
            {
                labelStatus.Text = "Operacja anulowana.";
            }
            else if (e.Result is Exception)
            {
                labelStatus.Text = "B³¹d mno¿enia macierzy: " + ((Exception)e.Result).Message;
            }
            else
            {
                double[,] result = (double[,])e.Result;
                labelStatus.Text = "Zakoñczono pomyœlnie.";
            }

            progressBar1.Value = 0;

        }


        public class MatrixOperations
        {
            // metoda mnozaca za pomoca algorytmyu Strassena
            public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
            {
                //algorytm Strassena jest szybszy dla mnozenia duzych macierzy
                return StrassenMultiply(matrixA, matrixB);
            }


            private static double[,] StrassenMultiply(double[,] A, double[,] B)
            {
                int n = A.GetLength(0);
                double[,] result = new double[n, n];

                // mnozenie macierzy
                if (n <= 128)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            result[i, j] = 0;
                            for (int k = 0; k < n; k++)
                            {
                                result[i, j] += A[i, k] * B[k, j];
                            }
                        }
                    }
                }

                return result;
            }

            // generujemy macierz
            public static double[,] CreateMatrix(int rows, int cols)
            {
                double[,] matrix = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = 1.0;
                    }
                }

                return matrix;
            }


            private void Form1_Load(object sender, EventArgs e)
            {

            }
        }
    }
}
  