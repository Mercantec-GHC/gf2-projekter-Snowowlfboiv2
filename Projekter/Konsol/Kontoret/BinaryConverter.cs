namespace Kontoret
{
    public class BinaryConverter
    {
        public void Start()
        {
            Console.WriteLine("Binærkodeomformer er ikke implementeret endnu.");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            string binary = "";

            if (number >= 128)
            {
                binary += "1";
                number -= 128;
            }
            else
            {
                binary += "0";
            }
            if (number >= 64)
            {
                binary += "1";
                number -= 64;
            }
            else
            {
                binary += "0";
            }
            if (number >= 32)
            {
                binary += "1";
                number -= 32;
            }
            else
            {
                binary += "0";
            }
            if (number >= 16)
            {
                binary += "1";
                number -= 16;
            }
            else
            {
                binary += "0";
            }
            if (number >= 4)
            {
                binary += "1";
                number -= 4;
            }
            else
            {
                binary += "0";
            }
            if (number >= 2)
            {
                binary += "1";
                number -= 2;
            }
            else
            {
                binary += "0";
            }
            if (number >= 1)
            {
                binary += "1";
                number -= 1;
            }
            else
            {
                binary += "0";
            }
        }
    }
}
