//Непросто отличить правду от лжи, и тем более от правды, но не всей. Если в строке есть подстрока not, то это правда.
//Если в строке нет подстроки not и длина не больше 20 символов, то будем считать её полуправдой.
//Остальные строки – ложь.

//Напишите программу для разделения строк по типам.

//Формат ввода
//Вводятся строки, пока не будет введена строка Final.

//Формат вывода
//В одну строку через пробел выведите сначала общую длину правдивых строк, затем строк с полуправдой, затем лживых строк.
using System;

namespace Олимпиада
{
    class MyException : Exception
    {
        public MyException(string Text)
        {
            Console.WriteLine(Text + "\nПрограмма будет закрыта!");
            Environment.Exit(1);
        }      
    }
    internal class MainClass
    {
        static void Main(string[] args)
        {

            // Принятие строк до ввода слова Final. Удаление Final, удаление лишних точек и пробелов, проверка на пустышку.
            string Lines = "";            
            while (true)
            {
                Lines += Console.ReadLine();              
                if (Lines.Contains("Final"))
                {
                    if (Lines == "Final")
                    {
                        throw new MyException("Ошибка: Текст не распознан!");
                    }

                    Lines = Lines.Remove(Lines.Length - 5);

                    if (Lines.Length < 2)
                    {
                        throw new MyException("Ошибка: Текст не распознан!\nМало букв");
                    }
                    // Удаление лишних точек и пробелов                                       
                    for (int i = 0; i < Lines.Length; i++)
                    {
                        if (Lines.StartsWith(" "))
                        {
                            Lines = Lines.TrimStart(new char[] { ' ' });
                        }
                        if (Lines.StartsWith(" "))
                        {
                            Lines = Lines.TrimStart(new char[] { '.' });
                        }

                        if (Lines[i].ToString().Contains("."))
                        {
                            if (i + 1 > Lines.Length - 1)
                            {
                                break;
                            }
                            if (Lines[i + 1].ToString().Contains("."))
                            {
                                Lines = Lines.Remove(i, 1);
                                i -= 1;
                                continue;
                            }
                            /////////////////////////////////////////
                            if (i - 1 < 0)
                            {
                                continue;
                            }
                            if (Lines[i - 1].ToString().Contains(" "))
                            {
                                Lines = Lines.Remove(i, 1);
                                i -= 1;
                                continue;
                            }
                        }

                        if (Lines[i].ToString().Contains(" "))
                        {
                            if (i + 1 == Lines.Length - 1)
                            {
                                break;
                            }
                            if (Lines[i + 1].ToString().Contains(" "))
                            {
                                Lines = Lines.Remove(i, 1);
                                i -= 1;
                                continue;
                            }
                        }
                    }

                    // Если в тексте нет точки, или она отстуствует в конце теста, то она автоматически ставится в конец
                    if ((Lines.IndexOfAny(new char[] { '.' }) == -1) | ((Lines[Lines.Length - 1]) != '.'))
                    {
                        Lines += ".";
                    }
                    break;
                }                
            }      
            Console.WriteLine(" "); 

            // Переработка в двумерный массив 
            int counter_length_of_the_lines_1 = 0;
            int counter_length_of_the_lines_2 = 0;
            int counter_length_of_the_lines_3 = 0;
            
            int counter_of_point = 0;            
            for (int i = 0; i < Lines.Length; i++) 
            {
                if (Lines[i].ToString().Contains("."))
                {
                    counter_of_point++;                   
                }               
            }            
            string[] LinesArr;
            LinesArr = new string[counter_of_point];
            int j = 0;
            int k = 0;
            int c = 0;              
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].ToString().Contains("."))
                {
                    c = i + 1;
                    LinesArr[k] = Lines.ToString().Substring(j, c - j);                    
                    if (i == Lines.Length - 1)
                    {
                        break;
                    }        
                    j = c;                                                         
                    k++;
                }       
            }
           
            ///////////////////////////////////////////// Вывод конечных версий строк на печать
            for (int i = 0; i < LinesArr.Length; i++)
            {
                Console.WriteLine(LinesArr[i]);
            }
            Console.WriteLine(" ");
            ///////////////////////////////////////////////// Сортировка по заданию
            for (int i = 0; i < LinesArr.Length; i++)
            {
                if (LinesArr[i].Contains("not"))
                {
                    counter_length_of_the_lines_1 += LinesArr[i].Length;
                }
                else if (LinesArr[i].Length <= 20 && !LinesArr[i].Contains("not"))
                {
                    counter_length_of_the_lines_2 += LinesArr[i].Length;
                }
                else
                {
                    counter_length_of_the_lines_3 += LinesArr[i].Length;
                }
            }
            //////////////////////////////////////////////// Вывод ответа
            Console.Write(counter_length_of_the_lines_1 + " " + counter_length_of_the_lines_2 + " " + counter_length_of_the_lines_3);
            Console.WriteLine(" ");
            //Debug
        }
    }
}
