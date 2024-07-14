namespace InvoiceManager
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
            InvoicePos = new DataGridView();
            Invoice = new DataGridView();
            DodajFakture = new Button();
            AktualizujFakture = new Button();
            UsunFakture = new Button();
            DodajPozycje = new Button();
            AktualizujPozycje = new Button();
            UsunPozycje = new Button();
            NazwaPozycji = new TextBox();
            NumerFaktury = new TextBox();
            LabelNumerFaktury = new Label();
            LabelNazwaPozycji = new Label();
            LabelWartoscPozycji = new Label();
            WartoscPozycji = new TextBox();
            label1 = new Label();
            WartoscFaktury = new TextBox();
            ((System.ComponentModel.ISupportInitialize)InvoicePos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Invoice).BeginInit();
            SuspendLayout();
            // 
            // InvoicePos
            // 
            InvoicePos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InvoicePos.Location = new Point(660, 252);
            InvoicePos.Name = "InvoicePos";
            InvoicePos.RowHeadersWidth = 51;
            InvoicePos.Size = new Size(475, 348);
            InvoicePos.TabIndex = 0;
            InvoicePos.CellContentClick += InvoicePos_CellContentClick;
            // 
            // Invoice
            // 
            Invoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Invoice.Location = new Point(74, 261);
            Invoice.Name = "Invoice";
            Invoice.RowHeadersWidth = 51;
            Invoice.Size = new Size(457, 298);
            Invoice.TabIndex = 1;
            Invoice.CellContentClick += Invoice_CellContentClick;
            // 
            // DodajFakture
            // 
            DodajFakture.Location = new Point(12, 52);
            DodajFakture.Name = "DodajFakture";
            DodajFakture.Size = new Size(136, 29);
            DodajFakture.TabIndex = 2;
            DodajFakture.Text = "Dodaj fakturę";
            DodajFakture.UseVisualStyleBackColor = true;
            DodajFakture.Click += DodajFakture_Click;
            // 
            // AktualizujFakture
            // 
            AktualizujFakture.Location = new Point(12, 123);
            AktualizujFakture.Name = "AktualizujFakture";
            AktualizujFakture.Size = new Size(136, 29);
            AktualizujFakture.TabIndex = 3;
            AktualizujFakture.Text = "Aktualizuj fakturę";
            AktualizujFakture.UseVisualStyleBackColor = true;
            AktualizujFakture.Click += AktualizujFakture_Click;
            // 
            // UsunFakture
            // 
            UsunFakture.Location = new Point(12, 191);
            UsunFakture.Name = "UsunFakture";
            UsunFakture.Size = new Size(136, 29);
            UsunFakture.TabIndex = 4;
            UsunFakture.Text = "Usuń fakturę";
            UsunFakture.UseVisualStyleBackColor = true;
            UsunFakture.Click += UsunFakture_Click;
            // 
            // DodajPozycje
            // 
            DodajPozycje.Location = new Point(660, 52);
            DodajPozycje.Name = "DodajPozycje";
            DodajPozycje.Size = new Size(136, 29);
            DodajPozycje.TabIndex = 5;
            DodajPozycje.Text = "Dodaj pozycję";
            DodajPozycje.UseVisualStyleBackColor = true;
            DodajPozycje.Click += DodajPozycje_Click;
            // 
            // AktualizujPozycje
            // 
            AktualizujPozycje.Location = new Point(660, 123);
            AktualizujPozycje.Name = "AktualizujPozycje";
            AktualizujPozycje.Size = new Size(166, 29);
            AktualizujPozycje.TabIndex = 6;
            AktualizujPozycje.Text = "Aktualizuj pozycję";
            AktualizujPozycje.UseVisualStyleBackColor = true;
            AktualizujPozycje.Click += AktualizujPozycje_Click;
            // 
            // UsunPozycje
            // 
            UsunPozycje.Location = new Point(660, 191);
            UsunPozycje.Name = "UsunPozycje";
            UsunPozycje.Size = new Size(136, 29);
            UsunPozycje.TabIndex = 7;
            UsunPozycje.Text = "Usuń pozycję";
            UsunPozycje.UseVisualStyleBackColor = true;
            UsunPozycje.Click += UsunPozycje_Click;
            // 
            // NazwaPozycji
            // 
            NazwaPozycji.Location = new Point(859, 123);
            NazwaPozycji.Name = "NazwaPozycji";
            NazwaPozycji.Size = new Size(192, 27);
            NazwaPozycji.TabIndex = 9;
            NazwaPozycji.TextChanged += NazwaPozycji_TextChanged;
            // 
            // NumerFaktury
            // 
            NumerFaktury.Location = new Point(241, 125);
            NumerFaktury.Name = "NumerFaktury";
            NumerFaktury.Size = new Size(196, 27);
            NumerFaktury.TabIndex = 10;
            // 
            // LabelNumerFaktury
            // 
            LabelNumerFaktury.AutoSize = true;
            LabelNumerFaktury.Location = new Point(473, 127);
            LabelNumerFaktury.Name = "LabelNumerFaktury";
            LabelNumerFaktury.Size = new Size(103, 20);
            LabelNumerFaktury.TabIndex = 11;
            LabelNumerFaktury.Text = "Numer faktury";
            // 
            // LabelNazwaPozycji
            // 
            LabelNazwaPozycji.AutoSize = true;
            LabelNazwaPozycji.Location = new Point(1065, 126);
            LabelNazwaPozycji.Name = "LabelNazwaPozycji";
            LabelNazwaPozycji.Size = new Size(105, 20);
            LabelNazwaPozycji.TabIndex = 12;
            LabelNazwaPozycji.Text = "Nazwa pozycji";
            LabelNazwaPozycji.Click += LabelNazwaPozycji_Click;
            // 
            // LabelWartoscPozycji
            // 
            LabelWartoscPozycji.AutoSize = true;
            LabelWartoscPozycji.Location = new Point(1065, 196);
            LabelWartoscPozycji.Name = "LabelWartoscPozycji";
            LabelWartoscPozycji.Size = new Size(62, 20);
            LabelWartoscPozycji.TabIndex = 13;
            LabelWartoscPozycji.Text = "Wartosc";
            LabelWartoscPozycji.Click += LabelWartoscPozycji_Click;
            // 
            // WartoscPozycji
            // 
            WartoscPozycji.Location = new Point(850, 193);
            WartoscPozycji.Name = "WartoscPozycji";
            WartoscPozycji.Size = new Size(192, 27);
            WartoscPozycji.TabIndex = 14;
            WartoscPozycji.TextChanged += WartoscPozycji_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(487, 177);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 16;
            label1.Text = "Wartosc";
            // 
            // WartoscFaktury
            // 
            WartoscFaktury.Location = new Point(241, 177);
            WartoscFaktury.Name = "WartoscFaktury";
            WartoscFaktury.Size = new Size(196, 27);
            WartoscFaktury.TabIndex = 17;
            WartoscFaktury.TextChanged += WartoscFaktury_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 612);
            Controls.Add(WartoscFaktury);
            Controls.Add(label1);
            Controls.Add(WartoscPozycji);
            Controls.Add(LabelWartoscPozycji);
            Controls.Add(LabelNazwaPozycji);
            Controls.Add(LabelNumerFaktury);
            Controls.Add(NumerFaktury);
            Controls.Add(NazwaPozycji);
            Controls.Add(UsunPozycje);
            Controls.Add(AktualizujPozycje);
            Controls.Add(DodajPozycje);
            Controls.Add(UsunFakture);
            Controls.Add(AktualizujFakture);
            Controls.Add(DodajFakture);
            Controls.Add(Invoice);
            Controls.Add(InvoicePos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)InvoicePos).EndInit();
            ((System.ComponentModel.ISupportInitialize)Invoice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView InvoicePos;
        private DataGridView Invoice;
        private Button DodajFakture;
        private Button AktualizujFakture;
        private Button UsunFakture;
        private Button DodajPozycje;
        private Button AktualizujPozycje;
        private Button UsunPozycje;
        private TextBox NazwaPozycji;
        private TextBox NumerFaktury;
        private Label LabelNumerFaktury;
        private Label LabelNazwaPozycji;
        private Label LabelWartoscPozycji;
        private TextBox WartoscPozycji;
       
        private Label label1;
        private TextBox WartoscFaktury;
    }
}
