using System.Numerics;

Console.WriteLine("Enter the number of centuries:");
int centuries = int.Parse(Console.ReadLine());

BigInteger years = 100 * centuries;
// Convert the number of years directly to BigInteger before multiplying
BigInteger days = years * 365 + (years / 4) - (years / 100) + (years / 400); // Correct leap year calculation
BigInteger hours = 24 * days;
BigInteger minutes = 60 * hours;
BigInteger seconds = 60 * minutes;
BigInteger milliseconds = 1000 * seconds;
BigInteger microseconds = 1000 * milliseconds;
BigInteger nanoseconds = 1000 * microseconds;

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = " +
                  $"{minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = " +
                  $"{microseconds} microseconds = {nanoseconds} nanoseconds");