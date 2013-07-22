//You are given an array of strings. 
// Write a method that sorts the array by the length of its elements 
// (the number of characters composing them).

using System;
class ArrayOfStrings
{

    static void Swap(string[] arr, int i, int j)
    {
        string t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static int Partition(string[] arr, int l, int r)
    {
        Swap(arr, new Random().Next(l, r + 1), r);
        int pivot = arr[r].Length, i = l;

        for (int j = l; j < r; j++) if (arr[j].Length <= pivot) Swap(arr, i++, j);
        Swap(arr, i, r);

        return i;
    }

    static void QuickSort(string[] arr, int l, int r)
    {
        if (l >= r) return;

        int q = Partition(arr, l, r);

        QuickSort(arr, l, q - 1);
        QuickSort(arr, q + 1, r);
    }

    static void Main()
    {
        string[] arr = {"i Pesho Kocakov,", "i Gosho,", "i Atanas,", "Az", "i Saschka,", "i Nemeca,", "i Gosho Pozharnikarcheto", "shte piem bira po cyal den!:)"};

        QuickSort(arr, 0, arr.Length - 1);

        foreach (string item in arr) 
            Console.WriteLine(item);
    }
}
    
