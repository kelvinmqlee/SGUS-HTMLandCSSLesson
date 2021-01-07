using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class BaseModel
    {
        public virtual int id { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastEdit { get; protected set; }
        public abstract bool Validate(); // half-defined
    }

    public class Course : BaseModel
    {
        //public Course()
        //{
        //    Validate();
        //}

        private string _courseName; // variable

        public string courseName
        {
            get { return _courseName; }
            set
            {
                // logic
                _courseName = value;
                lastEdit = DateTime.Now;
                Validate();
            }
        }

        // Aggregation
        public List<Student> students { get; set; } = new List<Student>();

        public double CalculateAverage()
        {
            if (students.Count == 0)
            {
                return 0; // to avoid dividing by zero exception
            }
            int totalmarks = 0;
            foreach (Student stud in students)
            {
                totalmarks = stud.marks + totalmarks;
            }
            return (totalmarks / students.Count);
        }

        public override bool Validate() // do in one go
        {
            if (courseName.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class Student : BaseModel
    {
        //public Student()
        //{
        //    Validate();
        //}

        private string _studentName; // variable
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private string _csName;
        public string csName
        {
            get { return _csName; }
            set { _csName = value; }
        }

        private int _marks;
        public int marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        private string _grade;
        public string grade
        {
            get { return _grade.ToUpper(); }
            set { _grade = value; }
        }

        public int courseId { get; set; }

        public override bool Validate()
        {
            if (studentName.Length == 0)
            {
                return false;
            }
            if (csName.Length == 0)
            {
                return false;
            }
            if (_marks > 100)
            {
                return false;
            }
            // To check if "Passed", "Failed" or "Excelled" was input for Grade
            //if (grade )
            //{
            //    return false;
            //}
            return true;
        }
    }
}
