int correctNumber = new Random().Next(1, 4);

Console.WriteLine("Guess a number between 1 and 3:");

while (true){
    int guessedNumber = int.Parse(Console.ReadLine());
    
    if (guessedNumber < 1 || guessedNumber > 3){
        Console.WriteLine("Your guess is outside the valid range of numbers. Please guess between 1 and 3.");
    }
    else if (guessedNumber < correctNumber) {
        Console.WriteLine("Your guess is too low.");
    }
    else if (guessedNumber > correctNumber) {
        Console.WriteLine("Your guess is too high.");
    }
    else {
        Console.WriteLine("You guessed correctly!");
        return;
    }
}

Console.ReadKey();