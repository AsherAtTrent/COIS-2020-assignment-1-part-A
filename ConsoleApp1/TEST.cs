public class assignment1
{
    public static void Main()
    {
        //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        assignment1 a = new assignment1(); 
        ConsoleKeyInfo keyinfo;
        bool mainmenu = true;

        
        while (mainmenu)
        {
            Console.WriteLine("press x to exit, press a for assignment a, press b for assignment b");
            keyinfo = Console.ReadKey();
            if (keyinfo.KeyChar == 'a')
            {
                a.menuA(keyinfo);  
            }
            else if(keyinfo.KeyChar == 'b')
            {
                a.menuB(keyinfo);
            }
            else if (keyinfo.KeyChar == 'x')
            {
                mainmenu = false;
            }
            else
            {
                Console.Clear();
            }
        }
    }
    public void menuA(ConsoleKeyInfo keyinfo)
    {
        Console.Clear();
        bool focused = true;
        while (focused)
        {
            Console.WriteLine("press x to exit to main menu, press 0 for userinput");
            keyinfo = Console.ReadKey();
            if (keyinfo.KeyChar == '0')
            {
                Console.Clear();
                Puzzle p = new Puzzle(5);
                p.Initialize(1);
                Console.WriteLine(p.Symmetric());
                Console.WriteLine(p.Sym());
                p.PrintGrid();
                p.printSymmetric();
            }
            else if (keyinfo.KeyChar == 'x')
            {
                focused = false;
            }
            else
            {
                Console.Clear();
            }

        }
        Console.Clear();
    }
    public void menuB(ConsoleKeyInfo keyinfo)
    {
        char[] arr = { 'a', 'b', 'c', 'd' };
        MyString s = new MyString(arr);
        s.Print();
        Console.WriteLine(s.IndexOf('a'));
        Console.WriteLine(s.IndexOf('b'));
        Console.WriteLine(s.IndexOf('c'));
        Console.WriteLine(s.IndexOf('d'));
        s.Reverse();
        s.Print();
        s.Reverse();
        s.Print();
        MyString test = new MyString(arr);
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

}