int[] initialArray = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

int[] copiedArray = new int[initialArray.Length];

for (int i = 0; i < initialArray.Length; i++){
    copiedArray[i] = initialArray[i];
}

Console.WriteLine("Initial Array:");

foreach (int item in initialArray) {
    Console.Write(item + " ");
}

Console.WriteLine();

Console.WriteLine("Copied Array:");

foreach (int item in copiedArray){
    Console.Write(item + " ");
}

Console.WriteLine();