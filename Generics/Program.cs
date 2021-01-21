using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            // bool equals = Calculator.AreEqual(1, 2);

            bool equals = Calculator.AreEqual1("A", "A");
            if (equals)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not equals");
            }

            // TestUnboxing
            // TestUnboxing.Unboxing();

            //ListGenerics.Add();
            //Console.WriteLine($"List of arraylist:  {ListGenerics.Get(0)}");

            // Generics on List of Students
            PrintGetGradesAndStudents();

        }

        private static void PrintGetGradesAndStudents()
        {

            var dictionary = new ItemsCollection<Student>();
            var studentComparer = new ItemsCollection<Student>.StudentComparer();
            dictionary.Add("KG", new Student {FirstName = "John", LastName = "Smith", StudentId = 1}, studentComparer)
                .Add("KG", new Student {FirstName = "ZMary", LastName = "Smith", StudentId = 2}, studentComparer)
                .Add("KG", new Student {FirstName = "Mary", LastName = "Smith", StudentId = 3}, studentComparer)
                .Add("KG", new Student {FirstName = "Mary", LastName = "Smith", StudentId = 4}, studentComparer)
                .Add("KG", new Student {FirstName = "Mary", LastName = "Smith", StudentId = 5}, studentComparer);

            dictionary.Add("1st grade", new Student {FirstName = "Scott", LastName = "Allen", StudentId = 5},
                    studentComparer)
                .Add("1st grade", new Student {FirstName = "ZMary", LastName = "Allen", StudentId = 6}, studentComparer)
                .Add("1st grade", new Student {FirstName = "Mary", LastName = "Allen", StudentId = 7}, studentComparer);


            foreach (var grade in dictionary)
            {
                Console.WriteLine(grade.Key);
                foreach (var student in grade.Value)
                {
                    Console.WriteLine("\t" + student.FirstName);
                }
            }

        }
    }


    // only works with integer data type
    public class Calculator
    {

        public static bool AreEqual(int value1, int value2)
        {
            return value1 == value2;
        }

        public static bool AreEqual1<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
    //1 How to operate on any datatype...(ob).. reuse with any type


    /// <summary>
    /// Class to test unboxing fail
    /// </summary>
    class TestUnboxing
    {
        public static void Unboxing()
        {
            int i = 123;
            object o = i;  // implicit boxing

            try
            {
                int j = (short)o;  // attempt to unbox

                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }
        }
    }

    /// <summary>
    /// display list
    /// </summary>
    class ListGenerics
    {
        
        public static readonly ArrayList AgesArrayList = new ArrayList();
        public static readonly List<int> Ages = new List<int>();

        public static void Add()
        {
            AgesArrayList.Add(20);
            //AgesArrayList.Add("A"); errors out
            Ages.Add(2);
        }
        public static int Get(int index)
        {
            return (int)AgesArrayList[index];
        }
    }
}


