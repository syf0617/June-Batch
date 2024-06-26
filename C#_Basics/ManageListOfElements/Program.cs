List<string> itemList = new List<string>();

while (true) { 
    Console.WriteLine("Current List:");
    
    if (itemList.Count == 0) { 
        Console.WriteLine("[List is empty]");
    }else{ 
        foreach (string item in itemList) { 
            Console.WriteLine(item); 
        } 
    } 
    
    Console.WriteLine("Enter command (+ item, - item, or -- to clear):"); 
    string input = Console.ReadLine().Trim();


    if (input.StartsWith("+"))
    {
        if (input.Length > 2 && !string.IsNullOrWhiteSpace(input.Substring(2)))
        {
            itemList.Add(input.Substring(2).Trim());
            Console.WriteLine("Item added.");
        }
        else
        {
            Console.WriteLine("Invalid command. No item specified to add.");
        }
    }else if (input.StartsWith("-")){
        if (input == "--"){
            itemList.Clear();
            Console.WriteLine("List cleared.");
        }else if (input.Length > 2 && itemList.Count > 0){ 
            string itemToRemove = input.Substring(2).Trim();
            if (itemList.Contains(itemToRemove)) { 
                itemList.Remove(itemToRemove);
                Console.WriteLine("Item removed.");
            }else{
                Console.WriteLine("Item not found.");
            }
        }else{
            Console.WriteLine("Invalid command. No item specified to remove or list is empty.");
        } 
    }else{
        Console.WriteLine("Invalid command. Please enter a valid command.");
    }
    Console.WriteLine();
}