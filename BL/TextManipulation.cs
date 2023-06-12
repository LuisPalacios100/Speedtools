using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Speedtools.BL
{
    public class TextManipulation
    {
        public string textReplacer(string input, string pre, string post)
        {
            return input.Replace(pre, post);
        }

        public string upperCase(string input)
        {
            return input.ToUpper();
        }

        public string lowerCase(string input)
        {
            return input.ToLower();
        }

        public string prepend(string input, string addition)
        {
            string delimiter = detectDelimiter(input);
            string[] entryList = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            List<string> outputList = new List<string>();
            foreach (string value in entryList)
            {
                outputList.Add(addition + value);
            }
            string result = string.Empty;
            foreach (string value in outputList)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;
        }

        public string append(string input, string addition)
        {
            string delimiter = detectDelimiter(input);
            string[] entryList = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            List<string> outputList = new List<string>();
            foreach (string value in entryList)
            {
                outputList.Add(value + addition);
            }
            string result = string.Empty;
            foreach (string value in outputList)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;
        }

        public class delimiterCounter
        {
            public int values { get; set; }
            public int key { get; set; }
        }

        public string detectDelimiter(string input)
        {

            string output = string.Empty;

            string[] comma = input.Split(',').ToArray();
            string[] column = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToArray();
            string[] semicolon = input.Split(';').ToArray();

            delimiterCounter[] comparator =
{
                new delimiterCounter {values = comma.Count(), key = 0},
                new delimiterCounter {values = column.Count(), key = 1},
                new delimiterCounter {values = semicolon.Count(), key = 2}

            };

            var orderResult = comparator.OrderByDescending(x => x.values).ToList();

            switch (orderResult[0].key)
            {
                case 0:
                    output = ",";
                    break;
                case 1:
                    output = Environment.NewLine;
                    break;
                case 2:
                    output = ";";
                    break;
            }

            return output;
        }

        public string alphabeticalOrder(string input)
        {
            string delimiter = detectDelimiter(input);
            string[] list = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            Array.Sort(list);
            string result = string.Empty;
            foreach (string value in list)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;
        }
        public string nukeBlanks(string input)
        {
            string delimiter = detectDelimiter(input);
            string[] entryList = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            List<string> outputList = new List<string>();
            foreach (string value in entryList)
            {
                outputList.Add(value.Replace(" ", ""));
            }
            string result = string.Empty;
            foreach (string value in outputList)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;
        }

        public string trimBlanks(string input)
        {
            string delimiter = detectDelimiter(input);
            string[] entryList = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            List<string> outputList = new List<string>();
            foreach (string value in entryList)
            {
                outputList.Add(value.Trim());
            }
            string result = string.Empty;
            foreach (string value in outputList)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;
        }

        public string removeDuplicates(string input)
        {
            string delimiter = detectDelimiter(input);
            string[] entryList = input.Split(new string[] { delimiter }, StringSplitOptions.None).ToArray();
            string[] outputList = entryList.Distinct().ToArray();
            string result = string.Empty;
            foreach (string value in outputList)
            {
                if (result.Length == 0)
                {
                    result = value;
                }
                else
                {
                    if (value.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += delimiter + value;
                    }
                }
            }
            return result;

        }

    }
}
