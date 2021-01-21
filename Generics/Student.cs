using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Generics;

namespace Generics
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }

    }

    internal class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
    }

}

public class ItemsCollection<T> : SortedDictionary<string, SortedSet<T>>
{
    public ItemsCollection<T> Add(string key, T item, IComparer<T> comparer)
    {
        //adding the grade if not there
        if (!ContainsKey(key))
        {
            Add(key, new SortedSet<T>(comparer));
        }

        // we add the student.
        this[key].Add(item);
        return this;
    }


    public class StudentComparer : IEqualityComparer<Student>, IComparer<Student>
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            return String.Compare(x.FirstName, y.FirstName);
        }

        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            return String.Equals(x.FirstName, y.FirstName);
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.FirstName.GetHashCode();
        }
    }

}