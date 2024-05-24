using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr_2
{
    using System;
    using System.IO;
    using System.Text;

    public abstract class Task
    {
        public abstract object Solve(object input);
    }

    public class Task1 : Task
    {
        public override object Solve(object input)
        {
            string word = (string)input;
            word = word.ToLower();
            bool[] letters = new bool[33];
            int dictinctLetterCount = 0;

            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    int index = GetLetterIndex(c);
                    if (!letters[index])
                    {
                        letters[index] = true;
                        dictinctLetterCount++;
                    }
                }
            }

            return dictinctLetterCount;
        }

        private int GetLetterIndex(char c)
        {
            if (c >= 'а' && c <= 'я')
            {
                return c - 'а';
            }
            else
            {
                return -1;
            }
        }
    }

    public class Task2 : Task
    {
        public override object Solve(object input)
        {
            string text = (string)input;
            string[] words = text.Split(' ', '\n', '\r', '\t');
            string[] uniqueLetterWords = new string[words.Length];
            int uniqueLetterWordsCount = 0;

            foreach (string word in words)
            {
                if (word.Length > 1 && HasUniqueLetters(word))
                {
                    uniqueLetterWords[uniqueLetterWordsCount++] = word;
                }
            }

            Array.Resize(ref uniqueLetterWords, uniqueLetterWordsCount);
            return uniqueLetterWords;
        }

        private bool HasUniqueLetters(string word)
        {
            word = word.ToLower();
            bool[] letters = new bool[33];

            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    int index = c - 'а';
                    if (letters[index])
                    {
                        return false;
                    }
                    letters[index] = true;
                }
            }
            return true;
        }
    }

    public class FileManager
    {
        private static string GetFilePath(string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string solutionPath = Path.Combine(desktopPath, "Solution");
            return Path.Combine(solutionPath, fileName);
        }

        public static void SaveDataToFile(string fileName, string data)
        {
            string filePath = GetFilePath(fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, data);
        }

        public static string ReadDataFromFile(string fileName)
        {
            string filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                return "";
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово для задания 1:");
            string inputWord = Console.ReadLine();
            Task task1 = new Task1();
            object result1 = task1.Solve(inputWord);
            Console.WriteLine($"Количество различных букв в слове: {result1}");


            FileManager.SaveDataToFile("task_1.json", $"{{\"word\": \"{inputWord}\", \"distinctLetterCount\": {result1}}}");


            string data = FileManager.ReadDataFromFile("task_1.json");
            Console.WriteLine($"Данные из task_1.json: {data}");

            Console.WriteLine();
            Console.WriteLine("Введите строку для задания 2:");
            string inputString = Console.ReadLine();
            Task task2 = new Task2();
            object result2 = task2.Solve(inputString);
            Console.WriteLine("Слова, состоящие из разных букв:");
            foreach (string word in (string[])result2)
            {
                Console.WriteLine(word);
            }


            FileManager.SaveDataToFile("task_2.json", $"{{\"inputString\": \"{inputString}\", \"uniqueLetterWords\": [{string.Join(",", (string[])result2)}]}}");


            data = FileManager.ReadDataFromFile("task_2.json");
            Console.WriteLine($"Данные из task_2.json: {data}");
        }
    }
}
