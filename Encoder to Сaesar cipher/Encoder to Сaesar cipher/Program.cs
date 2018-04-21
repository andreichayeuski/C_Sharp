using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder_to_Сaesar_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // A simple algorithm for encrypting a string with Caesar's cipher with a specified offset (offset)

                #region Create the correct alphabet given the encoding Unicode
                Console.Write("Allowed characters: ");
                char[] alphabet = new char[33];
                int flag = 0;
                for (int i = 0; i < alphabet.Length - 1; i++)
                {
                    if (i == 6)
                    {
                        alphabet[flag++] = (char)0x451;
                    }
                    alphabet[flag++] = (char)(0x430 + i);
                }
                #endregion
                Console.WriteLine(alphabet);

                #region Setting parameters
                Console.WriteLine("Write a string on Russian: ");
                string source = Console.ReadLine().ToLower();
                Console.WriteLine("Write offset: ");
                int count = Convert.ToInt32(Console.ReadLine());
                #endregion

                char[] result = new char[source.Length + 1]; // result string
                int buf;

                #region Algorithm
                for (int i = 0; i < source.Length; i++)
                {
                    if ((buf = source[i]) >= 0x430 && (buf <= 0x44F || buf == 0x451))
                    {
                        if ((source[i]) == 0x451)    // check letter 'ё'
                        {
                            result[i] = alphabet[6 + ((count > 27) ? (count - 33 * (count / 33) - count % 33) : count)];
                        }
                        else if (((buf = source[i] - 0x0430) >= 6) && buf < 32)     // letters from 'ж' to 'я'
                        {
                            result[i] = alphabet[(buf + 1 + count) < 33 ? (buf + 1 + count) : (buf + 1 + count - 33 * (count / 33) - count % 33)];
                        }
                        else        // letters from 'а' to 'е'
                        {
                            if (32 >= (source[i] - 0x0430 + count))
                            {
                                buf = source[i] - 0x0430 + count;
                            }
                            else
                            {
                                buf = source[i] - 0x0430 + count - 33 * (count / 33) - count % 33;
                            }
                            result[i] = alphabet[buf];
                        }
                    }
                    else
                    {
                        throw new Exception("symbol is incorrect " + (char)buf);
                    }
                }
                result[source.Length] = '\0';
                #endregion

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
