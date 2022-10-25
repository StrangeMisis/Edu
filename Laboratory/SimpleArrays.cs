using System.Runtime.InteropServices;

namespace Laboratory;

public class SimpleArrays
{
    public static void Task1()
    {
        Console.WriteLine("Введите массив: ");
        var arr = ReadArrayD1();
        WriteArrayD1(arr);
        MinMaxArray(arr);
        var mode = GetMode();
        if (!mode)
        {
            Mode2(arr);
        }
        else
        {
            Mode1(arr);
        }
    }

    public static void Task1T()
    {
        Console.WriteLine("Введите массив: ");
        var arr = ReadArrayD1T();
        WriteArrayD1(arr);
    }

    public static void Task2()
    {
        var arr = ReadArrayD2();
        WriteArrayD2(arr);
        MinMaxArrayD2(arr);
        arr = ReadArrayD2();
        WriteArrayD2(arr);
    }

    public static void Task3()
    {
        var arr = ReadArrayDS();
    }

    private static int[][] ReadArrayDS()
    {
        Console.WriteLine("Введите количество строк массива");
        var size = Convert.ToInt32(Console.ReadLine());
        int[][] arr = new int[size][];
        for (int i = 0; i < size; i++)
        {
            arr[i] = ReadArrayD1();
        }

        return arr;
    }

    public static int[,] ReadArrayD2()
    {
        Console.WriteLine("Введите размерность массива");
        var size = ReadArrayD1();
        if (size.Length != 2)
        {
            Console.WriteLine("Вы ввели неверную размерность");
            Environment.Exit(3);
        }

        Console.WriteLine("Введите двумерный массив: ");

        var arr2 = new int[size[0], size[1]];
        for (int i = 0; i < size[0]; i++)
        {
            var temp = ReadArrayD1();
            if (temp.Length == size[1])
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    arr2[i, j] = temp[j];
                }
            }
            else
            {
                Console.WriteLine("Вы ввели количество элементов, не соответствующее указанному");
                Environment.Exit(4);
            }
        }

        return arr2;
    }

    public static void WriteArrayD2(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]} ");
            }

            Console.WriteLine();
        }
    }

    public static void MinMaxArrayD2(int[,] arr)
    {
        var max = arr[0, 0];
        var min = arr[0, 0];
        var iMax = "0 0";
        var iMin = "0 0";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (max < arr[i, j])
                {
                    max = arr[i, j];
                    iMax = $"{i} {j}";
                }

                if (min > arr[i, j])
                {
                    min = arr[i, j];
                    iMin = $"{i} {j}";
                }
            }
        }

        Console.WriteLine($"Max = {max}, num = {iMax} | Min = {min}, num = {iMin}");
    }

    public static void Mode1(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        WriteArrayD1(array);
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        WriteArrayD1(array);
    }

    public static void Mode2(int[] array)
    {
        Array.Sort(array);
        WriteArrayD1(array);
        Array.Reverse(array);
        WriteArrayD1(array);
    }

    public static bool GetMode()
    {
        Console.Write("Выберите режим работы программы - a или b: ");
        var choice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (choice)
        {
            case 'a':
                return true;
            case 'b':
                return false;
            default:
                Console.WriteLine("Режим не выбран, заканчиваю работу");
                Environment.Exit(2);
                break;
        }

        return true;

    }

    public static void WriteArrayD1(int[] a)
    {
        Console.WriteLine($"{string.Join(" ", a)}");
    }

    public static void MinMaxArray(int[] a)
    {
        var max = a[0];
        var min = a[0];
        var iMax = 0;
        var iMin = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
                iMax = i;
            }

            if (a[i] < min)
            {
                min = a[i];
                iMin = i;
            }
        }

        Console.WriteLine($"Max = {max}, num = {iMax} | Min = {min}, num = {iMin}");
    }

    public static int[] ReadArrayD1()
    {
        var stroke = Console.ReadLine();
        var strokearr = stroke.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var array = new int[strokearr.Length];
        for (int i = 0; i < strokearr.Length; i++)
        {
            if (!int.TryParse(strokearr[i], out array[i]))
            {
                Console.WriteLine("Вы ввели неверное значение элемента массива");
                Environment.Exit(1);
            }
        }

        return array;
    }

    public static int[] ReadArrayD1T()
    {
        string stroke;
        string[] strokearr;
        int[] array;
        var error = true;
        do
        {
            stroke = Console.ReadLine();
            strokearr = stroke.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            array = new int[strokearr.Length];
            var flag = true;
            for (int i = 0; i < strokearr.Length; i++)
            {
                if (!int.TryParse(strokearr[i], out array[i]))
                {
                    Console.WriteLine("Вы ввели неверное значение элемента массива");
                    error = false;
                }
            }
            return array;
        }
        while (error) ;
    }
}

