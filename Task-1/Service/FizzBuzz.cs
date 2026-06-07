using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Interfaces;
using Task_1.Models;

namespace Task_1.Service
{
    public class FizzBuzz : IFizzBuzz
    {
        public FizzBuzzResult GetOverlapping(string input)
        {
            if (!Valid(input))
            {
                return new FizzBuzzResult
                {
                    Result = "Enter a valid string to get Overlapping result .",
                    Count = 0
                };
            }

            var sb = new StringBuilder();
            int wordIndex = 0;
            int count = 0;

            int i = 0;

            while (i < input.Length)
            {
                if (IsAccepted(input[i]))
                {
                    int start = i;

                    while (i < input.Length &&
                      (IsAccepted(input[i]) ||
                      (input[i] == '\''
                       && i + 1 < input.Length
                       && IsAccepted(input[i + 1]))))
                    {
                        i++;
                    }

                    wordIndex++;

                    string word = input.Substring(start, i - start);

                    string replacement = ApplyRules(wordIndex,word, ref count);

                    sb.Append(replacement);
                }
                else
                {
                    sb.Append(input[i]);
                    i++;
                }
            }

            return new FizzBuzzResult
            {
                Result = sb.ToString(),
                Count = count
            };
        }




        private string ApplyRules(int idx,string curr, ref int count)
        {
            bool fizz = idx % 3 == 0;
            bool buzz = idx % 5 == 0;

            if (fizz && buzz)
            {
                count++;
                return "FizzBuzz";
            }

            if (fizz)
            {
                count++;
                return "Fizz";
            }

            if (buzz)
            {
                count++;
                return "Buzz";
            }

            return curr;
        }

        private bool IsAccepted(char c)
        {
            return (c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z')
                || (c >= '0' && c <= '9');
        }

        private bool Valid(string input)
        {
            if (input is null)
                return false;
            return true;
        }
    }
}
