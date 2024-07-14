namespace daneosobowe
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
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            textBox1=new TextBox();
            textBox2=new TextBox();
            radioButton1=new RadioButton();
            radioButton2=new RadioButton();
            dateTimePicker1=new DateTimePicker();
            button1=new Button();
            listBox1=new ListBox();
            button2=new Button();
            button3=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(59, 48);
            label1.Name="label1";
            label1.Size=new Size(38, 20);
            label1.TabIndex=0;
            label1.Text="Imię";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(59, 137);
            label2.Name="label2";
            label2.Size=new Size(72, 20);
            label2.TabIndex=1;
            label2.Text="Nazwisko";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(59, 233);
            label3.Name="label3";
            label3.Size=new Size(113, 20);
            label3.TabIndex=2;
            label3.Text="Data Urodzenia";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(59, 350);
            label4.Name="label4";
            label4.Size=new Size(36, 20);
            label4.TabIndex=3;
            label4.Text="Płeć";
            // 
            // textBox1
            // 
            textBox1.Location=new Point(155, 48);
            textBox1.Name="textBox1";
            textBox1.Size=new Size(125, 27);
            textBox1.TabIndex=4;
            textBox1.TextChanged+=textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location=new Point(155, 130);
            textBox2.Name="textBox2";
            textBox2.Size=new Size(125, 27);
            textBox2.TabIndex=5;
            textBox2.TextChanged+=textBox2_TextChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize=true;
            radioButton1.Location=new Point(133, 346);
            radioButton1.Name="radioButton1";
            radioButton1.Size=new Size(82, 24);
            radioButton1.TabIndex=6;
            radioButton1.TabStop=true;
            radioButton1.Text="Kobieta";
            radioButton1.UseVisualStyleBackColor=true;
            radioButton1.CheckedChanged+=radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize=true;
            radioButton2.Location=new Point(283, 346);
            radioButton2.Name="radioButton2";
            radioButton2.Size=new Size(102, 24);
            radioButton2.TabIndex=7;
            radioButton2.TabStop=true;
            radioButton2.Text="Mężczyzna";
            radioButton2.UseVisualStyleBackColor=true;
            radioButton2.CheckedChanged+=radioButton2_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location=new Point(190, 226);
            dateTimePicker1.Name="dateTimePicker1";
            dateTimePicker1.Size=new Size(250, 27);
            dateTimePicker1.TabIndex=8;
            dateTimePicker1.ValueChanged+=dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.Location=new Point(552, 350);
            button1.Name="button1";
            button1.Size=new Size(94, 29);
            button1.TabIndex=9;
            button1.Text="Zapisz";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled=true;
            listBox1.ItemHeight=20;
            listBox1.Location=new Point(427, 49);
            listBox1.Name="listBox1";
            listBox1.Size=new Size(361, 104);
            listBox1.TabIndex=10;
            listBox1.SelectedIndexChanged+=listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location=new Point(667, 350);
            button2.Name="button2";
            button2.Size=new Size(94, 29);
            button2.TabIndex=11;
            button2.Text="Usuń";
            button2.UseVisualStyleBackColor=true;
            button2.Click+=button2_Click;
            // 
            // button3
            // 
            button3.Location=new Point(552, 409);
            button3.Name="button3";
            button3.Size=new Size(94, 29);
            button3.TabIndex=12;
            button3.Text="Aktualizuj";
            button3.UseVisualStyleBackColor=true;
            button3.Click+=button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name="Form1";
            Text="Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
    }
}