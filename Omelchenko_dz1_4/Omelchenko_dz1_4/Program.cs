using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Omelchenko_dz1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chains1;
            string[] chains2;

            Console.WriteLine("Введите путь к файлу, где содержаться цепочки первого языка, в формате диск:\\папка/папка/.../файл.расширение");
            Console.WriteLine("Или введите language1.txt, с тестовым алфавитом:{abc a df}"); 
            var path1 = Console.ReadLine();
            try
            {
                chains1 = Read(path1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Путь к файлу указан некоректно");
                return;
            }
            Console.WriteLine("Прочитанные цепочки первого языка:");
            Print(chains1);

            Console.WriteLine("Введите путь к файлу, где содержаться цепочки второго языка, в формате диск:\\папка/папка/.../файл.расширение");
            Console.WriteLine("Или введите language2.txt, стестовым алфавитом:{12 cf}");
            var path2 = Console.ReadLine();
            try
            {
                chains2 = Read(path2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Путь к файлу указан некоректно");
                return;
            }
            Console.WriteLine("Прочитанные цепочки второго языка:");
            Print(chains2);

            var chains3 = Concatenation(chains1, chains2);
            Console.WriteLine("Язык полученный Конкатенацией этих языков:");
            Print(chains3);

            Console.WriteLine("Введите путь к файлу, куда сохранить цепочки получившегося языка, в формате диск:\\папка/папка/.../файл.расширение");
            Console.WriteLine("Или введите -, чтобы не сохранять");
            var path3 = Console.ReadLine();
            if (path3 != "-")
            {
                try
                {
                    Write(path3, chains3);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Путь к файлу указан некоректно");
                    return;
                }
            }
            Console.ReadKey(true);
        }

        static string[] Read(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                var lines = sr.ReadToEnd();
                var chains = lines.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                return chains;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new string[] { };
            }
        }

        static void Write(string path, string[] chains)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                foreach(var chain in chains)
                {
                    sw.Write(chain + " ");
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static void Print(string[] words)
        {
            foreach(var word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }

        static string[] Concatenation(string[] chains1, string[] chains2)
        {

            string[] result = new string[chains1.Length*chains2.Length];
            for (int i = 0; i < chains1.Length; i++)
                for (int j = 0; j < chains2.Length; j++)
                    result[i * chains2.Length + j] = chains1[i] + chains2[j];
            return result;
        }
    }
}
