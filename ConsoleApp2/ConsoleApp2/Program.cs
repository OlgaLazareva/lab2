using System;

namespace Snifor
{
    class Program
    {

        static void Main(string[] args)
        {

            string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIKLMNOPQRSTVXYZabcdefghiklmnopqrstvxyz.,!?-";
            do
            {
                switch (menu())
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите сообщение: ");
                        string original_message = Console.ReadLine();
                        //Переменная выбора шифрования/дешифрования
                        Console.Write("Введите ключ: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        // если ключ не больше ,чем кол-во букв в алфавите,то вывод зашифрованного сообщения ,иначе ошибка 
                        // Вывод на экран шифрованной строки
                        Console.WriteLine("Зашифрованное сообщение: " + encryption(original_message, Alphabet, key));
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Зашифрованноe сообщение: ");
                        string encrypted_message = Console.ReadLine();
                        deshift(encrypted_message, Alphabet); //вызов функции шифрования 
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка!");
                        break;
                }
                Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                Console.ReadLine();
            }
            while (true);

        }
        static string encryption(string message, string alphabet, int key)
        {
            string result = "";
            //Строка - результат шифрования/дешифрования
            int m = alphabet.Length;
            key = key % m;
            //Цикл по каждому символу строки
            for (int i = 0; i < message.Length; i++)
            {
                if (alphabet.IndexOf(message[i]) > -1)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (message[i] == alphabet[j])
                        {
                            int temp = (j + key) % m;
                            result = result + alphabet[temp];
                        }
                    }
                }
                else
                    result = result + message[i];
            }
            return result;
        }

        static void deshift(string message, string alphabet)
        {
            string result;
            int m = alphabet.Length;
            int key = 0;
            Console.WriteLine();

            do
            {
                result = "";
                //Строка - результат шифрования/дешифрования
                // Выполение дешифрования
                //Цикл по каждому символу строки
                for (int i = 0; i < message.Length; i++)
                {
                    //если
                    if (alphabet.IndexOf(message[i]) > -1)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (message[i] == alphabet[j])
                            {
                                int temp = (j - key + m) % m;
                                result = result + alphabet[temp];
                            }
                        }
                    }//Добавление в строку результатов символ 
                    else
                        result = result + message[i];
                }
                //Вывод на экран дешифрованной строки
                Console.WriteLine("Ключ{0}  {1}", key, result);
                key = key + 1;
            } while (key <= alphabet.Length);
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Шифрование");
            Console.WriteLine("2. Дешифрование");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
            string s = Console.ReadLine(); ////Считывание переменной выбора
            int key = Convert.ToInt32(s); // ключ(сдвиг) к слову дожен быть не больше ,чем колличество букв в алфавите 
            return key;
        }

    }
}