//Write a program, that reads from the console an array of N integers 
// and an integer K, sorts the array and using the method Array.BinSearch() 
// and finds the largest number in the array which is ≤ K. 


using System;

class Program
{
    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static int Partition(int[] arr, int l, int r)
    {
        Swap(arr, new Random().Next(l, r + 1), r);
        int pivot = arr[r], i = l;

        for (int j = l; j < r; j++) if (arr[j] <= pivot) Swap(arr, i++, j);
        Swap(arr, i, r);

        return i;
    }

    static void QuickSort(int[] arr, int l, int r)
    {
        if (l >= r) return;

        int q = Partition(arr, l, r);

        QuickSort(arr, l, q - 1);
        QuickSort(arr, q + 1, r);
    }

    static int LowerBound(int[] arr, int x)
    {
        int l = 0, r = arr.Length - 1;

        while (l < r)
        {
            int m = l + (r - l + 1) / 2;

            if (arr[m] > x) r = m - 1;
            else l = m;
        }

        if (arr[l] > x) l--;

        return l;
    }

    static void Main()
    {
        // Input
        Console.WriteLine("What is the size of the array?");

        int[] arr = new int[int.Parse(Console.ReadLine())];
        
        Console.WriteLine("Give a value for K");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("Now enter {0} values in order to fill the array",arr.Length);

        for (int i = 0; i < arr.Length; i++) 
        arr[i] = int.Parse(Console.ReadLine());

        // Sort
        QuickSort(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++) 
        Console.Write(arr[i] + (i == arr.Length - 1 ? "\n" : " "));

        // Search
        int index = LowerBound(arr, k);

        // Print
        Console.WriteLine(index);
        if (index != -1) Console.WriteLine(arr[index]);
    }
}
