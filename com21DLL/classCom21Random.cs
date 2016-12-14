using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com21DLL;

namespace com21DLL
{
    public class classCom21Random
    {
        private Random r;
        const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        const string NUMBERS = "0123456789";
        const string SYMBOLS = @"~`!@#$%^&*()-_=+<>?:,./\[]{}|'";

        public classCom21Random()
        {
            r = new Random();
        }

        public classCom21Random(int seed)
        {
            r = new Random(seed);
        }

        public virtual string NextString(int length)
        {
            return NextString(length, true, true, true, true);
        }

        public virtual string NextString(int length, bool lowerCase, bool upperCase, bool numbers, bool symbols)
        {
            char[] charArray = new char[length];
            string charPool = string.Empty;

            //Build character pool
            if (lowerCase)
                charPool += LOWERCASE;

            if (upperCase)
                charPool += UPPERCASE;

            if (numbers)
                charPool += NUMBERS;

            if (symbols)
                charPool += SYMBOLS;

            //Build the output character array
            for (int i = 0; i < charArray.Length; i++)
            {
                //Pick a random integer in the character pool
                int index = r.Next(0, charPool.Length);

                //Set it to the output character array
                charArray[i] = charPool[index];
            }

            return new string(charArray);
        }
    }
}
