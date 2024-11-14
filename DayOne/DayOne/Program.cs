using System.Text.RegularExpressions;

string file = "input.txt";
string pathFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + file;
StreamReader streamReader = new StreamReader(pathFile);
string? line;
int total = 0;

while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    line = ReplaceSpellWithDigit(line);
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

string ReplaceSpellWithDigit(string input)
{
    Dictionary<string, int> spellsDigits = new Dictionary<string, int>()
    {
        { "zero" , 0 },
        { "one" , 1 },
        { "two" , 2 },
        { "three" , 3 },
        { "four" , 4 },
        { "five" , 5 },
        { "six" , 6 },
        { "seven" , 7 },
        { "eight" , 8 },
        { "nine" , 9 },
    };
    foreach (KeyValuePair<string, int> key in spellsDigits)
    {
        Regex regex = new Regex(key.Key);
        if (regex.IsMatch(input))
        {
            input = input.Replace(key.Key, key.Value + key.Key);
        }
    }

    return input;
}
