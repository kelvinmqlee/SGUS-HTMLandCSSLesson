using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CourseStudentDataAccess
    {
        private string connectionString = "Data Source=DESKTOP-R08O3R9;Initial Catalog=ContonsoConsoleDb;Integrated Security=True";
        public bool SaveCourse(Course obj)
        {
            // Step 1 - Open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Step 2 - Create SQL Insert into...
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Insert into tblCourse(CourseName) values(' "+obj.courseName+" ')";
            comm.Connection = conn;

            // Step 3 - Execute
            comm.ExecuteNonQuery();

            // Step 4 - Close the connection
            conn.Close();

            return true;
        }

        public bool SaveStudent(Student obj)
        {
            // Step 1 - Open the connection
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Step 2 - Create SQL Insert into...
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Insert into tblStudent(StudentName, Studentmarks, StudentGrade, CourseId_fk) " +
                               "values(' "+obj.studentName+" ', "+obj.marks+", "+obj.grade+", "+obj.courseId+" ')";
            comm.Connection = conn;

            // Step 3 - Execute
            comm.ExecuteNonQuery();

            // Step 4 - Close the connection
            conn.Close();

            return true;
        }

        public List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Select Id, CourseName from tblCourse";
            comm.Connection = conn;

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course();
                temp.id = Convert.ToInt32(dr["Id"]);
                temp.courseName = dr["CourseName"].ToString();

                // Get the students of this course
                List<Student> studs = getStudents(temp.id);
                foreach(var item in studs)
                {
                    temp.students.Add(item);
                }
                courses.Add(temp);
            }
            conn.Close();

            return courses;
        }

        public List<Student> getStudents(int id)
        {
            List<Student> studs = new List<Student>();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Select * from tblStudent";
            comm.Connection = conn;

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Student temp = new Student();
                temp.id = Convert.ToInt32(dr["Id"]);
                temp.studentName = dr["StudentName"].ToString();
                temp.marks = Convert.ToInt32(dr["StudentMarks"]);
                temp.grade = dr["StudentGrade"].ToString();
                temp.courseId = Convert.ToInt32(dr["CourseId_fk"]);
                studs.Add(temp);
            }
            conn.Close();

            return studs;
        }

        public int FindCourse(string courseName)
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Select Id from tblCourse where CourseName = '" + courseName + "'";
            comm.Connection = conn;

            SqlDataReader dr = comm.ExecuteReader();
            dr.Read(); // Go to the first row and get the id
            int id = Convert.ToInt32(dr["Id"]);
            conn.Close();
            return id;
        }
    }
}
