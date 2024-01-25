using Newtonsoft.Json;
using System.IO;
using Transposition.Core.Models;

namespace Transposition.Core.Extensions
{
    public static class FileExtension
    {
        public static NotesToTranspose GetNotesToTransponseFromJson(string path)
        {
            string inputFilePath = $"{Directory.GetCurrentDirectory()}{path}";
            try
            {
                string jsonContent = File.ReadAllText(inputFilePath);
                NotesToTranspose notesToTranspose = JsonConvert.DeserializeObject<NotesToTranspose>(jsonContent);
                return notesToTranspose;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error during file reading: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return null;
        }

        public static void WriteTransponsedNotesToJson(this List<Note> transposedNotes, string outputPath)
        {
            string outputFilePath = $"{Directory.GetCurrentDirectory()}{outputPath}";
            string jsonContent = JsonConvert.SerializeObject(transposedNotes, Formatting.Indented);
            File.WriteAllText(outputFilePath, jsonContent);
        }
    }
}
