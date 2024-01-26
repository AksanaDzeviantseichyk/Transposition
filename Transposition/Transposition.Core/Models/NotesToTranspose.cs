using Newtonsoft.Json;

namespace Transposition.Core.Models
{
    public class NotesToTranspose
    {
        [JsonProperty("notes")]
        public List<int[]> NoteArray { get; set; }

        [JsonProperty("numberSemitones")]
        public int NumberSemitones { get; set; }

        [JsonIgnore]
        public List<Note> Notes
        {
            get
            {
                return NoteArray.Select(Note.FromArray).ToList();
            }
        }


    }
}
