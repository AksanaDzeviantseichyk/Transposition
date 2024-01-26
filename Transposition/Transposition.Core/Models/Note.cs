using Newtonsoft.Json;

namespace Transposition.Core.Models
{
    public class Note
    {
        private const int MinOctave = -3;
        private const int MaxOctave = 5;
        private const int MinNote = 1;
        private const int MaxNotesInFullOctave = 12;
        private const int NotesInPartialOctaveLower = 10;
        private const int NotesInPartialOctaveUpper = 1;

        private int octaveNumber;
        private int noteNumber;

        [JsonProperty("octaveNumber")]
        public int OctaveNumber
        {
            get => octaveNumber;
            set => octaveNumber = ValidateOctave(value);
        }

        [JsonProperty("noteNumber")]
        public int NoteNumber
        {
            get => noteNumber;
            set => noteNumber = ValidateNoteNumber(value, OctaveNumber);
        }

        private int ValidateOctave(int value)
        {
            if (value < MinOctave || value > MaxOctave)
            {
                throw new ArgumentOutOfRangeException(nameof(OctaveNumber), 
                    $"Octave must be between {MinOctave} and {MaxOctave}.");
            }
            return value;
        }

        private int ValidateNoteNumber(int value, int octave)
        {
            int maxNotesInOctave = GetMaxNotesInOctave(octave);

            if (value < MinNote || value > maxNotesInOctave)
            {
                throw new ArgumentOutOfRangeException(nameof(NoteNumber),
                    $"NoteNumber must be between {MinNote} and {maxNotesInOctave} for octave {octave}.");
            }
            return value;
        }

        private int GetMaxNotesInOctave(int octave)
        {
            if (octave == -3)
            {
                return NotesInPartialOctaveLower;
            }
            else if (octave == 5)
            {
                return NotesInPartialOctaveUpper;
            }
            else
            {
                return MaxNotesInFullOctave;
            }
        }

        public static Note FromArray(int[] array)
        {
            if (array == null || array.Length != 2)
            {
                throw new ArgumentException("Invalid array for Note deserialization.");
            }

            return new Note
            {
                OctaveNumber = array[0],
                NoteNumber = array[1]
            };
        }
    }
}
