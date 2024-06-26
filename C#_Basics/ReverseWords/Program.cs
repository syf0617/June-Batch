Console.WriteLine("Enter a string:");
string input = Console.ReadLine();

// Method 1: char array
char[] charArray = input.ToCharArray();
Array.Reverse(charArray);
string reversedString = new string(charArray);
Console.WriteLine("Reversed using char array: " + reversedString);

// Method 2: for-loop
string reversedUsingLoop = "";
for (int i = input.Length - 1; i >= 0; i--) {
    reversedUsingLoop += input[i];
}
Console.WriteLine("Reversed using loop: " + reversedUsingLoop);