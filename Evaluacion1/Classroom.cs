namespace Evaluacion1
{
    internal class Classroom
    {
        private List<Student> _students = new List<Student>();
        private string _classroomName;

        public Classroom()
        {
        }

        public Classroom(List<Student> students)
        {
            List<Student> _students = Clone(students);
        }

        public void SetClassroomName(string name)
        {
            _classroomName = name;
        }

        public string GetClassroomName()
        {
            return _classroomName;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void RemoveStudentAt(int index)
        {
            _students.RemoveAt(index);
        }

        public int ContainsStudentWithName(string name)
        {
            for(int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveStudentWithName(string name)
        {
            _students.RemoveAt(ContainsStudentWithName(name));
        }

        public static List<Student> Clone(List<Student> students)
        {
            List<Student> cloneStudents = new List<Student>();

            for (int i = 0; i < students.Count; i++)
            {
                Student clone = Student.Clone(students[i]);
                cloneStudents.Add(clone);
            }
            return cloneStudents;
        }

    }
}
