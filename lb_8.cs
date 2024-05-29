using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    public Task(string text) { }
    protected virtual string ParseText(string text)
    {
        return text;
    }

}
class Task_2 : Task
{
    private string text;
    public Task_2(string text) : base(text) { this.text = text; }

    public string Encrypt(string text)
    {
        char[] punctuation = { '.', ',', '!', '?', ';', ':', '(', ')' };
        StringBuilder reversed = new StringBuilder();
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            int punctuationIndex = -1;

            foreach (char p in punctuation)
            {
                if (word.Contains(p))
                {
                    punctuationIndex = word.IndexOf(p);
                    break;
                }
            }

            if (punctuationIndex != -1)
            {
                string reversedWord = new string(word.Substring(0, punctuationIndex).ToCharArray().Reverse().ToArray());
                reversed.Append(reversedWord + word[punctuationIndex]);
            }
            else
            {
                string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
                reversed.Append(reversedWord);
            }

            if (i < words.Length - 1)
            {
                reversed.Append(" ");
            }
        }

        return (reversed).ToString();
    }
    public string Descrypt(string text2)
    {
        text = Encrypt(text2);
        return text;
    }
}
class Task_4 : Task
{
    private string text;
    public Task_4(string text) : base(text) { this.text = text; }

    public int HardText(string text4)
    {
        int hardText = 0;
        string[] words = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            foreach (char c in word)
            {
                if (char.IsPunctuation(c))
                {
                    hardText++;
                }
            }
        }
        hardText += words.Length;
        return hardText;
    }
}

class Task_6 : Task
{
    protected string text;
    public Task_6(string text) : base(text) { this.text = text; }

    public int[] CountSyllables(string text)
    {
        int one = 0;
        int two = 0;
        int three = 0;
        int other = 0;
        int Counter = 0;
        string[] words = text.Split(' ');
        Regex regex = new Regex("[ёуеыаоэяиюeyuoai]", RegexOptions.IgnoreCase);
        foreach (string word in words)
        {
            Counter = regex.Matches(word).Count;

            if (word.EndsWith("e") || word.EndsWith("es"))
            {
                Counter--;
            }
            if (Counter == 1)
                one++;
            else if (Counter == 2) two++;
            else if (Counter == 3) three++;
            else other++;

        }
        int[] count = new int[] { one, two, three, other };

        return count;
    }
}
class Task_8 : Task
{
    public List<string> lines = new List<string>();
    private string text;
    public Task_8(string text) : base(text) { this.text = text; }
    public string ParseText(string text)
    {
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder line = new StringBuilder();
        int lineLength = 0;

        foreach (string word in words)
        {
            if (lineLength + word.Length + 1 > 50)
            {
                AdjustLine(line, 50);
                lines.Add(line.ToString());
                line.Clear();
                lineLength = 0;
            }

            if (line.Length > 0)
            {
                line.Append(" ");
                lineLength++;
            }
            line.Append(word);
            lineLength += word.Length;
        }

        if (line.Length > 0)
        {
            AdjustLine(line, 50);
            lines.Add(line.ToString());
        }

        return string.Join("\n", lines);
    }

    private void AdjustLine(StringBuilder line, int targetLength)
    {
        while (line.Length < targetLength)
        {
            for (int i = 0; i < line.Length && line.Length < targetLength; i++)
            {
                if (line[i] == ' ' && (i == 0 || line[i - 1] != ' '))
                {
                    line.Insert(i, ' ');

                    i++;
                }
            }
        }
    }
}

class Task_9 : Task
{
    string text;
    private string[] Ke;
    private string[] Codes;
    public Task_9(string text) : base(text) { this.text = text; }
    public string[] GetKeys()
    {
        return Ke;
    }
    public string[] GetCodes()
    {
        return Codes;
    }
    public override string ToString()
    {
        return ParseText(text);
    }

    protected string[] First10KeysToArray(Dictionary<string, int> a)
    {
        return a.Take(10).Select(x => x.Key).ToArray();
    }
    protected Dictionary<string, int> CreateRusLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 1072; i < 1105; i++)
        {
            for (int j = 1072; j < 1105; j++)
            {
                int n1 = i;
                int n2 = j;
                if (i == 1104) { n1 += 1; }
                if (j == 1104) { n2 += 1; }
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }
        return letterComb;
    }
    protected Dictionary<string, int> CreateEngLetterDict()
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();
        for (int i = 97; i < 123; i++)
        {
            for (int j = 97; j < 123; j++)
            {
                int n1 = i;
                int n2 = j;
                char first = (char)n1;
                char second = (char)n2;
                string k = first.ToString() + second.ToString();
                letterComb.Add(k, 0);
            }
        }

        return letterComb;
    }
    protected bool CheckTextOnLanguage()
    {
        string rusLetter = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
        for (int i = 0; i < rusLetter.Length; i++)
        {
            if (text.Contains(rusLetter[i]))
            {
                return true;
            }
        }
        return false;
    }
    protected string[] CreateCode()
    {
        string[] code = new string[10];
        int c = 0;
        for (int i = 33; i < 127; i++)
        {
            if (text.Contains((char)i) == false)
            {
                code[c] = char.ToUpper((char)i).ToString();
                c++;
                if (c == 10)
                {
                    break;
                }
            }

        }
        return code;
    }
    protected override string ParseText(string text)
    {
        Dictionary<string, int> letterComb = new Dictionary<string, int>();

        if (CheckTextOnLanguage() == false)
        {
            letterComb = CreateEngLetterDict();
        }
        else
        {
            letterComb = CreateRusLetterDict();
        }

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (letterComb.ContainsKey(text[i].ToString() + text[i + 1].ToString()))
            {
                letterComb[text[i].ToString() + text[i + 1].ToString()]++;
            }
        }


        var sortedLetterComb = letterComb.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        string[] ke = First10KeysToArray(sortedLetterComb);
        string[] code = CreateCode();

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(ke[i], code[i]);
        }
        Ke = ke;
        Codes = code;

        return text;
    }

}
class Task_10 : Task
{
    string[] codes;
    string[] keys;
    string text;
    public Task_10(string text, string[] codes, string[] keys) : base(text)
    {
        this.text = text;
        this.codes = codes;
        this.keys = keys;
    }
    public override string ToString()
    {
        return ParseText(text);
    }

    protected override string ParseText(string text)
    {

        string[] ke = keys;
        string[] code = codes;

        for (int i = 0; i < ke.Length; i++)
        {
            text = text.Replace(code[i], ke[i]);
        }

        return text;
    }

}

class Program
{
    public static void Main()
    {
        string text = "Три девицы под окном. Пряли поздно вечерком";
        Task_2 task2 = new Task_2(text);
        Console.WriteLine("Исходный текст: ");
        Console.WriteLine(text);
        Console.WriteLine("\nЗадание 2 (зашифровано)");
        Console.WriteLine(task2.Encrypt(text));
        Console.WriteLine("\nЗадание 2 (расшифровано)");
        Console.WriteLine(task2.Descrypt(task2.Encrypt(text)));

        Task_4 task4 = new Task_4(text);
        Console.WriteLine("\nЗадание 4");
        Console.WriteLine(task4.HardText(text));

        Task_6 task6 = new Task_6(text);
        int[] count = task6.CountSyllables(text);
        Console.WriteLine("\nЗадание 6");
        for (int i = 0; i < count.Length; i++)
        {
            Console.WriteLine("Количество слоговов: {0} \t Количество слов : {1} ", i, count[i]);
        }

        Console.WriteLine("\n Задание 8");
        Task_8 task8 = new Task_8(text);
        Console.WriteLine(task8.ParseText(text));




        Console.WriteLine("\n Задание 9");
        Task_9 task9 = new Task_9(text);
        Console.WriteLine(task9);

        Console.WriteLine("\nЗадание 10");
        Task_10 task10 = new Task_10(task9.ToString(), task9.GetCodes(), task9.GetKeys());
        Console.WriteLine(task10);

    }
}

