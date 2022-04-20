public class Program
{
    public static void Main()
    {
        bool goAgain = true;
        List<string> names = new List<string>() { "Adam", "Ryan", "Dom" };
        List<string> hometown = new List<string>() { "Pinckney", "Ann Arbor", "Dearborn" };
        List<string> favoriteFood = new List<string>() { "sushi", "tacos", "donuts" };
        List<string> favoriteColor = new List<string>() { "blue", "green", "baby blue" };

        while (goAgain)
        {
            int studentNumber;
            int.TryParse(GetUserInput($"Which of our student's information would you like to display? (1-{names.Count})"), out studentNumber);
            
            int index = studentNumber - 1;

            if (studentNumber > names.Count || studentNumber < 1)
            {
                 Console.WriteLine("That is not a student number, please try again.");
                 continue;
            }
            else
            {
                CaseSwitcher(index, names, hometown, favoriteFood, favoriteColor);
            }
         
            Lister(names, hometown, favoriteFood, favoriteColor);

            string allStu = GetUserInput("Would you like to see a list of all students? y/n");
            if (allStu == "y")
            {
                foreach (string stu in names)
                {
                    Console.Write(stu + " ");
                }
            }
            else
            {
                Console.WriteLine("Alright, we'll keep the full list hidden.");
            }

            goAgain = RunAgain();
        }
    }

    public static void Lister(List<string> names, List<string> hometown, List<string> favoriteFood, List<string> favoriteColor)
    {
        Console.WriteLine("Would you like to add another student's information? y/n");
        string input = Console.ReadLine().ToLower();
        if (input == "y" || input == "yes")
        {
            string newName;
            Console.WriteLine("What is the student's name?");
            newName = Console.ReadLine();
            names.Add(newName);

            Console.WriteLine($"What is {newName}'s hometown?");
            hometown.Add(Console.ReadLine());

            Console.WriteLine($"What is {newName}'s favorite food?");
            favoriteFood.Add(Console.ReadLine());

            Console.WriteLine($"What is {newName}'s favorite color?");
            favoriteColor.Add(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("No problem...");
        }
    }

    public static void CaseSwitcher(int index, List<string> names, List<string>hometown, List<string>favoriteFood, List<string>favoriteColor)
    {
        Console.WriteLine($"Student {index + 1}: {names[index]}");
        string info = GetUserInput($"Would you like to display {names[index]}'s hometown, favorite food, or favorite color? \nHit any other key to exit.");
        if (info.ToLower().Contains("home") || info.ToLower().Contains("town"))
        {
            Console.WriteLine($"{names[index]} is from {hometown[index]}.");
        }
        else if (info.ToLower().Contains("food"))
        {
            Console.WriteLine($"{names[index]}'s favorite food is {favoriteFood[index]}.");
        }
        else if (info.ToLower().Contains("color"))
        {
            Console.WriteLine($"{names[index]}'s favorite color is {favoriteColor[index]}.");
        }
        else
        {
            Console.WriteLine("Exiting...");
        }
    }

    public static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine().ToLower();
        return input;
    }

    public static bool RunAgain()
    {
        string answer = GetUserInput("\nWould you like to learn more about another student? y/n ").ToLower();

        if (answer == "y")
        {
            return true;
        }
        else if (answer == "n")
        {
            Console.WriteLine("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("\nI'm sorry, I didn't understand that. \nPlease input y or n\nTry again:");
            return RunAgain();
        }
    }

}