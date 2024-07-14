namespace macierze
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
            rozpocznijMnozenie=new Button();
            progressBar1=new ProgressBar();
            labelStatus=new Label();
            backgroundWorker1=new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // rozpocznijMnozenie
            // 
            rozpocznijMnozenie.Location=new Point(292, 118);
            rozpocznijMnozenie.Name="rozpocznijMnozenie";
            rozpocznijMnozenie.Size=new Size(137, 71);
            rozpocznijMnozenie.TabIndex=1;
            rozpocznijMnozenie.Text="Pomnóż macierze";
            rozpocznijMnozenie.UseVisualStyleBackColor=true;
            rozpocznijMnozenie.Click+=rozpocznijMnozenie_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location=new Point(248, 240);
            progressBar1.Name="progressBar1";
            progressBar1.Size=new Size(236, 27);
            progressBar1.TabIndex=2;
            progressBar1.Click+=progressBar1_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize=true;
            labelStatus.Location=new Point(118, 143);
            labelStatus.Name="labelStatus";
            labelStatus.Size=new Size(0, 20);
            labelStatus.TabIndex=3;
            labelStatus.Click+=label1_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress=true;
            backgroundWorker1.DoWork+=backgroundWorker1_DoWork;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(labelStatus);
            Controls.Add(progressBar1);
            Controls.Add(rozpocznijMnozenie);
            Name="Form1";
            Text="Form1";
            Load+=Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        #endregion
        private Button rozpocznijMnozenie;
        private ProgressBar progressBar1;
        private Label labelStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}