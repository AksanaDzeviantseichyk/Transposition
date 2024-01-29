using Transposition.Core.Models;

namespace Transposition.Core
{
    public static class Transposition
    {
        public static List<Note> GetTransponsedNotes(this NotesToTranspose notesToTranspose)
        {
            var transponsedNotes = new List<Note>();
            foreach (var note in notesToTranspose.Notes) 
            {
                var newNote = note.NoteNumber + notesToTranspose.NumberSemitones;
                if(newNote>= 1 && newNote <= 12)
                {
                    transponsedNotes.Add(
                        new Note
                        {
                            OctaveNumber = note.OctaveNumber,
                            NoteNumber = newNote,
                        });
                }
                else if(newNote < 1)
                {
                    transponsedNotes.Add(
                        new Note
                        {
                            OctaveNumber = note.OctaveNumber - (Math.Abs(newNote) / 12 + 1),
                            NoteNumber = 12 - Math.Abs(newNote) % 12,
                        });
                }
                else
                {
                    var octave = newNote % 12 == 0 ? note.OctaveNumber + (newNote / 12) - 1 : note.OctaveNumber + newNote / 12;
                    var n = newNote % 12;
                    transponsedNotes.Add(
                        new Note
                        {
                            OctaveNumber = newNote % 12 == 0 ? note.OctaveNumber + (newNote / 12) - 1 : note.OctaveNumber + newNote / 12,
                            NoteNumber = newNote % 12 == 0 ? 12 : newNote % 12,
                        });
                }
                
            }
            return transponsedNotes;
        }
    }
}
