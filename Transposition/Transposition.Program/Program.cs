using Transposition.Core;
using Transposition.Core.Extensions;

class Program
{
    static void Main(string[] args)
    {
        String answer;
        do
        {
            Console.WriteLine("Enter a path to the input json file to transponse:");
            var inputFilePath = Console.ReadLine();

            var notesToTransponse = FileExtension.GetNotesToTransponseFromJson(inputFilePath);
            var transponsedNotes = notesToTransponse.GetTransponsedNotes();

            Console.WriteLine("Enter a path to the output json file:");
            var outputFilePath = Console.ReadLine();
            transponsedNotes.WriteTransponsedNotesToJson(outputFilePath);

            Console.WriteLine("Do you want to repeat (YES/NO)? If YES enter Y:");
            answer = Console.ReadLine().ToUpper();

        } while (answer == "Y");
    }
}