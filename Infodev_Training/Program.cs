// See https://aka.ms/new-console-template for more information
using System.Text;

namespace ConsoleApp
{
    public class Car
    {
        int Speed;
        int _horsepower;
        public int HorsePower
        {
            get
            {
                return _horsepower; 
            }
            set
            {
                _horsepower = value;
            }
        }
        public int Wheels { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public PersonType PersonType { get; set; }

    }
    public enum PersonType
    {
        Student ,
        Employee=50,
        Owner
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return ($"{FirstName} {MiddleName} {LastName}");
            }
        }
    }
    public class Student : Person
    {
        public string Faculty { get; set; }
        public DateTime JoinDate { get; set; }

        //public Student(string Faculty) {   }

        public int Age()
        {
            return 25;
        }
    }
    public struct StructClass
    {
        public int x;
        public int y;
        public string z;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ClassEg();
            // Datatype();
            // EnumEg();
            //Interpolation();
            // InheritingAndOverriding();
            //StructureEg();

            
        }
        public static void StructureEg()
        {
            StructClass t;
            //Console.WriteLine(t.x);    Error: value not initialized so cant be accessed
            t.x = 5;
            t.y = 6;

            Console.WriteLine(t.x);//value initialized so can be accessed
        }
        public static void InheritingAndOverriding()
        {
            Rectangle r = new Rectangle();
            r.Length = 15.5M;
            r.Breadth = 12.5M;

            Shape s = new Rectangle();
            s.Length = 20.0M;
            // s.Breadth = 10.5M;     Error: no access to breath which is child variable

            Rectangle re = new Rectangle(2, 5);
            Console.WriteLine($"The Perimeter of rectangle is:{re.Perimeter()}");

            Shape overridingeg = new Rectangle(2, 5);
            Console.WriteLine("Overriding Test");
            Console.WriteLine($"The Perimeter of rectangle is:{overridingeg.Perimeter()}");
            Console.ReadLine();

        }
        public static void Interpolation()
        {
            int a = 50;
            int b = 100;
            //string formatting
            Console.WriteLine("This is a string {1} and string {0}", a, b);
            string str= String.Format("This is a string {1} and string {0}", a, b);
            Console.WriteLine(str);
            

            //string interpolation:
            Console.WriteLine($"This is a string {b} and string {a}");


            Person s1 = new Person();
            s1.FirstName = "Mansij";
            s1.LastName = "Ranjit";
            Console.WriteLine(s1.FullName);

        }
        public static void ClassEg()
        {
            Car ferrari = new Car();
            ferrari.HorsePower = 200;
            int hoersePowerOfCar = ferrari.HorsePower;
            Console.WriteLine(hoersePowerOfCar);
        }
        public static void Datatype()
        {
            //float a = 1.00f;
            //double a2 = 1.00d;
            //decimal a3 = 1.00m;

            //int[] arr = new int[1000];
            //char y = '1';

            //string test = "test";//Memory location 5000
            //test = "change";//memory location 5002 [Thus string is called immutable datatype]

            StringBuilder sb = new StringBuilder("Hello");//Memory location 6000[mutable datatype]
            sb.Append(" Superman");//Memory location 6000
            //  sb.Clear();
            sb.AppendLine();
            sb.Append("new line of string");
            sb.AppendLine();
            sb.AppendFormat("{0:C}", 500);
            sb.AppendLine();
            int a = 3, a2 = 3, a3 = 9;
            sb.AppendFormat("{0} {1} {2}", a, a2, a3);
            Console.WriteLine(sb);
        }
        public static void EnumEg()
        {
            int i = (int)PersonType.Student;
            int i1 = (int)PersonType.Employee;

            Console.WriteLine("Enum value stored :" + i);
            Console.WriteLine("Enum value stored :" + i1);

            Car ferrari=new Car();
            ferrari.PersonType = (PersonType)50;
            Console.WriteLine("Enum value stored :" + ferrari.PersonType.ToString());


            Console.ReadLine();
        }
       
    }
   
}
//Basic Data Types:
     // short 8bit, int 32bit, long 64bit, float 4*8, double 8*8, decimal 16*16, char 16bit, string;
