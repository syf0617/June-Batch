/*int max = 500;
for (byte i = 0; i < max; i++)
{
    WriteLine(i);
}*/

int max = 500;

byte maxByteValue = 255;

if (max > maxByteValue) {
    Console.WriteLine($"Warning: The loop will never terminate because max ({max}) is greater than the maximum byte value ({maxByteValue}).");
    return; // Exit 
}

for (byte i = 0; i < max; i++) {
    Console.WriteLine(i);
}