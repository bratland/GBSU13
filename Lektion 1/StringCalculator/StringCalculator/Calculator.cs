using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            var validDelimiters = new List<string> { ",", "\n" };
            var delimiter = FindDelimiters(inputString);
            inputString = CleanInput(inputString);
            if (delimiter != null)
                validDelimiters.AddRange(delimiter);

            var stringValues = inputString.Split(validDelimiters.ToArray(), StringSplitOptions.None);
            var ints = stringValues.Select(int.Parse);


            
            try
            {
                var sum = ints.Where(v => v <= 1000).Sum();
                if (ints.Any(i => i < 0))
                {
                    throw new Exception(" Illegal Values: " + string.Join(", ", ints.Where(i => i < 0)));
                }                
                return sum;
            }
            catch (Exception)
            {
                throw new Exception("Contains invalid chars");
            }
        }

        private string CleanInput(string inputString)
        {
            if (inputString.StartsWith("//"))
                inputString = inputString.Split(new char[] { '\n' }, 2)[1];

            inputString = inputString.Replace(" ", "");

            return inputString;
        }

        private IEnumerable<string> FindDelimiters(string inputString)
        {
            if (inputString.StartsWith("//"))
            {
                var rawDelimiters = inputString.Substring(2);
                var delimiters = new List<string>();

                if (rawDelimiters[0] != '[')
                    delimiters.Add(rawDelimiters.Split('\n')[0]);

                while (rawDelimiters.Contains('['))
                {
                    var splittedDelimiters = rawDelimiters.Split(new char[] { ']' }, 2);
                    delimiters.Add(splittedDelimiters[0].Substring(1));
                    rawDelimiters = splittedDelimiters[1];
                }

                return delimiters;
            }

            return new string[]{};
        }
    }
}
