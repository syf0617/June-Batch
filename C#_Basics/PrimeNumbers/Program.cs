int[] primes = FindPrimesInRange(1, 100);

Console.WriteLine("Prime numbers in the range:");

foreach (int prime in primes){
    Console.Write(prime + "\n");
}

static int[] FindPrimesInRange(int startNum, int endNum) {
    List<int> primesList = new List<int>();
        
    for (int num = startNum; num <= endNum; num++){
        if (IsPrime(num))
        {
            primesList.Add(num);
        }
    }

    return primesList.ToArray();
}

static bool IsPrime(int number) {
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    int boundary = (int)Math.Sqrt(number);

    for (int i = 3; i <= boundary; i += 2) {
        if (number % i == 0)
            return false;
    }

    return true;
}