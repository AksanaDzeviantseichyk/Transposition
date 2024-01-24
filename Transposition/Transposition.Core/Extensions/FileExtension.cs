using Newtonsoft.Json;
using Transposition.Core.Models;

namespace Transposition.Core.Extensions
{
    public static class FileExtension
    {
        public static NotesToTranspose GetNotesToFromJson(string path)
        {
            try
            {
                string jsonContent = File.ReadAllText(path);
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
    }
}
