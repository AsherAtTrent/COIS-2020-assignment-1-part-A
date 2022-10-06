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
            char[] a = { };
            MyString s = new MyString(a);
            s.Print();
        }
       


    }
}