using NUnit.Framework;
using Transposition.Core;
using Transposition.Core.Extensions;

namespace Transposition.Tests
{
    public class TranspositionUnitTests
    {
        [TestCase("\\TestData\\test1.json")]
        public void Test1(string path)
        {
            var notesToTransponse = FileExtension.GetNotesToTransponseFromJson(path);
            var transponsedNotes = notesToTransponse.GetTransponsedNotes();
            transponsedNotes.WriteTransponsedNotesToJson("\\TestData\\outputTest1.json");
            Assert.Pass();
        }
    }
}