Console.WriteLine("Enter the array elements separated by space:");
int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

int bestStart = 0;
int bestLength = 1;
int currentStart = 0;
int currentLength = 1;

for (int i = 1; i < array.Length; i++) {
    if (array[i] == array[i - 1]) {
        currentLength++;
    }else{
        if (currentLength > bestLength){
            bestLength = currentLength;
            bestStart = currentStart;
        }
        
        currentStart = i;
        currentLength = 1;
    }
}

if (currentLength > bestLength) {
    bestLength = currentLength;
    bestStart = currentStart;
}

int[] result = new int[bestLength];
for (int i = 0; i < bestLength; i++) {
    result[i] = array[bestStart + i];
}

Console.WriteLine("The longest sequence of equal elements:");
Console.WriteLine(string.Join(" ", result));