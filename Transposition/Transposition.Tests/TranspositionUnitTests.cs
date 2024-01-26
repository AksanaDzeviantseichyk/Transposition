using NUnit.Framework;
using Transposition.Core;
using Transposition.Core.Extensions;

namespace Transposition.Tests
{
    public class TranspositionUnitTests
    {
        [TestCase("\\TestData\\test1.json", "\\TestData\\outputTest1.json")]
        public void Test1(string inputFilePath, string outputFilePath)
        {
            var notesToTransponse = FileExtension.GetNotesToTransponseFromJson($"{Directory.GetCurrentDirectory()}{inputFilePath}");
            var transponsedNotes = notesToTransponse.GetTransponsedNotes();
            transponsedNotes.WriteTransponsedNotesToJson($"{Directory.GetCurrentDirectory()}{outputFilePath}");
            Assert.Pass();
        }
    }
}