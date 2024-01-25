using Transposition.Core.Extensions;

class Program
{
    static void Main(string[] args)
    {
        String answer;
        do
        {
            Console.WriteLine("Enter a path to the json file to transponse:");
            var filePath = Console.ReadLine();

            var notesToTransponse = FileExtension.GetNotesToTransponseFromJson(filePath);

            Console.WriteLine("Do you want to repeat (YES/NO)? If YES enter Y:");
            answer = Console.ReadLine().ToUpper();

        } while (answer == "Y");
    }
}