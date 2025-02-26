using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to C# old phone pad calculator");

        Console.WriteLine("Examples:");
        Console.WriteLine($"OldPhonePad(“33#”) => output: {Calculator.OldPhonePad("33#")}");
        Console.WriteLine($"OldPhonePad(“227*#”) => output: {Calculator.OldPhonePad("227*#")}");
        Console.WriteLine($"OldPhonePad(“4433555 555666#”) => output: {Calculator.OldPhonePad("4433555 555666#")}");
        Console.WriteLine($"OldPhonePad(“8 88777444666*664# => output: {Calculator.OldPhonePad("8 88777444666*664#")}\n");

        while (true)
        {
            Console.Write("Enter characters: ");
            string characters = Console.ReadLine();

            if (characters is not null && Calculator.ValidateOldPhonePadInput(characters)) {
              string result = Calculator.OldPhonePad(characters);
              Console.WriteLine($"Result: {result}\n");
            } else {
              Console.WriteLine($"Invalid characters!!");
            }

            Console.Write("Do you want to continue? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;
        }
    }
}