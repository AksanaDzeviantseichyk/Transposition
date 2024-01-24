using Newtonsoft.Json;

namespace Transposition.Core.Models
{
    public class NotesToTranspose
    {
        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("numberSemitones")]
        public int NumberSemitones { get; set; }
    }
}
