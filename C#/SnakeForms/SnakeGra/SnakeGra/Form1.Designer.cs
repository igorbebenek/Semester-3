namespace SnakeGra
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            Start = new Button();
            Stop = new Button();
            panel1 = new Panel();
            Szerokosc = new TextBox();
            Wysokosc = new TextBox();
            Dlugosc = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(268, 42);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(513, 29);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 42);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "Score";
            label1.Click += label1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1544, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // Start
            // 
            Start.Location = new Point(1397, 101);
            Start.Name = "Start";
            Start.Size = new Size(94, 29);
            Start.TabIndex = 3;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // Stop
            // 
            Stop.Location = new Point(1397, 150);
            Stop.Name = "Stop";
            Stop.Size = new Size(94, 29);
            Stop.TabIndex = 4;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += Stop_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(75, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 510);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // Szerokosc
            // 
            Szerokosc.Location = new Point(1385, 228);
            Szerokosc.Name = "Szerokosc";
            Szerokosc.Size = new Size(125, 27);
            Szerokosc.TabIndex = 6;
            Szerokosc.TextChanged += Szerokosc_TextChanged;
            // 
            // Wysokosc
            // 
            Wysokosc.Location = new Point(1385, 283);
            Wysokosc.Name = "Wysokosc";
            Wysokosc.Size = new Size(125, 27);
            Wysokosc.TabIndex = 7;
            Wysokosc.TextChanged += Wysokosc_TextChanged;
            // 
            // Dlugosc
            // 
            Dlugosc.Location = new Point(1385, 339);
            Dlugosc.Name = "Dlugosc";
            Dlugosc.Size = new Size(125, 27);
            Dlugosc.TabIndex = 8;
            Dlugosc.TextChanged += Dlugosc_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1274, 235);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 9;
            label2.Text = "Szerokosc";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1275, 283);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 10;
            label3.Text = "Wysokosc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1263, 339);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 11;
            label4.Text = "Dlugosc weza";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 718);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Dlugosc);
            Controls.Add(Wysokosc);
            Controls.Add(Szerokosc);
            Controls.Add(panel1);
            Controls.Add(Stop);
            Controls.Add(Start);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
        private Label label1;
        private MenuStrip menuStrip1;
        private Button Start;
        private Button Stop;
        private Panel panel1;
        private TextBox Szerokosc;
        private TextBox Wysokosc;
        private TextBox Dlugosc;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
