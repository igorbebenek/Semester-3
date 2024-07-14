namespace SnakeGra
{
    public partial class Form1 : Form
    {
        private List<Point> snakeSegments;
        private int segmentSize = 20; 
        private int currentLength;
        private Direction currentDirection;
        private System.Windows.Forms.Timer gameTimer;
        private bool gameRunning;
        private int gameWidth = 20; 
        private int gameHeight = 15; 
        private int unitSize = 20; 
        private Point artifactPosition;

        public Form1()
        {
            InitializeComponent();
            panel1.Size = new Size(gameWidth * unitSize, gameHeight * unitSize);
            this.KeyPreview = true;


        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!gameRunning) return; 

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (currentDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;

                case Keys.Left:
                    if (currentDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;

                case Keys.Up:
                    if (currentDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;

                case Keys.Down:
                    if (currentDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
            }
        }



        private void InitializeGame()
        {
            snakeSegments = new List<Point>();
            currentDirection = Direction.Right;
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 500; 
            gameTimer.Tick += new EventHandler(timer1_Tick);
            GenerateArtifact();     
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100; 

            progressBar1.Width = gameWidth * unitSize;
        }

        private void EatArtifact()
        {
            currentLength++;
            GenerateArtifact(); 
        }



        private bool IsGameOver()
        {
            return snakeSegments.Count >= MaxLength();
        }


        private void GenerateArtifact()
        {
            Random rnd = new Random();
            bool isOnSnake;

            do
            {
                isOnSnake = false;
                int x = rnd.Next(0, gameWidth) * unitSize;
                int y = rnd.Next(0, gameHeight) * unitSize;

                if (x >= panel1.Width || y >= panel1.Height)
                {
                    continue; 
                }

                Point potentialArtifactPosition = new Point(x, y);

                foreach (var segment in snakeSegments)
                {
                    if (segment.Equals(potentialArtifactPosition))
                    {
                        isOnSnake = true;
                        break;
                    }
                }

                if (!isOnSnake)
                {
                    artifactPosition = potentialArtifactPosition;
                    break;
                }
            } while (isOnSnake);
        }




        private void CheckForArtifact(Point headPosition)
        {
            if (headPosition.Equals(artifactPosition))
            {
                EatArtifact();
                GenerateArtifact(); 
            }
        }
        private void StartGame()
        {
            Point startPosition = new Point(panel1.Width / 2, panel1.Height / 2);
            snakeSegments.Clear();

            for (int i = 0; i < currentLength; i++)
            {
                snakeSegments.Add(new Point(startPosition.X - i * segmentSize, startPosition.Y));
            }

            gameRunning = true;
            gameTimer.Start();
            progressBar1.Visible = true;
        }

        private void StopGame()
        {
            gameRunning = false;
            gameTimer.Stop();
            int lengthPercent = CalculateProgress();
            MessageBox.Show($"Gra zakoñczona! Uzyskana d³ugoœæ wê¿a: {lengthPercent}%");
            progressBar1.Visible = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!gameRunning) return;
            Graphics g = e.Graphics;
            foreach (Point segment in snakeSegments)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(segment.X, segment.Y, segmentSize, segmentSize));
            }

            g.FillRectangle(Brushes.Red, new Rectangle(artifactPosition.X, artifactPosition.Y, unitSize, unitSize));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            panel1.Invalidate(); 
        }



        private void MoveSnake()
        {
            Point head = snakeSegments[0];
            Point newHead = new Point(head.X, head.Y);

            switch (currentDirection)
            {
                case Direction.Right:
                    newHead.X += segmentSize;
                    break;
                case Direction.Left:
                    newHead.X -= segmentSize;
                    break;
                case Direction.Up:
                    newHead.Y -= segmentSize;
                    break;
                case Direction.Down:
                    newHead.Y += segmentSize;
                    break;
            }

            if (newHead.Equals(artifactPosition))
            {
                EatArtifact();
            }
            else
            {
                if (snakeSegments.Count > currentLength)
                {
                    snakeSegments.RemoveAt(snakeSegments.Count - 1);
                }
            }

            snakeSegments.Insert(0, newHead); 

            for (int i = 1; i < snakeSegments.Count; i++)
            {
                if (newHead.Equals(snakeSegments[i]))
                {
                    StopGame();
                    return;
                }
            }

            if (newHead.X < 0 || newHead.X >= panel1.Width || newHead.Y < 0 || newHead.Y >= panel1.Height)
            {
                StopGame();
                return;
            }

            if (snakeSegments.Count >= MaxLength())
            {
                StopGame();
                MessageBox.Show("Wygrana! W¹¿ osi¹gn¹³ maksymaln¹ d³ugoœæ.");
                return;
            }

        
            progressBar1.Value = CalculateProgress();
        }


        private int MaxLength()
        {
            int maxSegments = (panel1.Width / segmentSize) * (panel1.Height / segmentSize);
            return maxSegments;
        }

        private int CalculateProgress()
        {
            int progress = (int)(((double)snakeSegments.Count / MaxLength()) * progressBar1.Maximum);
            return progress;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!gameRunning)
            {
                ReadInputParameters();
                InitializeGame();
                StartGame();
                panel1.Focus();
            }
        }

        private void ReadInputParameters()
        {
            try
            {
                gameWidth = int.Parse(Szerokosc.Text);
                gameHeight = int.Parse(Wysokosc.Text);
                currentLength = int.Parse(Dlugosc.Text);

                if (gameWidth <= 0 || gameHeight <= 0 || currentLength <= 0)
                {
                    MessageBox.Show("Wartoœci musz¹ byæ wiêksze od 0");
                    gameRunning = false;
                    return;
                }

                panel1.Size = new Size(gameWidth * unitSize, gameHeight * unitSize);
                progressBar1.Maximum = MaxLength();
            }
            catch (FormatException)
            {
                MessageBox.Show("B³êdne parametry wejœciowe - upewnij siê, ¿e wprowadzono liczby");
                gameRunning = false;
            }
        }



        private void Stop_Click(object sender, EventArgs e)
        {
            if (gameRunning) StopGame();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (currentDirection != Direction.Left) currentDirection = Direction.Right;
                    break;
                case Keys.Left:
                    if (currentDirection != Direction.Right) currentDirection = Direction.Left;
                    break;
                case Keys.Up:
                    if (currentDirection != Direction.Down) currentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    if (currentDirection != Direction.Up) currentDirection = Direction.Down;
                    break;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "newGameToolStripMenuItem":
                    StartGame();
                    break;
                case "exitToolStripMenuItem":
                    this.Close();
                    break;
            }
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Szerokosc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Wysokosc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dlugosc_TextChanged(object sender, EventArgs e)
        {

        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}