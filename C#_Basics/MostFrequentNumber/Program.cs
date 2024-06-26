Console.WriteLine("Enter the sequence of numbers separated by space:");
int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Dictionary<int, int> frequency = new Dictionary<int, int>();
Dictionary<int, int> firstAppearance = new Dictionary<int, int>();

for (int i = 0; i < numbers.Length; i++) {
    int number = numbers[i];
    if (!frequency.ContainsKey(number)) {
        frequency[number] = 1;
        firstAppearance[number] = i;
    }else {
        frequency[number]++;
    }
}

int maxFrequency = frequency.Values.Max();

var mostFrequentNumbers = frequency.Where(f => f.Value == maxFrequency)
    .Select(f => f.Key)
    .OrderBy(n => n)
    .ToList();

int leftmostNumber = mostFrequentNumbers.OrderBy(n => firstAppearance[n]).First();

if (mostFrequentNumbers.Count == 1) {
    Console.WriteLine($"The number {mostFrequentNumbers.First()} is the most frequent (occurs {maxFrequency} times)");
}else {
    string numbersList = string.Join(", ", mostFrequentNumbers);
    Console.WriteLine($"The numbers {numbersList} have the same maximal frequency (each occurs {maxFrequency} times). The leftmost of them is {leftmostNumber}.");
}