using System.Text.RegularExpressions;

string file = "input.txt";
string pathFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + file;
StreamReader streamReader = new StreamReader(pathFile);
string? line;
int total = 0;

while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    char[] characters = line?.ToCharArray();
    List<int> digitInLine = new List<int>();
    foreach (char character in characters)
    {
        if (Char.IsDigit(character))
        {
            int integer = int.Parse(character.ToString());
            digitInLine.Add(integer);
        }
    }

    string firstDigit = digitInLine.First().ToString();
    string lastDigit = digitInLine.Last().ToString();
    string calibration = firstDigit + lastDigit;
    total += int.Parse(calibration);
}

Console.WriteLine(total);