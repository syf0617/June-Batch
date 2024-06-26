using System.Text.RegularExpressions;

Console.WriteLine("Enter text to find palindromes:");
string input = Console.ReadLine();
Console.WriteLine("Unique sorted palindromes: " + FindAndSortPalindromes(input));

static string FindAndSortPalindromes(string text) {
    var words = Regex.Split(text, @"[\W_]+").Where(w => w != "").ToArray();

    Dictionary<string, List<string>> palindromes = new Dictionary<string, List<string>>();

    foreach (string word in words) {
        if (IsPalindrome(word)){
            string lowercasedWord = word.ToLower();
            if (!palindromes.ContainsKey(lowercasedWord)) {
                palindromes[lowercasedWord] = new List<string> { word };
            }else {
                if (!palindromes[lowercasedWord].Any(p => p.Equals(word, StringComparison.Ordinal))) {
                    palindromes[lowercasedWord].Add(word);
                }
            }
        }
    }
    
    var allPalindromes = palindromes.Values.SelectMany(x => x).Distinct().ToList();
    allPalindromes.Sort(StringComparer.OrdinalIgnoreCase);
    
    return string.Join(", ", allPalindromes);
}

static bool IsPalindrome(string word) {
    int left = 0;
    int right = word.Length - 1;
    while (left < right) {
        if (word[left] != word[right]) {
            return false;
        }
        left++;
        right--;
    }
    return true;
}