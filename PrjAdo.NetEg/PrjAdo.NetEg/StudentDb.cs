using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;


namespace PrjAdo.NetEg
{
    /*class StudentDb
    {
    }*/

    interface AppEngine
    {
        public void introduce(Course course);
        public void register(Student student);
        public List<Student> ListOfStudents();
        public void enroll(Student student, Course course);
        public List<Enroll> ListOfEnrollments();

    }

    class Student
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal DateTime dateofbirth { get; set; }




        public Student(int id, string name, DateTime dateofbirth)
        {
            this.id = id;
            this.name = name;
            this.dateofbirth = dateofbirth;

        }
    }
    /* class Course
     {
         internal int id { get; set; }
         internal string name { get; set; }
         internal int duration { get; set; }
         internal double fees { get; set; }

         public Course(int id, string name, int duration, double fees)
         {
             this.id = id;
             this.name = name;
             this.duration = duration;
             this.fees = fees;

         }

         internal virtual void CalculateMonthlyFees(double fees)
         {
             double total;
             total = fees / 12;
             Console.WriteLine(total);


         }
     }*/

    abstract class Course
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal int duration { get; set; }
        internal double fees { get; set; }

        public Course(int id, string name, int duration, double fees)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;

        }

        /*internal virtual void CalculateMonthlyFees(double fees)
        {
            double total;
            total = fees / 12;
            Console.WriteLine(total);


        }*/

        abstract internal void CalculateMonthlyFees(double fees);
    }

    class DegreeCourse : Course
    {
        internal enum Level
        {
            Bachelors,
            Masters
        }
        internal Level level;
        internal bool isPlacementAvailable;

        internal DegreeCourse(int id, string name, int duration, double fees, string level1, bool isPlacementAvailable) : base(id, name, duration, fees)
        {
            this.isPlacementAvailable = isPlacementAvailable;
            level = (Level)Enum.Parse(typeof(Level), level1);
        }

        internal override void CalculateMonthlyFees(double fees)
        {
            double val;
            val = (fees / 12) + (0.1 * (fees / 12));
            Console.WriteLine(val);
        }


    }

    class DiplomaCourse : Course
    {
        internal enum Type
        {
            Professional,
            Academic
        };

        internal Type type;

        internal DiplomaCourse(int id, string name, int duration, double fees, string type1) : base(id, name, duration, fees)
        {
            type = (Type)Enum.Parse(typeof(Type), type1);
        }

        internal override void CalculateMonthlyFees(double fees)
        {
            double a, b;
            if (type == (Type)0)
            {
                a = (fees / 12) + (0.1 * (fees / 12));
                Console.WriteLine(a);
            }
            else if (type == (Type)1)
            {
                b = (fees / 12) + (0.05 * (fees / 12));
                Console.WriteLine(b);
            }

        }

    }



    class Info
    {
        public static void display(Student student)
        {
            Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
        }

        public static void display_course(Course course)
        {

            Console.WriteLine(course.id + " " + course.name + " " + course.duration + " " + course.fees);
        }
    }

    class Enroll
    {
        private Student student { get; set; }
        private Course course { get; set; }
        private DateTime enrollmentDate { get; set; }

        internal Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
    }

    /*class InMemoryAppEngine : AppEngine
    {
        List<Student> Students = new List<Student>();
        List<Enroll> Enrollments = new List<Enroll>();

        void AppEngine.introduce(Course course)
        {
            Console.WriteLine(course.id + " " + course.name + " " + course.duration + " " + course.fees);
        }

        void AppEngine.register(Student student)
        {
            Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
            Students.Add(student);
        }

        List<Student> AppEngine.ListOfStudents()
        {
            return Students;


        }

        void AppEngine.enroll(Student student, Course course)
        {

            Enroll enroll = new Enroll(student, course, DateTime.Today);
            Enrollments.Add(enroll);

        }

        List<Enroll> AppEngine.ListOfEnrollments()
        {
            return Enrollments;

        }



    }

    public class EnrollmentException : ApplicationException
    {
        public EnrollmentException(string Message) : base(Message)
        {

        }
    }*/

    class PersistantAppEngine : AppEngine
    {
        public void register(Student student)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = new SqlConnection(
                    "Data Source = DESKTOP-IM16U2B;Initial Catalog = CaseStudy; Integrated Security = true ");

                cmd = new SqlCommand("insert into Student(name,dateofbirth) values (@sname,@dob)", con);
                cmd.Parameters.AddWithValue("@name", student.name);
                cmd.Parameters.AddWithValue("@dob", student.dateofbirth);
                int j = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Affected :{0}", j);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }

        }

        public void introduce(Course course)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = new SqlConnection(
                    "Data Source = DESKTOP-IM16U2B;Initial Catalog = CaseStudy; Integrated Security = true ");

                cmd = new SqlCommand("update Course set duration = @duration, fees= @fees where name = @cname", con);
                cmd.Parameters.AddWithValue("@name", course.name);
                cmd.Parameters.AddWithValue("@duration",  course.duration);
                cmd.Parameters.AddWithValue("@fees", course.fees);

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Affected :{0}", i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }

        }
    }


    class App
    {
        public static void Scenario1()
        {
            Student student1 = new Student(1, "Koushika", Convert.ToDateTime("05/10/1999"));
            Student student2 = new Student(2, "Nishidha", Convert.ToDateTime("18/02/1999"));
            Student student3 = new Student(3, "Maneesha", Convert.ToDateTime("03/12/1999"));

            Info info = new Info();
            Info.display(student1);
            Info.display(student2);
            Info.display(student3);


        }


        public static void Scenario2()
        {
            Student[] students = new Student[3];
            students[0] = new Student(1, "Koushika", Convert.ToDateTime("05/10/1999"));
            students[1] = new Student(2, "Nishidha", Convert.ToDateTime("18/02/1999"));
            students[2] = new Student(3, "Maneesha", Convert.ToDateTime("03/12/1999"));
            foreach (Student su in students)
            {
                Info.display(su);
            }

        }
        public static void Scenario3()
        {
            Console.WriteLine("Enter number of student:");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[n];
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("Enter roll no,name, and dob");
                int id = Convert.ToInt32(Console.ReadLine());
                String name = Console.ReadLine();
                DateTime date = DateTime.Parse(Console.ReadLine());
                students[i] = new Student(id, name, date);


            }
            foreach (Student su in students)
            {
                Info.display(su);
            }
        }

        public static void Scenario4()
        {
            Console.WriteLine("Enter number of student:");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayList students = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter roll no,name, and dob");
                int id = Convert.ToInt32(Console.ReadLine());
                String name = Console.ReadLine();
                DateTime date = DateTime.Parse(Console.ReadLine());
                //students[i] = new Student(id, name, date);
                students.Add(new Student(id, name, date));

            }
            foreach (Student su in students)
            {
                Info.display(su);
            }



        }





        static void Main()
        {
            App.Scenario1();
            App.Scenario2();
            App.Scenario3();
            App.Scenario4();

            DegreeCourse degreeCourse = new DegreeCourse(1, "Koushika", 2, 5000000, "Masters", true);
            degreeCourse.CalculateMonthlyFees(5000000);

            DiplomaCourse diplomaCourse = new DiplomaCourse(1, "Koushika", 2, 5000000, "Professional");
            diplomaCourse.CalculateMonthlyFees(5000000);

           // AppEngine x = new InMemoryAppEngine();


        }
    }

}

