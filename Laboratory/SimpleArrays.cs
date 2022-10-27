namespace Laboratory;

public class SimpleArrays
{
    public static void StartMenu()
    {
        //Просим пользователя ввести задачу
        Mode taskMode;
        do
        {
            taskMode = GetTaskMode();
        }
        while (Mode.ErrorMode == taskMode);
        
        //Просим пользователя ввести режим чтения
        Mode readMode;
        do
        {
            readMode = GetReadMode();
        }
        while (Mode.ErrorMode == readMode);

        switch (taskMode)
        {
            case Mode.Task1:
                Task1();
                break;
            case Mode.Task2:
                Task2();
                break;
            case Mode.Task3:
                Task3();
                break;
        }
    }

    public static void Task1()
    {
        Console.WriteLine("Введите массив: ");
        var arr = ReadArrayD1Repeatedly();
        WriteArrayD1(arr);
        MinMaxArray(arr);
        Mode mode;
        do
        {
            mode = GetSortMode();
        } while (Mode.ErrorMode == mode);

        switch (mode)
        {
            case Mode.MySortMode:
                MySort(arr);
                break;
            case Mode.LibrarySortMode:
                LibrarySort(arr);
                break;
        }
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
        WriteArrayDS(arr);
        MinMaxArrayDS(arr);
        GenerateRandomElementInArrayDS(arr);
        WriteArrayDS(arr);

    }

    private static int[][] ReadArrayDS()
    {
        Console.WriteLine("Введите количество строк массива");
        int size;
        while (!int.TryParse(Console.ReadLine(), out size))
        {
            Console.WriteLine("Неверно заданное количество строк, повторите ввод");
        }

        int[][] arr = new int[size][];
        for (int i = 0; i < size; i++)
        {
            arr[i] = ReadArrayD1Repeatedly();
        }

        return arr;
    }

    public static void WriteArrayDS(int[][] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            WriteArrayD1(arr[i]);
        }
    }

    public static void GenerateRandomElementInArrayDS(int[][] arr)
    {
        Console.WriteLine("Введите индекс элемента");
        int[] indexes;
        do
        {
            indexes = ReadArrayD1Repeatedly();
            if (indexes.Length != 2 || (indexes[0] < 0 || indexes[1] < 0) || indexes[0] >= arr.Length || indexes[1] >= arr[indexes[0]].Length)
            {
                Console.WriteLine("Вы ввели неверный индекс, повторите ввод");
            }
        } 
        while (indexes.Length != 2 || (indexes[0] < 0 || indexes[1] < 0) || indexes[0] >= arr.Length || indexes[1] >= arr[indexes[0]].Length);

        var randomElement = new Random();
        arr[indexes[0]][indexes[1]] = randomElement.Next();
    }

    public static void MinMaxArrayDS(int[][] arr)
    {
        var max = arr[0][0];
        var min = arr[0][0];
        var iMax = "0 0";
        var iMin = "0 0";
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (max < arr[i][j])
                {
                    max = arr[i][j];
                    iMax = $"{i} {j}";
                }

                if (min > arr[i][j])
                {
                    min = arr[i][j];
                    iMin = $"{i} {j}";
                }
            }
        }

        Console.WriteLine($"Max = {max}, num = {iMax} | Min = {min}, num = {iMin}");
    }

    public static int[,] ReadArrayD2()
    {
        Console.WriteLine("Введите размерность массива");
        int[] size;
        do
        {
            size = ReadArrayD1Repeatedly();
            if (size.Length != 2)
            {
                Console.WriteLine("Вы ввели неверную размерность массива, повторите ввод");
            }
        } 
        while (size.Length != 2);

        Console.WriteLine("Введите двумерный массив: ");

        var arr2 = new int[size[0], size[1]];
        
        //Цикл по строкам
        for (int i = 0; i < size[0]; i++)
        {
            int[] stroke;
            
            //Цикл для проверки размерности строки
            do
            {
                stroke = ReadArrayD1Repeatedly();
                if (stroke.Length != size[1])
                {
                    Console.WriteLine("Вы ввели количество элементов, не соответствующее указанному");
                }
            } while (stroke.Length != size[1]);
            
            //Цикл по элементам строки
            for (int j = 0; j < stroke.Length; j++)
            {
                arr2[i, j] = stroke[j];
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

    public static void MySort(int[] array)
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

    public static void LibrarySort(int[] array)
    {
        Array.Sort(array);
        WriteArrayD1(array);
        Array.Reverse(array);
        WriteArrayD1(array);
    }

    public static Mode GetSortMode()
    {
        Console.WriteLine("Выберите режим работы программы - a или b: ");
        var choice = Console.ReadKey().KeyChar;
        Console.WriteLine();
        switch (choice)
        {
            case 'a':
                return Mode.MySortMode;
            case 'b':
                return Mode.LibrarySortMode;
            default:
                return Mode.ErrorMode;
        }
    }
    
    public static Mode GetReadMode()
    {
        Console.WriteLine("Выберите режим чтения из консоли или файла - kb или fl: ");
        var choice = Console.ReadLine();
        if (choice == null)
        {
            return Mode.ErrorMode;
        }
        switch (choice)
        {
            case "kb":
                return Mode.ConsoleMode;
            case "fl":
                return Mode.FileMode;
            default:
                return Mode.ErrorMode;
        }
    }
    
    public static Mode GetTaskMode()
    {
        Console.WriteLine("Выберите задание: t1, t2 или t3");
        var choice = Console.ReadLine();
        if (choice == null)
        {
            return Mode.ErrorMode;
        }
        switch (choice)
        {
            case "t1":
                return Mode.Task1;
            case "t2":
                return Mode.Task2;
            case "t3":
                return Mode.Task3;
            default:
                return Mode.ErrorMode;
        }
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
                Environment.Exit(1);
            }
        }

        return array;
    }

    public static int[] ReadArrayD1Repeatedly()
    {
        string stroke;
        string[] strokearr;
        int[] array;
        bool error;
        do
        {
            error = false;
            stroke = Console.ReadLine();
            strokearr = stroke.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            array = new int[strokearr.Length];
            for (int i = 0; i < strokearr.Length; i++)
            {
                if (!int.TryParse(strokearr[i], out array[i]))
                {
                    error = true;
                }
            }

            if (error)
            {
                Console.WriteLine("Вы ввели неверное значение массива, повторите ввод");
            }
        }
        while (error);
        return array;
    }
}

