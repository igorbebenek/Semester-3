using System;
using System.IO;
using System.Windows.Forms;

public class CsvToHtmlConverterForm : Form
{
    private TextBox inputTextBox;
    private TextBox outputTextBox;
    private Button convertButton;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;

    public CsvToHtmlConverterForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.inputTextBox = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Œcie¿ka do pliku CSV..." };
        this.outputTextBox = new TextBox { Dock = DockStyle.Top, PlaceholderText = "Œcie¿ka do pliku HTML..." };
        this.convertButton = new Button { Text = "Konwertuj", Dock = DockStyle.Top };
        this.openFileDialog = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv" };
        this.saveFileDialog = new SaveFileDialog { Filter = "HTML files (*.html)|*.html" };

        this.convertButton.Click += new EventHandler(this.ConvertButtonClick);

        this.Controls.Add(this.convertButton);
        this.Controls.Add(this.outputTextBox);
        this.Controls.Add(this.inputTextBox);
        this.AutoSize = true;
        this.Text = "Konwerter CSV do HTML";
    }

    private void ConvertButtonClick(object sender, EventArgs e)
    {
        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.inputTextBox.Text = this.openFileDialog.FileName;
            this.outputTextBox.Text = Path.ChangeExtension(this.openFileDialog.FileName, ".html");
        }

        if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.outputTextBox.Text = this.saveFileDialog.FileName;
            ConvertCsvToHtml(this.inputTextBox.Text, this.outputTextBox.Text);
        }
    }

    private void ConvertCsvToHtml(string inputPath, string outputPath)
    {
        bool tableOpen = true;

        string fileHead()
        {
            return "<!DOCTYPE html>\n<html lang=\"en\">\n<head><meta charset=\"UTF-8\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>Document</title>\n<style>\ntable, th, td {\n  border: 1px solid black;\n  border-collapse: collapse;\n}\n</style>\n</head>\n<body>";
        }

        string table()
        {
            if (tableOpen)
            {
                tableOpen = false;
                return "\n<table style=\"width:100%\">";
            }
            tableOpen = true;
            return "\n</table>";
        }

        string head(string line)
        {
            return "\n<tr>\n<th>\n" + line.Replace(",", "\n</th>\n<th>\n") + "\n</th>\n</tr>";
        }

        string body(string line)
        {
            return "\n<tr>\n<td>\n" + line.Replace(",", "\n</td>\n<td>\n") + "\n</td>\n</tr>";
        }

        string fileTail()
        {
            return "\n</body>\n</html>";
        }

        using (StreamReader reader = new StreamReader(inputPath))
        {
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                writer.WriteLine(fileHead());
                writer.WriteLine(table());

                string line;
                bool first = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (first)
                    {
                        writer.WriteLine(head(line));
                        first = false;
                    }
                    else
                    {
                        writer.WriteLine(body(line));
                    }
                }

                writer.WriteLine(table());
                writer.WriteLine(fileTail());
            }
        }

        MessageBox.Show("Konwersja zakoñczona sukcesem!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

   
}
