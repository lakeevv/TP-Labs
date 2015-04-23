using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleHello
{
    class Program
    {

        static void transpose()
        {
            Console.WriteLine("Исходный массив: ");
            double[,] Trans = { { 1, 5 }, { 3, 9 }, { 1.13, 2.2 } };
            for (int j = 0; j < Trans.GetLength(0); j++)
            {
                for (int i = 0; i < Trans.GetLength(1); i++)
                    Console.Write(Trans[j, i] + "\t");
                Console.WriteLine();
                Console.WriteLine();
            }
            
            Console.ReadKey();

            //Переворачиваем массив
            double[,] Trans1 = new double[Trans.GetLength(1), Trans.GetLength(0)];
            for (int j = 0; j < Trans1.GetLength(0); j++)
            {
                for (int i = 0; i < Trans1.GetLength(1); i++) Trans1[j, i] = Trans[i, j];
            }

            //Вывод перевернутого массива
            Console.WriteLine("Перевернутый массив: ");
            for (int j = 0; j < Trans1.GetLength(0); j++)
            {
                for (int i = 0; i < Trans1.GetLength(1); i++)
                    Console.Write(Trans1[j, i] + "\t");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void findmax()
        {
            int[,] Search = { { 1, 5, 69 }, { 3, 9, 1 }, { 19, 9, 31 }, { 7, 2, 45 } };
            Console.WriteLine("Исходный массив: ");
            for (int j = 0; j < Search.GetLength(0); j++)
            {
                for (int i = 0; i < Search.GetLength(1); i++)
                    Console.Write(Search[j, i] + "\t");
                Console.WriteLine();
                Console.WriteLine();
            }
            int[,] MinAr = new int[Search.GetLength(1),3];
            int Min;
            //запись минимальные элементы столбцов в массив MinAr
            for (int j = 0; j < Search.GetLength(1); j++)
            {
                Min = Search[0, j];
                for (int i = 0; i < Search.GetLength(0); i++)
                {
                    if (Search[i, j] < Min)
                    { Min = Search[i, j]; MinAr[j, 1] = i; MinAr[j, 2] = j; }
                }
                MinAr[j,0] = Min;
            }

            //Нахождение максимального элемента в массиве MinAr
            int[] Max = new int[3]; 
            Max[0] = MinAr[0,0];
            for (int i = 1; i < MinAr.GetLength(0); i++)
            {
                if (MinAr[i, 0] > Max[0])
                { Max[0] = MinAr[i, 0]; Max[1] = MinAr[i, 1]; Max[2] = MinAr[i, 2]; }
            }
            Console.Write("Минимальные элементы в столбцах: ");
            for (int i = 0; i < MinAr.GetLength(0); i++)
                Console.Write(MinAr[i,0] + "\t");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Максимальный элемент: {0}\t Строка: {1}\t Столбец: {2}",Max[0],Max[1]+1,Max[2]+1);
            Console.WriteLine();
            Console.ReadKey();
        }

        static void findword(string text)
        {
            //Запись строки в String
            char[] dSentence = { '.', '?', '!' }, dWord = { ',', ';', ' ' };
            StringSplitOptions sOpt = StringSplitOptions.RemoveEmptyEntries;

            // Сплитит предложения и слова в них
            var ss =
                text.ToLower()
                .Split(dSentence, sOpt)
                .Select(sen => sen.Split(dWord, sOpt));

            // Создает пересечение первого элемента со всеми
            var intrs =
                ss.Skip(1)
                .Aggregate(
                    new HashSet<string>(ss.First()),
                    (h, e) => { h.IntersectWith(e); return h; })
                .ToList();

            Console.WriteLine(intrs.Count > 0 ? String.Join(", ", intrs) : "Нет совпадений");
        }

        static int findmyword(string str, string myword)
        {
            int sum = 0;
            str = str.Replace(".", " ");
            str = str.Replace("  ", " ");
            string[] words = str.Split(' ');
            int len = words.Length;
            for (int i = 0; i < len; i++)
            {
                if (myword == words[i]) sum++;
            }
            return sum;
        }

        static string oreplacer(string ostr)
        {
            Regex r = new Regex(@"(o|O|о|О)");
            string ostr1 = r.Replace(ostr, "$1Ok"); 	// $1 – соответствует группе (o|O|о|О)
            return ostr1;
        }

        static int FindInt(string str)
        {
            Regex pat = new Regex(@"\d");
            Match match = pat.Match(str);
            if (match.Success) return (1); else return (0);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Какое задание вы хотите выполнить?");
            Console.WriteLine("1 - Задание 2.4(Переворачиваем массив):");
            Console.WriteLine("2 - Задание 2.9(Максимальный среди минимальных):");
            Console.WriteLine("3 - Задание 3.4(Найти введенное слово):");
            Console.WriteLine("4 - Задание 3.9(Найти повторяющееся слово):");
            Console.WriteLine("5 - Задание 4.4(Заменяет о на Ок):");
            Console.WriteLine("6 - Задание 4.9(Проверяет на числа):");
            /*
            string masha = "fdsjdhflkasfnsaljfdsa";
            if (FindInt(masha)==0) Console.WriteLine("Чисел нет"); else Console.WriteLine("Числа есть");*/

            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    {
                        Console.WriteLine("Задание 2.4(Переворачиваем массив):");
                        transpose();
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine("Задание 2.9(Максимальный среди минимальных):");
                        findmax();
                    }
                    break;
                case "3":
                    {
                        
                        Console.WriteLine("Задание 3.4(Найти введенное слово):");
                        Console.WriteLine("Введите вашу строку(текст): ");
                        string str= Console.ReadLine();
                        Console.WriteLine("Введите слово для поиска: ");
                        string myword=Console.ReadLine();
                        int result = findmyword(str, myword);
                        if (result == 0) Console.WriteLine("Данного слова нет в тексте."); 
                        else Console.WriteLine("Слово встречается в тексте {0} раз(а).", result);
                        
                    }
                    break;
                case "4":
                    {
                        Console.WriteLine("Задание 3.9(Найти повторяющееся слово):");
                        Console.WriteLine("Введите вашу строку(текст): ");
                        string str = Console.ReadLine();
                        findword(str);
                    }
                    break;
                case "5":
                    {
                        Console.WriteLine("Задание 4.4(Заменяет о на Ок):");
                        Console.WriteLine("Введите вашу строку(текст): ");
                        string ostr = Console.ReadLine();
                        Console.WriteLine(oreplacer(ostr));
                    }
                    break;
                case "6":
                    {
                        Console.WriteLine("Задание 4.9(Проверяет на числа):");
                        Console.WriteLine("Введите вашу строку(текст): ");
                        string str = Console.ReadLine();
                        if (FindInt(str) == 0) Console.WriteLine("Чисел нет"); else Console.WriteLine("Числа есть");
                    }

            
                    break;
            }
            Console.ReadKey();
			Console.ReadKey();
        }
   



        }
}
