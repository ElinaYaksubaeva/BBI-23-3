using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task3
    {
        public class Searcher
        {
            private string _input;
            private string[] _output;

            public string Input
            {
                get { return _input; }
            }

            public string[] Output
            {
                get { return _output; }
            }

            public Searcher(string input)
            {
                _input = input;
                string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                _output = new string[words.Length];
                int palindromesCount = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 1 && IsPalindrome(words[i]))
                    {
                        _output[palindromesCount] = words[i];
                        palindromesCount++;
                    }
                }
                _output = _output.Take(palindromesCount).ToArray();
            }

            private bool IsPalindrome(string word)
            {
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - i - 1])
                    {
                        return false;
                    }
                }
                return true;
            }

            public override string ToString()
            {
                if (_output.Length == 0)
                {
                    return "";
                }
                else
                {
                    string result = "";
                    for (int i = 0; i < _output.Length; i++)
                    {
                        result += _output[i] + "\n";
                    }
                    return result;
                }
            }
        }

    }
}
