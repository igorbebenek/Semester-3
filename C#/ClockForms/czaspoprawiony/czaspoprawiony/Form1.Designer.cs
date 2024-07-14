namespace czaspoprawiony
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
            components=new System.ComponentModel.Container();
            Czas=new Label();
            Data=new Label();
            timer1=new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Czas
            // 
            Czas.AutoSize=true;
            Czas.Font=new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Czas.Location=new Point(68, 62);
            Czas.Name="Czas";
            Czas.Size=new Size(59, 25);
            Czas.TabIndex=0;
            Czas.Text="Czas";
            Czas.Click+=Czas_Click;
            // 
            // Data
            // 
            Data.AutoSize=true;
            Data.Font=new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Data.Location=new Point(473, 62);
            Data.Name="Data";
            Data.Size=new Size(61, 25);
            Data.TabIndex=1;
            Data.Text="Data";
            Data.Click+=Data_Click;
            // 
            // timer1
            // 
            timer1.Tick+=timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(Data);
            Controls.Add(Czas);
            Name="Form1";
            Text="Form1";
            Load+=Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Czas;
        private Label Data;
        private System.Windows.Forms.Timer timer1;
    }
}