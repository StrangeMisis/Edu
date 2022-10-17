namespace Laboratory;

public class SimpleArrays
{
    public static void Simplearrays()
    {
        Console.Write("Введите количество элементов массива ==> ");
        int amount = int.Parse(Console.ReadLine());
        int[] arr = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            Console.Write($"Введите {i+1}-ый элемент массива ==> ");
            arr[i] = int.Parse(Console.ReadLine());

        }

        foreach (var i in arr)
        {
            Console.Write($" {i}");
        }
    }
}