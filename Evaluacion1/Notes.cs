namespace Evaluacion1
{
    public enum SubjectType
    {
        MATHS,
        SCIENCE,
        HISTORY,
        LANGUAGE,
        UNKNOWN
    }

    public class Notes
    {
        private List<double> _notes = new List<double>();

        public Notes()
        {
        }

        public double GetQualificationForSignature(SubjectType subject)
        {
            return _notes[(int)subject];
        }

        public void SetQualificationForSignature(SubjectType subject, int value)
        {
            _notes[(int)subject] = value;
        }

        public double GetQualificationAverage()
        {
            int lastSubject = (int)SubjectType.UNKNOWN - 1;
            double notesSum = 0;

            for (int i = 0; i <= lastSubject; i++)
            {
                notesSum += _notes[i];
            }

            return notesSum / (int)SubjectType.UNKNOWN;
        }

        public SubjectType GetHightestMarkSubject()
        {
            int lastSubject = (int)SubjectType.UNKNOWN - 1;

            int higherPosition = 0;
            for (int i = 0; i <= lastSubject - 1; i++)
            {
                if (_notes[i + 1] > _notes[i])
                    higherPosition = i;
            }
            return (SubjectType)higherPosition;
        }

        public SubjectType GetLowestMarkSubject()
        {
            int lastSubject = (int)SubjectType.UNKNOWN - 1;

            int lowerPosition = 0;
            for (int i = 0; i <= lastSubject - 1; i++)
            {
                if (_notes[i + 1] < _notes[i])
                    lowerPosition = i;
            }
            return (SubjectType)lowerPosition;
        }

        public double GetLowestMark()
        {
            int lastSubject = (int)SubjectType.UNKNOWN - 1;
            double lowestMark = _notes[0];
            for (int i = 0; i <= lastSubject - 1; i++)
            {
                if (_notes[i + 1] < _notes[i])
                    lowestMark = _notes[i + 1];
            }
            return lowestMark;
        }

        public double GetHighestMark()
        {
            int lastSubject = (int)SubjectType.UNKNOWN - 1;
            double highestMark = _notes[0];
            for (int i = 0; i <= lastSubject - 1; i++)
            {
                if (_notes[i + 1] > _notes[i])
                    highestMark = _notes[i + 1];
            }
            return highestMark;
        }

        public static Notes Clone(Notes notes)
        {
            Notes cloneNotes = new Notes();
            for (int i = 0; i < notes._notes.Count; i++)
                cloneNotes._notes[i] = notes._notes[i];
            return cloneNotes;
        }

        public Notes Clone()
        {
            return Clone(this);
        }

    }
}


