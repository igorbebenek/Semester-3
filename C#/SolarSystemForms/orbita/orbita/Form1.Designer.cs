namespace orbita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1=new PictureBox();
            pictureBox2=new PictureBox();
            pictureBox3=new PictureBox();
            timer1=new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor=SystemColors.Desktop;
            pictureBox1.Image=(Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location=new Point(419, 337);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(73, 49);
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex=0;
            pictureBox1.TabStop=false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image=(Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location=new Point(265, 176);
            pictureBox2.Name="pictureBox2";
            pictureBox2.Size=new Size(111, 51);
            pictureBox2.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex=1;
            pictureBox2.TabStop=false;
            pictureBox2.Click+=pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image=(Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location=new Point(342, 253);
            pictureBox3.Name="pictureBox3";
            pictureBox3.Size=new Size(99, 46);
            pictureBox3.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex=2;
            pictureBox3.TabStop=false;
            // 
            // timer1
            // 
            timer1.Enabled=true;
            timer1.Tick+=timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=SystemColors.Control;
            ClientSize=new Size(800, 450);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name="Form1";
            Text="Form1";
            Load+=Form1_Load;
            Paint+=Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
    }
}