using System;
namespace spor_s_Temichem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРАВИЛА ИГРЫ В КОНСОЛЬНЫЕ КРЕСТИКИ/НОЛИКИ:\n");
            Console.WriteLine("Строки: 1, 2, 3; Столбцы: a, b, c. Пример:");
            Console.Write("Ход крестиков: ");
            Console.WriteLine("2b");
            Console.WriteLine("\n   |   |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   | X |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   |   |   \n");

            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();

            char[,] arrayField = 
            {
              {' ', ' ' , ' '},
              {' ', ' ' , ' '},
              {' ', ' ' , ' '},
            };

            fieldVis(arrayField);

            while (true) {
                stepX(arrayField);
                fieldVis(arrayField);

                if (CheckWin(arrayField, 'X'))
                {
                    Console.WriteLine("Победа! Крестики выиграли!");
                    break;
                }
                else if (CheckWin(arrayField, 'O'))
                {
                    Console.WriteLine("Победа! Нолики выиграли!");
                    break;
                }
                else if (CheckDraw(arrayField))
                {
                    Console.WriteLine("Ничья!");
                    break;
                }

                stepO(arrayField);
                fieldVis(arrayField);

                if (CheckWin(arrayField, 'X'))
                {
                    Console.WriteLine("Победа! Крестики выиграли!");
                    break;
                }
                else if (CheckWin(arrayField, 'O'))
                {
                    Console.WriteLine("Победа! Нолики выиграли!");
                    break;
                }
                else if (CheckDraw(arrayField))
                {
                    Console.WriteLine("Ничья!");
                    break;
                }
            }
            Console.ReadKey();
        }

        static void fieldVis(char [,] arr) 
        {
            Console.WriteLine($"\n {arr[0,0]} | {arr[0, 1]} | {arr[0, 2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {arr[1, 0]} | {arr[1, 1]} | {arr[1, 2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {arr[2, 0]} | {arr[2, 1]} | {arr[2, 2]} \n");
        }

        static void stepX(char[,] arr)
        {

            Console.Write("\nХод крестиков: ");
            string step;

            int count = 0;

            do
            {
                if (count > 0)
                {
                    Console.WriteLine("Поле занято!");
                }

                step = Console.ReadLine();
                count++;
            }
            while (isTrue(arr, step));

            switch (step)
            {
                case "1a":
                    arr[0, 0] = 'X';
                    break;
                case "1b":
                    arr[0, 1] = 'X';
                    break;
                case "1c":
                    arr[0, 2] = 'X';
                    break;

                case "2a":
                    arr[1, 0] = 'X';
                    break;
                case "2b":
                    arr[1, 1] = 'X';
                    break;
                case "2c":
                    arr[1, 2] = 'X';
                    break;

                case "3a":
                    arr[2, 0] = 'X';
                    break;
                case "3b":
                    arr[2, 1] = 'X';
                    break;
                case "3c":
                    arr[2, 2] = 'X';
                    break;
            }
            Console.Clear();
        }

        static void stepO(char[,] arr) 
        {
            Console.Write("\nХод нолика: ");
            string step;

            int count = 0;

            do
            {
                if (count > 0)
                {
                    Console.WriteLine("Поле занято!");
                }

                step = Console.ReadLine();
                count++;
            }
            while (isTrue(arr, step));

            switch (step)
            {
                case "1a":
                    arr[0, 0] = 'O';
                    break;
                case "1b":
                    arr[0, 1] = 'O';
                    break;
                case "1c":
                    arr[0, 2] = 'O';
                    break;

                case "2a":
                    arr[1, 0] = 'O';
                    break;
                case "2b":
                    arr[1, 1] = 'O';
                    break;
                case "2c":
                    arr[1, 2] = 'O';
                    break;

                case "3a":
                    arr[2, 0] = 'O';
                    break;
                case "3b":
                    arr[2, 1] = 'O';
                    break;
                case "3c":
                    arr[2, 2] = 'O';
                    break;
            }
            Console.Clear();
        }

        static bool isTrue(char[,] arr, string step)
        {
            switch (step)
            {
                case "1a":
                    return arr[0, 0] != ' ';
                case "1b":
                    return arr[0, 1] != ' ';
                case "1c":
                    return arr[0, 2] != ' ';

                case "2a":
                    return arr[1, 0] != ' ';
                case "2b":
                    return arr[1, 1] != ' ';
                case "2c":
                    return arr[1, 2] != ' ';

                case "3a":
                    return arr[2, 0] != ' ';
                case "3b":
                    return arr[2, 1] != ' ';
                case "3c":
                    return arr[2, 2] != ' ';

                default:
                    return true;
            }
        }

        static bool CheckWin(char[,] arr, char player)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if ((arr[i, 0] == player && arr[i, 1] == player && arr[i, 2] == player) || 
                    (arr[0, i] == player && arr[1, i] == player && arr[2, i] == player))   
                {
                    return true;
                }
            }


            if ((arr[0, 0] == player && arr[1, 1] == player && arr[2, 2] == player) || 
                (arr[0, 2] == player && arr[1, 1] == player && arr[2, 0] == player))   
            {
                return true;
            }
            return false;
        }

        static bool CheckDraw(char[,] arr)
        {
            // Проверяем каждую ячейку поля
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Если находим хотя бы одну пустую ячейку, игра не окончена
                    if (arr[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            // Если все ячейки заняты, но нет победителя, это ничья
            return true;
        }
    }
}
