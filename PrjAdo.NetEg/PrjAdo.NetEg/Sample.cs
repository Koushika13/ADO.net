using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAdo.NetEg
{
    class Sample
    {
        int box = 20;
        const int square = 10;

        const int a = square + 20;
        readonly float pi = 3.14f;

        internal Sample()
        {
            pi = 3.00f; //read-only are run time constant
            //square = 90; //constants are compile time constants

        }

        internal void Analyse()
        {
            box = 30;
            //constant variable
            //square = 60; //constant variable cant be changed
            // a=square + square; //Error
        }

        //Name parameter and optional parameter
                        //optional parameter

        public static int Calculation(int a, int b = 78)
        {
            return a + b;
        }
    }

    class ConstandReadonly
    {
        static void Main()
        {
            Sample.Calculation(3);
        }
    }
}
