namespace Hjemmet
{
    public class GuessANumber
    {
        public void Start()
        {
            Console.WriteLine("Gæt et tal er ikke implementeret endnu.");

            Random random = new Random();

            int number = random.Next(1, 501);
            int userGuess = 0;
            int attempts = 0;

            while (userGuess != number)
            {
                Console.WriteLine("Indtast dit gæt: ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out userGuess);

                if (!isNumber)
                {
                    Console.WriteLine("Det var ikke et gyldigt tal. prøv igen");
                    continue;
                }

                attempts++;

                if (userGuess < number)
                {
                    Console.WriteLine("For lavt! Prøv et højere tal.");
                }
                else if (userGuess > number) 
                {
                    Console.WriteLine("For Højt! Prøv et lavere tal.");
                }
                else
                {
                    Console.WriteLine($"Tillykke! Du gættede rigtigt på {attempts} forsøg.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Tryk på en tast for at afslutte.");
            Console.ReadKey();



        }
    }
}
