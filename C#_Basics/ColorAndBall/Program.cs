namespace ColorAndBall;

class Program {
    public static void Main(string[] args) {
        var redBall = new Ball(10, new Color(255, 0, 0));
        var greenBall = new Ball(15, new Color(0, 255, 0));
        var blueBall = new Ball(20, new Color(0, 0, 255));
        
        Console.WriteLine($"Red ball greyscale: {redBall.Color.GetGrayscale()}");
        Console.WriteLine($"Green ball greyscale: {greenBall.Color.GetGrayscale()}");
        Console.WriteLine($"Blue ball greyscale: {blueBall.Color.GetGrayscale()}");
        
        redBall.Throw();
        redBall.Throw();
        greenBall.Throw();
        
        blueBall.Pop();
        blueBall.Throw();
        
        Console.WriteLine($"Red ball thrown: {redBall.GetThrowCount()} times");
        Console.WriteLine($"Green ball thrown: {greenBall.GetThrowCount()} times");
        Console.WriteLine($"Blue ball thrown: {blueBall.GetThrowCount()} times");
    }
}