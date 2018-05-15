using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Программа, которая определяет, можно ли введенное число представить в виде 
//произведения трех последовательных простых чисел.
//При решении задания не допускается использование массивов, списков, коллекций и тому подобное.
//Пример:
//Последовательные простые числа:  2,3,5; 3,5,7; 5,7,11; 7,11,13; 11,13,17…
//105 – введенное число
//Ответ – Да, 3 * 5 * 7 = 105
 
//2431 – введенное число
//Ответ – Да, 11 * 13 * 17 = 2431
 
//18 – введенное число
//Ответ – Нет.

namespace Task1
{
    class Program
    {
        public static bool IsNumberPrime(int src)
        {
            int counter = 0;
            for (int i = 1; i <= src; i++)
            {
                if (src % i == 0)
                {
                    counter++;
                }
            }
            return counter == 2 ? true : false;
        }

        public static bool CanBeRepresented(int src, int num1, int num2, int num3)
        {
            return (src / (num1 * num2 * num3)) == 1 ? true : false;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, write a number");
                int source = Convert.ToInt32(Console.ReadLine());
                int prime1 = 0, prime2 = 0, prime3 = 0;
                Console.WriteLine("Can we represented a number as a product of three consecutive prime numbers?");
                for (int i = 1; i <= source; i++)
                {
                    if (IsNumberPrime(i))
                    {
                        if (prime1 == 0)
                        {
                            prime1 = i;
                            continue;
                        }
                        else if (prime2 == 0)
                        {
                            prime2 = i;
                            continue;
                        }
                        else if (prime3 == 0)
                        {
                            prime3 = i;
                            if (CanBeRepresented(source, prime1, prime2, prime3))
                            {
                                Console.WriteLine("Yes, we can: {0} = {1} * {2} * {3}", source, prime1, prime2, prime3);
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                prime1 = prime2;
                                prime2 = prime3;
                                prime3 = 0;
                            }
                        }
                    }
                }
                Console.WriteLine("No, we can not.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
