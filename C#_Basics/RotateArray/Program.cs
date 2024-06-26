Console.WriteLine("Enter the array elements separated by space:");
int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());

int n = array.Length;
int[] sumArray = new int[n];

for (int r = 1; r <= k; r++) {
    int[] rotatedArray = new int[n];
    for (int i = 0; i < n; i++) {
        rotatedArray[(i + r) % n] = array[i];
    }
    
    for (int i = 0; i < n; i++) {
        sumArray[i] += rotatedArray[i];
    }
}

Console.WriteLine("Sum array:");
Console.WriteLine(string.Join(" ", sumArray));