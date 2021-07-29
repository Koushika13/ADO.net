using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
        class Course
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
}
