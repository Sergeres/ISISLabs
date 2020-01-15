    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeresISIS
{
    public class methods
    {
        public static int GetCountWordsByLength(string text, int length)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n', ',', '?', '-', '.', ':' }; // разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // все слова
            return words.Where(x => x.Length == length).ToList().Count; // количество слов по условию 
        }

        public static int sum(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static bool SpaceFinder(char chr)
        {
            if (chr == ' ') return true;
            else return false;
        }

        public static int CountSPACE(string str)
        {
            char[] chars = str.ToCharArray();
            char[] findChars = Array.FindAll(chars, SpaceFinder);
            int count = findChars.Length;
            return count;
        }

        public static bool Palindrom(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)

                if (s[i] != s[s.Length - i - 1])
                    return false;
            return true;
        }

        public static int ArrLen(int [] arr)
        {
            return arr.Length;
        }

        public static bool NotEqueal(int a, int b)
        {
            if (a != b)
            {
                return false;
            }
            else return true;
        }

        public static int dif(int a, int b)
        {
            int c = a - b;
            return c;
        }

        public static int dev(int a, int b)
        {
            int c = a / b;
            return c;
        }

        public static int mult(int a, int b)
        {
            int c = a * b;
            return c;
        }
    }
}
