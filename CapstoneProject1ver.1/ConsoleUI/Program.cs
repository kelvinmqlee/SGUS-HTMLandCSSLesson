using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace ConsoleUI
{
    class Program
    {
        #region declaration
        static string mainAction;
        static int subAction;
        #endregion declaration

        static void Main(string[] args)
        {
            // string -- series CHAR
            while (mainAction != "Q")
            {
                Console.Clear();
                MainMenuOptions();

                if (mainAction == "D")
                {
                    DisplayAllOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        DisplayAllCourses();
                    }
                    if (subAction == 2)
                    {
                        DisplayAllStudents();
                    }
                    if (subAction == 3)
                    {
                        MainMenuOptions();
                    }
                }

                if (mainAction == "A")
                {
                    AddAllOptions();
                    subAction = Convert.ToInt32(Console.ReadLine());
                    if (subAction == 1)
                    {
                        AddNewCourse();
                    }
                    if (subAction == 2)
                    {
                        AddNewStudent();
                    }
                    if (subAction == 3)
                    {
                        MainMenuOptions();
                    }
                }

                //if (mainAction == "E")
                //{
                //    EditAllOptions();
                //    subAction = Convert.ToInt32(Console.ReadLine());
                //    if (subAction == 1)
                //    {
                //        EditCourse();
                //    }
                //    if (subAction == 2)
                //    {
                //        EditStudent();
                //    }
                //    if (subAction == 3)
                //    {
                //        MainMenuOptions();
                //    }
                //}

                mainAction = Console.ReadLine().ToUpper();
            }
        }

        static void MainMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("**********Contonso University Student Management System**********");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Press 'D' to Display all courses / student records");
            Console.WriteLine("Press 'A' to Add a new course / new student record");
            Console.WriteLine("Press 'E' to Edit or Delete a course / student record");
            Console.WriteLine("Press 'Q' to Exit");
        }

        static void DisplayAllOptions()
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("**********Contonso University Student Management System**********");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Press '1' to display all courses");
            Console.WriteLine("Press '2' to display all student records");
            Console.WriteLine("Press '3' to return to the Main Menu");
        }

        static void AddAllOptions()
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("**********Contonso University Student Management System**********");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Press '1' to add a new course");
            Console.WriteLine("Press '2' to add a new student record");
            Console.WriteLine("Press '3' to return to the Main Menu");
        }

        static void EditAllOptions()
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("**********Contonso University Student Management System**********");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Press '1' to edit a course name");
            Console.WriteLine("Press '2' to edit a student record");
            Console.WriteLine("Press '3' to return to the Main Menu");
        }

        static void DisplayAllCourses()
        {
            Console.WriteLine();
            Console.WriteLine("LIST OF COURSE(S) AVAILABLE:");
            Console.WriteLine();

            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Course> courses = db.getCourses();
            foreach (var temp in courses)
            {
                Console.WriteLine("ID: " + temp.id);
                Console.WriteLine("Course Name: " + temp.courseName);
                Console.WriteLine("Average Marks Achieved: " + temp.CalculateAverage());
            }

            Console.WriteLine();
            Console.WriteLine("Total number of Courses: " + courses.Count);
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Main Menu");
        }

        static void DisplayAllStudents()
        {
            Console.WriteLine();

            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Student> students = db.getStudents(); // I'm stuck here......
            foreach (var temp in students)
            {
                Console.WriteLine();
                Console.WriteLine("Course Name: " + temp.csName);
                Console.WriteLine();
                Console.WriteLine("Student ID: " + temp.id);
                Console.WriteLine("Student Name: " + temp.studentName);
                Console.WriteLine("Marks Achieved: " + temp.marks);
                Console.WriteLine("Grade Achieved: " + temp.grade);
            }

            Console.WriteLine();
            Console.WriteLine("Total number of Students: " + students.Count);
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Main Menu");
        }
        static void AddNewCourse()
        {
            #region takeInputs
            Course course = new Course();
            Console.WriteLine();
            Console.WriteLine("Please input new course name:");
            course.courseName = Console.ReadLine().ToUpper();

            // Make the DataAccess call
            CourseStudentDataAccess db = new CourseStudentDataAccess();
            db.SaveCourse(course);

            Console.Clear();
            MainMenuOptions();

            // -- To check for existing course name in system
            //Course course = FindCourse(courseName);
            //if (course != null)
            //{
            //    Console.WriteLine("The Course already existed in the system");
            //}
            //else
            //{
            //    course = new Course();

            //    #region addToCollection
            //    courses.Add(course);
            //    #endregion addToCollection

            //    Console.Clear();
            //    MainMenuOptions();
            //}
            #endregion takeInputs
        }

        static void AddNewStudent()
        {
            #region takeInputs
            Console.WriteLine();
            Console.WriteLine("Please input course name:");
            string courseName = Console.ReadLine().ToUpper();

            // Make the DataAccess call
            CourseStudentDataAccess db = new CourseStudentDataAccess();

            int courseId = db.FindCourse(courseName);
            if (courseId == 0)
            {
                Console.WriteLine("Course is not available");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the Main Menu");
            }
            else
            {               
                Student student = new Student();
                Console.WriteLine();
                Console.WriteLine("Please input new student ID:");
                student.id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please input new student name:");
                student.studentName = Console.ReadLine().ToUpper();

                Console.WriteLine("Please input marks achieved:");
                string marks = Console.ReadLine();
                int marksChecked = 0;
                if (int.TryParse(marks, out marksChecked) == true) // Try parse return
                {
                    student.marks = marksChecked;

                    Console.WriteLine("Please input grade achieved:");
                    student.grade = Console.ReadLine().ToUpper();

                    student.courseId = courseId;

                    #region addToCollection
                    db.SaveStudent(student);
                    #endregion addToCollection
                }
                else
                {
                    Console.WriteLine("Marks should be numeric");
                }
            }
            #endregion takeInputs

            Console.Clear();
            MainMenuOptions();
        }

        static void EditCourse()
        {
            // To be updated
        }

        static void EditStudent()
        {
            // To be updated
        }

        static Course FindCourse(string courseName)
        {
            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Course> courses = db.getCourses();
            foreach (var temp in courses)
            {
                if(temp.courseName == courseName)
                {
                    return temp; // you found an existing course
                }
            }
            return null; // you did not find the course
        }

        static Course FindCourseLinq(string courseName)
        {
            CourseStudentDataAccess db = new CourseStudentDataAccess();

            List<Course> courses = db.getCourses();
            List<Course> tCourses = (from temp in courses 
                                    where temp.courseName == courseName
                                    select temp).ToList<Course>();
            if (tCourses.Count == 0)
            {
                return null;
            }
            else
            {
                return tCourses[0];
            }
        }
    }
}
