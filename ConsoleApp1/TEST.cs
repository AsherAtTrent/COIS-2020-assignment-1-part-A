using System.Runtime.Intrinsics.Arm;

public class assignment1
{
    public static void Main()
    {
        Console.WriteLine("press a for assignment a, press any other character for assignment b");
        if(Console.Read() == 'a')
        {
            Puzzle p = new Puzzle(3);
            p.Initialize(2);
            Console.WriteLine(p.Symmetric());
            p.PrintGrid();
        }
        else
        {      
            char[] a = { 'a','b','c','d'};
            MyString s = new MyString(a);
            s.Print();
            Console.WriteLine(s.IndexOf('a'));
            Console.WriteLine(s.IndexOf('b'));
            Console.WriteLine(s.IndexOf('c'));
            Console.WriteLine(s.IndexOf('d'));
            s.Reverse();
            s.Print();
            s.Reverse();
            s.Print();
            MyString test = new MyString(a);
            char[] b = { 'a','b','c'};
            char[] c = Array.Empty<char>();
            char[] d = Array.Empty<char>();
            MyString test2 = new MyString(b);
            MyString test3 = new MyString(c);
            MyString test4 = new MyString(d);
            Console.WriteLine(s.Equals(test));
            Console.WriteLine(s.Equals(test2));
            Console.WriteLine(test3.Equals(test4));
        }
       


    }
}