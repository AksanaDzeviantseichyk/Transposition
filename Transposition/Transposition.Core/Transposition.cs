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
                            OctaveNumber = note.OctaveNumber - 1,
                            NoteNumber = 12 + newNote,
                        });
                }
                else
                {
                    transponsedNotes.Add(
                        new Note
                        {
                            OctaveNumber = note.OctaveNumber + 1,
                            NoteNumber = newNote - 12,
                        });
                }
                
            }
            return transponsedNotes;
        }
    }
}
