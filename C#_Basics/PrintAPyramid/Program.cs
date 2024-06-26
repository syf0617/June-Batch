int totalLines = 5;

for (int line = 1; line <= totalLines; line++)
{
    for (int space = totalLines - line; space > 0; space--) {
        Console.Write(" ");
    }
    
    for (int star = 1; star <= 2 * line - 1; star++) {
        Console.Write("*");
    }
    
    Console.WriteLine();
}