// See https://aka.ms/new-console-template for more information


//string path = "input.csv";
string inputPath = args[0];
string outputPath = args[1];
bool tableOpen = true;

string fileHead() //naglowek pliku
{
    return "<!DOCTYPE html>\n<html lang=\"en\">\n<head><meta charset=\"UTF-8\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>Document</title>\n<style>\ntable, th, td {\n  border: 1px solid black;\n  border-collapse: collapse;\n}\n</style>\n</head>\n<body>";
}

string fileTail() //stopka pliku
{
    return "\n</body>\n</html>";
}
string table() //tabela
{
    if (tableOpen)
    {
        tableOpen = false;
        return "\n<table style=\"width:100%\">";
    }
    tableOpen = true;
    return "\n</table>";
}
string head(string line) //wiersz naglowkowy
{
    return "\n<tr>\n<th>\n" + line.Replace(";", "\n</th>\n<th>\n") + "\n</th>\n</tr>";
}

string body(string line) //wiersze z danymi
{
    return "\n<tr>\n<td>\n" + line.Replace(";", "\n</td>\n<td>\n") + "\n</td>\n</tr>";
}


bool first = true;
var lines = File.ReadLines(inputPath);

using (StreamWriter writer = new StreamWriter(outputPath, true))
{
    writer.Write(fileHead());
    writer.Write(table());
    foreach (var line in lines)
    {
        if (first)
        {
            writer.Write(head(line));
            first = false;
        }
        else
        {
            writer.Write(body(line));
        }
    }
    writer.Write(table());
    writer.Write(fileTail());
}