using System;

namespace OverrideEquals
{
    public enum Direction { East = 1, West = 2, North = 3, South = 4 };

    public class Customer{
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Customer))
                return false;

            return this.FirstName == (obj as Customer).FirstName &&
                       this.LastName == (obj as Customer).LastName;
        }

        public override int GetHashCode()
        {
            // use bitwise xor to combine the hascodes into a single hashcode
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // value type
            int i = 10;
            int j = 10;

            Console.WriteLine(i == j);
            Console.WriteLine(i.Equals(j));

            // value type (enum)
            Direction d1 = Direction.East;
            Direction d2 = Direction.East;

            Console.WriteLine(d1 == d2);
            Console.WriteLine(d1.Equals(d2));

            // reference type
            Customer c1 = new Customer() { FirstName = "Simon", LastName = "Says" };
            Customer c2 = c1;

            Console.WriteLine(c1 == c2);      // reference equality
            Console.WriteLine(c1.Equals(c2)); // value equality

            // reference type
            Customer c3 = new Customer() { FirstName = "Simon", LastName = "Says" };

            Console.WriteLine(c1 == c3);      // reference inequality
            Console.WriteLine(c1.Equals(c3)); // value equality is false, 
                                              // but should be tru
                                              // therefore, override equality
        }
    }
}
