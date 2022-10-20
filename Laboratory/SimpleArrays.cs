using System.Runtime.InteropServices;

namespace Laboratory;

public class SimpleArrays
{
    public static void Task1()
    {
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
                Console.WriteLine("Такого режима нет");
                Environment.Exit(2);
                break;
        }

        return true;

    }

    public static void WriteArrayD1(int[] a)
    {
        Console.WriteLine($"[{string.Join(", ", a)}]");
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
        Console.WriteLine($"Max = {max}, num = {iMax}| Min = {min}, num = {iMin}");
    }

    public static int[] ReadArrayD1()
    {
        Console.WriteLine("Введите массив: ");
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
}

