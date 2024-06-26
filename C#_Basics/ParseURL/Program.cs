using System.Text.RegularExpressions;

Console.WriteLine("Enter URL:");
string input = Console.ReadLine();

ParseUrl(input);

static void ParseUrl(string url) {
    Regex regex = new Regex(@"^(?:([^:/?#]+):)?(?://)?([^/?#]+)([^?#]*)$");
    Match match = regex.Match(url);

    if (match.Success) {
        string protocol = match.Groups[1].Value;
        string server = match.Groups[2].Value;
        string resource = match.Groups[3].Value.TrimStart('/');

        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }else{
        Console.WriteLine("Invalid URL format.");
    }
}