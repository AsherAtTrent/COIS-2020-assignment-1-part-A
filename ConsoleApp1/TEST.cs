using System.Runtime.Intrinsics.Arm;

public class assignment1
{
    public static void Main()
    {
        
        //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        
        Console.WriteLine("press x to exit, press a for assignment a, press b for assignment b");
        ConsoleKeyInfo keyinfo;
        bool mainmenu = true;
        while(mainmenu)
        {

            keyinfo = Console.ReadKey(); 
            if (keyinfo.KeyChar == 'a')
            {
                Console.Clear();
                Puzzle p = new Puzzle(5);
                p.Initialize(1);
                Console.WriteLine(p.Symmetric());
                Console.WriteLine(p.Sym());
                p.PrintGrid();
                p.printSymmetric();
            }
            else if(keyinfo.KeyChar == 'b')
            {
                char[] a = { 'a', 'b', 'c', 'd' };
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
                char[] b = { 'a', 'b', 'c' };
                char[] c = Array.Empty<char>();
                char[] d = Array.Empty<char>();
                MyString test2 = new MyString(b);
                MyString test3 = new MyString(c);
                MyString test4 = new MyString(d);
                Console.WriteLine(s.Equals(test));
                Console.WriteLine(s.Equals(test2));
                Console.WriteLine(test3.Equals(test4));
            }
            Console.WriteLine("press x to exit, press a for assignment a, press b for assignment b");
        }
        

    }
}