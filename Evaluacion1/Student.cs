namespace Evaluacion1
{
    public enum GenderType
    {
        MALE,
        FEMALE,
        OTHER
    }

    internal class Student
    {
        private string _studentName;
        private int _age;
        private GenderType _gender;
        private double _height;
        private double _weight;
        private Notes _notes;

        public Student()
        {
        }

        public Student(string studentName, int age)
        {
            _studentName = studentName;
            _age = age;
        }

        public Student(string studentName, int age, GenderType gender, double height, double weight, Notes notes)
        {
            _studentName = studentName;
            _age = age;
            _gender = gender;
            _height = height;
            _weight = weight;
            _notes = notes;
        }

        public void SetStudentName(string studentName) { _studentName = studentName; }

        public void SetAge(int age) { _age = age; }

        public void SetGender(GenderType gender) { _gender = gender; }

        public void SetHeight(double height) { _height = height; }

        public void SetWeight(double weight) { _weight = weight; }

        public void SetNotes(Notes notes) { _notes = notes; }

        public string GetStudentName() { return _studentName; }

        public int GetAge() { return _age; }

        public GenderType GetGender() { return _gender; }

        public double GetHeight() { return _height; }

        public double GetWeight() { return _weight; }

        public Notes GetNotes() { return _notes; }

        public double GetIMC() { return _weight / (_height * _height); }

        public double GetAverage() { return _notes.GetQualificationAverage(); }

        public static Student Clone(Student student)
        {
            Student cloneStudent = new Student(student.GetStudentName(), student.GetAge(), student.GetGender(), student.GetHeight(), student.GetWeight(), student.GetNotes().Clone());
            return cloneStudent;
        }

        public string GetName()
        {
            return _studentName;
        }
        
        public bool IsOver18()
        {
            return _age > 18;
        }

    }
}
