using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;
using Transposition.Core.Models;

namespace Transposition.Core.Extensions
{
    public static class FileExtension
    {
        public static NotesToTranspose GetNotesToTransponseFromJson(string path)
        {
            try
            {
                string jsonContent = File.ReadAllText(path);
                return JsonConvert.DeserializeObject <NotesToTranspose>(jsonContent);

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
            string jsonContent = JsonConvert.SerializeObject(transposedNotes, Formatting.Indented);
            File.WriteAllText(outputPath, jsonContent);
        }
    }
}
