namespace PrintNumbers;
using System;

class Program {
    public static void Main(string[] args) {
        int[] numbers = GenerateNumbers(10);
        Reverse(numbers);
        PrintNumbers(numbers);
    }

    private static int[] GenerateNumbers(int length) {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++) {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    private static void Reverse(int[] array) {
        int temp;
        int length = array.Length;
        for (int i = 0; i < length / 2; i++) {
            temp = array[i];
            array[i] = array[length - i - 1];
            array[length - i - 1] = temp;
        }
    }

    private static void PrintNumbers(int[] array) {
        foreach (int number in array) {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}