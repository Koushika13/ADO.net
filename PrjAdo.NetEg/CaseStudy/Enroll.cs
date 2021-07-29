using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace CaseStudy
{
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



    interface AppEngine
    {
        public void introduce(Course course);
        public void register(Student student);
        public List<Student> ListOfStudents();
        public void enroll(Student student, Course course);
        public List<Enroll> ListOfEnrollments();

    }

    class InMemoryAppEngine : AppEngine
    {
        void AppEngine.introduce(Course course)
        {


            Console.WriteLine(course.id + " " + course.name + " " + course.duration + " " + course.fees);
        }

        void AppEngine.register(Student student)
        {

            Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
            //Students.Add(student);
        }

        List<Student> AppEngine.ListOfStudents()
        {
            Console.WriteLine("Enter number of students");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            List<Student> Students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                int Sid;
                string Sname;
                DateTime dob;
                Console.WriteLine("Enter student details");

                Sid = Convert.ToInt32(Console.ReadLine());
                Sname = Console.ReadLine();
                dob = Convert.ToDateTime(Console.ReadLine());

                Students.Add(new Student(Sid, Sname, dob));


            }

            return Students;

        }

        void AppEngine.enroll(Student student, Course course)
        {
            //Console.WriteLine(student.id + " " + student.name + " " + course.id + " " + course.name );
            //Console.WriteLine()
            Console.WriteLine(course.id + " " + course.name + " " + course.duration + " " + course.fees);
            Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));


        }

        List<Enroll> AppEngine.ListOfEnrollments()
        {
            int x;
            x = Convert.ToInt32(Console.ReadLine());
            List<Enroll> Enrollments = new List<Enroll>();

            for (int j = 0; j < x; j++)
            {
                Student student1 = new Student(1, "Koushika", Convert.ToDateTime(12 / 12 / 1999));
                Student student2 = new Student(2, "Deepika", Convert.ToDateTime(07 / 08 / 1999));
                Student student3 = new Student(3, "Nishidha", Convert.ToDateTime(05 / 06 / 1999));
                Student student4 = new Student(4, "Snehitha", Convert.ToDateTime(09 / 11 / 1999));

                Course course1 = new Course(1, "C#", 3, 20000);
                Course course2 = new Course(2, "C++", 4, 40000);
                Course course3 = new Course(3, "Java", 5, 20000);

                Console.WriteLine("Enrollment date");
                DateTime date = Convert.ToDateTime(Console.ReadLine());


                Enroll enrolls1 = new Enroll(student1, course1, date);
                Enroll enrollS2 = new Enroll(student1, course2, date);
                Enroll enrolls3 = new Enroll(student2, course3, date);
                Enroll enrollS4 = new Enroll(student3, course1, date);
                Enroll enrollS5 = new Enroll(student4, course3, date);

                Enrollments.Add(enrolls1);
                Enrollments.Add(enrollS2);
                Enrollments.Add(enrolls3);
                Enrollments.Add(enrollS4);
                Enrollments.Add(enrollS5);

              


            }

            return Enrollments;
        }



        static void Main()
        {
            AppEngine inMemoryApp = new InMemoryAppEngine();

            inMemoryApp.introduce(new Course(3, "Java", 5, 20000));
            //inMemoryApp.register(new Student(10001, "Koushika", Convert.ToDateTime(12 / 12 / 1999)));

            foreach (var l in inMemoryApp.ListOfStudents())
            {
                Console.WriteLine("id: {0},name :{1},dob:{2}", l.id, l.name, l.dateofbirth);

            }

            inMemoryApp.enroll(new Student(3, "Nishidha", Convert.ToDateTime(05 / 06 / 1999)), new Course(3, "Java", 5, 20000));


        }

    }


    

}
