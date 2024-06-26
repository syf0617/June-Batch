for (int increment = 1; increment <= 4; increment++) {
    for (int i = 0; i <= 24; i += increment) {
        Console.Write(i != 24 ? $"{i}," : $"{i}");
    }

    Console.WriteLine();
}