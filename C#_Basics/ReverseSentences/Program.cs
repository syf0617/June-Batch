using System.Text.RegularExpressions;

Console.WriteLine("Please enter a sentence:");
string input = Console.ReadLine();

if (!string.IsNullOrEmpty(input)){
    string output = ReverseWords(input);
    Console.WriteLine("Reversed sentence:");
    Console.WriteLine(output);
}else {
    Console.WriteLine("No input provided.");
}

static string ReverseWords(string sentence) {
    string pattern = @"([\s.,:;=()\[\]&""'\\/!?]+)"; 
    List<string> parts = new List<string>(Regex.Split(sentence, pattern));
    
    parts.RemoveAll(string.IsNullOrEmpty);
    
    int left = 0;
    int right = parts.Count - 1;

    while (left < right) {
        if (!Regex.IsMatch(parts[left], pattern) && !Regex.IsMatch(parts[right], pattern)) {
            string temp = parts[left];
            parts[left] = parts[right];
            parts[right] = temp;
            left++; 
            right--; 
        }else {
            if (Regex.IsMatch(parts[left], pattern)) {
                left++;
            }
            if (Regex.IsMatch(parts[right], pattern)) {
                right--;
            }
        }
    }
    
    return string.Join("", parts);
}