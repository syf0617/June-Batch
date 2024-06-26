DateTime birthDate = new DateTime(2000,01, 01); 

DateTime today = DateTime.Today;
int daysOld = (today - birthDate).Days;

int daysToNextAnniversary = 10000 - (daysOld % 10000);

Console.WriteLine($"You are {daysOld} days old.");

DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);
Console.WriteLine($"Your next 10,000 day anniversary will be on {nextAnniversary.ToShortDateString()}.");