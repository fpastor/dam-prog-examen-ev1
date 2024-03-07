namespace Evaluacion1
{
    internal class Stadistics
    {
        public enum RangoType
        {
            EST_NOTA_MED_MAYOR_9,
            EST_NOTA_MED_ENTRE_7_Y_9,
            EST_NOTA_MED_ENTRE_5_Y_7,
            EST_NOTA_MED_ENTRE_3_Y_5,
            EST_NOTA_MED_ENTRE_0_Y_3,
        }

        public static double GetAverageIMC(List<Student> students)
        {
            double sumIMC = 0;
            for(int i = 0; i < students.Count; i++)
                sumIMC += students[i].GetIMC();
            return sumIMC / students.Count;
        }

        public static Student GetBestStudent(List<Student> students)
        {
            Student bestStudent = students[0];
            for (int i = 1; i < students.Count; i++)
            {
                if(students[i].GetAverage() > bestStudent.GetAverage())
                    bestStudent = students[i];
            }
            return bestStudent;
        }

        public static Student GetYoungestStudent(List<Student> students)
        {
            Student youngestStudent = students[0];
            for (int i = 1; i < students.Count; i++)
            {
                if (students[i].GetAge() > youngestStudent.GetAge())
                    youngestStudent = students[i];
            }
            return youngestStudent;
        }

        public static List<Student> GetSortedStudentsForSignature(List<Student> students, SubjectType subject)
        {
            List<Student> studentsSortByMarks = Classroom.Clone(students);
            
            for (int i = 0; i < studentsSortByMarks.Count - 1; i++)
            {
                if (studentsSortByMarks[i + 1].GetNotes().GetQualificationForSignature(subject) > studentsSortByMarks[i].GetNotes().GetQualificationForSignature(subject))
                    Swap(studentsSortByMarks[i + 1], studentsSortByMarks[i]);
            }
            return studentsSortByMarks;
        }

        public List<Student> GetStudentsWithGender(GenderType gender, List<Student> students)
        {
            List<Student> studentsWithGender = new List<Student>();

            for (int i = 0; i < students.Count - 1; i++)
            {
                if(students[i].GetGender() == gender)
                    studentsWithGender.Add(students[i]);
            }
            return SortStudentByAge(studentsWithGender);
        }

        public static Dictionary<RangoType, int> GetStadistics(List<Student> students)
        {
            int studentsPlus9 = 0;
            int students7to9 = 0;
            int students5to7 = 0;
            int students3to5 = 0;
            int students0to3 = 0;

            Dictionary<RangoType, int> stadistics = new Dictionary<RangoType, int>();

            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].GetAverage() > 9)
                    studentsPlus9++;

                if (7 < students[i].GetAverage() && students[i].GetAverage() <= 9)
                    students7to9++;

                if (5 < students[i].GetAverage() && students[i].GetAverage() <= 7)
                    students5to7++;

                if (3 < students[i].GetAverage() && students[i].GetAverage() <= 5)
                    students3to5++;

                if (0 <= students[i].GetAverage() && students[i].GetAverage() <= 3)
                    students0to3++;
            }

            stadistics.Add(RangoType.EST_NOTA_MED_MAYOR_9, studentsPlus9);
            stadistics.Add(RangoType.EST_NOTA_MED_ENTRE_7_Y_9, students7to9);
            stadistics.Add(RangoType.EST_NOTA_MED_ENTRE_5_Y_7, students5to7);
            stadistics.Add(RangoType.EST_NOTA_MED_ENTRE_3_Y_5, students3to5);
            stadistics.Add(RangoType.EST_NOTA_MED_ENTRE_0_Y_3, students0to3);

            return stadistics;
        }

        public static List<Student> SortStudentByAge(List<Student> students)
        {
            List<Student> sortedByAgeStudents = Classroom.Clone(students);

            for (int i = 0; i < students.Count - 1; i++)
            {
                if (sortedByAgeStudents[i + 1].GetAge() > sortedByAgeStudents[i].GetAge())
                    Swap(sortedByAgeStudents[i + 1], sortedByAgeStudents[i]);
            }
            return sortedByAgeStudents;
        }

        public static void Swap(Student student1, Student student2)
        {
            Student aux = new Student(student1.GetStudentName(),student1.GetAge(), student1.GetGender(), student1.GetHeight(), student1.GetWeight(), student1.GetNotes());

            student2.SetStudentName(student1.GetStudentName());
            student2.SetAge(student1.GetAge());
            student2.SetGender(student1.GetGender());
            student2.SetHeight(student1.GetHeight());
            student2.SetWeight(student1.GetWeight());
            student2.SetNotes(student1.GetNotes());

            student1.SetStudentName(aux.GetStudentName());
            student1.SetAge(aux.GetAge());
            student1.SetGender(aux.GetGender());
            student1.SetHeight(aux.GetHeight());
            student1.SetWeight(aux.GetWeight());
            student1.SetNotes(aux.GetNotes());
        }

    }
}
