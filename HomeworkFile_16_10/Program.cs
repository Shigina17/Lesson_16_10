using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFile_16_10
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Задание 1");
                string path = Path.GetFullPath("");
                string file = "";
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        file += line;
                    }
                }
                string[] passwords = file.Substring(file.IndexOf('[') + 1, file.IndexOf(']') - file.IndexOf('[') - 1).Replace('\'', ' ').Split(',');
                string[] enicode = file.Substring(file.LastIndexOf(',') + 1, file.LastIndexOf(')') - file.LastIndexOf(',') - 1).Split('\'')[1].Split(' ');
                char[] bytes = new char[enicode.Length];
                int count = 0;
                foreach (var item in enicode)
                {
                    int bytei = Convert.ToInt32(item);
                    int c = 1, bit = 0;
                    while (bytei != 0)
                    {
                        bit += c * (bytei % 10);
                        c *= 2;
                        bytei /= 10;
                    }
                    bytes[count] = (char)bit;
                    count++;
                }
                bool flag = true;
                foreach (var item in passwords)
                {
                    if (item.Trim().Equals(new string(bytes)))
                    {
                        Console.WriteLine(item.Trim());
                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("false");
                }



                Console.WriteLine("Задание 2");
                List<string> input = Console.ReadLine().Split(' ').ToList();
                string symbols = Console.ReadLine();
                for (int i = 0; i < input.Count; i++)
                {
                    input[i] = input[i].Replace('а', '@').Replace('А', '@').Replace('a', '@').Replace('A', '@');
                    foreach (var j in symbols)
                    {
                        input[i] = input[i].Replace(j, '*');
                    }
                    input[i] += "!!!!";
                    Console.Write(input[i] + ' ');
                }
                Console.ReadKey();
            }
        }
    }