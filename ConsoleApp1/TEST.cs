using System.Runtime.Serialization;

public class assignment1
{
    /// <summary>
    /// this is only to let examiners test this assignment1 and assignment2
    /// </summary>
    public static void Main()
    {
        //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        assignment1 a = new assignment1(); 
        ConsoleKeyInfo keyinfo;
        bool mainmenu = true;


        do
        {
            Console.WriteLine("press x to exit \npress a for assignment a \npress b for assignment b");
            keyinfo = Console.ReadKey();
            if (keyinfo.KeyChar == 'a')
            {
                a.MenuA(keyinfo);
            }
            else if (keyinfo.KeyChar == 'b')
            {
                a.MenuB(keyinfo);
            }
            else if (keyinfo.KeyChar == 'x')
            {
                mainmenu = false;
            }
            else
            {
                Console.Clear();
            }
        } while (mainmenu);
    }

    /// <summary>
    /// seperates MenuA, which contains partA and helps test it using user input.
    /// </summary>
    /// 
    /// <param name="keyinfo"></param>
    public void MenuA(ConsoleKeyInfo keyinfo)
    {
        Console.Clear();
        bool focused = true;
        do
        {
            Console.WriteLine("press x to exit to main menu \npress a for userinput");
            keyinfo = Console.ReadKey();
            if (keyinfo.KeyChar == 'a')
            {

                string sizeMessage = "Please input a non-zero number for length of square grid, and press enter";
                int puzzleSize;

                do
                {
                    puzzleSize = NumberChecker(sizeMessage);
                } while (!(puzzleSize > 0)); //checks to see if entered value is greater than 0 to avoid exception throw
                

                Puzzle p = new Puzzle(puzzleSize);

                string blackSqMessage = "Please input number of black squares not greater than number of squares in grid";
                int blackSquares;

                do
                {
                    blackSquares = NumberChecker(blackSqMessage);
                } while (blackSquares < 0 || blackSquares > (puzzleSize * puzzleSize));//checks to see if entered value is less than 0 or greater than number of squares to avoid exception

                do
                {
                    Console.Clear();
                    p.Initialize(blackSquares);
                    Console.WriteLine(p.Symmetric());
                    Console.WriteLine(p.Sym());
                    p.Number();
                    Console.WriteLine();
                    p.PrintGrid();
                    p.PrintClues();
                    Console.WriteLine("press x to exit to user input \npress r to replay ");
                } while (Console.ReadKey().KeyChar == 'r');
                
                

                
            }
            else if (keyinfo.KeyChar == 'x')
            {
                focused = false;
            }
            else
            {
                Console.Clear();
            }

        } while (focused);
        Console.Clear();
    }
    /// <summary>
    /// seperates menuB, which holds partB, and helps test with user input, as well as giving some own basic test cases
    /// </summary>
    /// 
    /// <param name="keyinfo"></param>
    public void MenuB(ConsoleKeyInfo keyinfo)
    {
        Console.Clear();
        bool focused = true;
        do
        {
            Console.WriteLine("press x to exit to main menu \npress b for userinput\ntype a for test cases ");
            keyinfo = Console.ReadKey();
            if (keyinfo.KeyChar == 'a')
            {
                Console.Clear();

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
                MyString? v = null;

                Console.WriteLine("when comparing against null answer is: " + s.Equals(v));
            }
            else if(keyinfo.KeyChar == 'b'){
                Console.Clear();
                Console.WriteLine("type first list of characters, and press enter");
                
                char[] arr1 = Console.ReadLine().ToCharArray();

                Console.WriteLine("type second list of characters, and press enter");
                char[] arr2 = Console.ReadLine().ToCharArray();

                MyString s1 = new MyString(arr1);
                MyString s2 = new MyString(arr2);

                Boolean userinput = true;
                Console.Clear();
                do
                {
                    Console.WriteLine("1st String:");
                    s1.Print();
                    Console.WriteLine("2nd String:");
                    s2.Print();
                    Console.WriteLine("press x to exit to Menu B \npress v for reverse\ntype e equal\npress i for index of character \npress r for remove ");
                    keyinfo = Console.ReadKey();

                    if (keyinfo.KeyChar == 'v')
                    {
                        listStrings(s1, s2);
                        Console.WriteLine("press 1 for string 1 \npress 2 for string 2 \npress 3 for both strings \npress any other key to exit");
                        keyinfo = Console.ReadKey();
                        if (keyinfo.KeyChar == '1')
                        {
                            Console.Clear();
                            s1.Reverse();
                        }
                        else if (keyinfo.KeyChar == '2')
                        {
                            Console.Clear();
                            s2.Reverse();
                        }
                        else if (keyinfo.KeyChar == '3')
                        {
                            Console.Clear();
                            s1.Reverse();
                            s2.Reverse();
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    else if (keyinfo.KeyChar == 'e')
                    {
                        Console.Clear();
                        Console.WriteLine("Does 1st string equal 2nd string: {0}", s1.Equals(s2)); ;

                    }
                    else if (keyinfo.KeyChar == 'i')
                    {
                        listStrings(s1, s2);
                        Console.WriteLine("press 1 for string 1 \npress 2 for string 2 \npress 3 for both strings \npress any other key to exit");
                        keyinfo = Console.ReadKey();
                        char c;
                        if (keyinfo.KeyChar == '1')
                        {
                            listStrings(s1);
                            Console.WriteLine("press any character to search for: ");
                            c = Console.ReadKey().KeyChar;
                            Console.Clear();
                            Console.WriteLine("The index of {0} in string 1 is: {1}", c, s1.IndexOf(c));
                        }
                        else if (keyinfo.KeyChar == '2')
                        {

                            listStrings(s2);
                            Console.WriteLine("press any character to search for: ");
                            c = Console.ReadKey().KeyChar;
                            Console.Clear();
                            Console.WriteLine("The index of {0} in string 2 is: {1}", c, s2.IndexOf(c));
                        }
                        else if (keyinfo.KeyChar == '3')
                        {
                            listStrings(s1, s2);
                            Console.WriteLine("press any character to search for: ");
                            c = Console.ReadKey().KeyChar;
                            Console.Clear();
                            Console.WriteLine("The index of {0} in string 1 is: {1}", c, s1.IndexOf(c));
                            Console.WriteLine("The index of {0} in string 2 is: {1}", c, s2.IndexOf(c));
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    else if (keyinfo.KeyChar == 'r')
                    {
                        Console.Clear();
                        Console.WriteLine("press 1 for string 1 \npress 2 for string 2 \npress 3 for both strings \npress any other key to exit");
                        keyinfo = Console.ReadKey();
                        char c;
                        if (keyinfo.KeyChar == '1')
                        {
                            listStrings(s1);
                            Console.WriteLine("press any character to remove: ");
                            c = Console.ReadKey().KeyChar;
                            s1.Remove(c);
                            Console.Clear();
                            
                        }
                        else if (keyinfo.KeyChar == '2')
                        {
                            listStrings(s2);
                            Console.WriteLine("press any character to remove: ");
                            c = Console.ReadKey().KeyChar;
                            s2.Remove(c);
                            Console.Clear();
                        }
                        else if (keyinfo.KeyChar == '3')
                        {
                            listStrings(s1,s2);
                            Console.WriteLine("press any character to remove: ");
                            c = Console.ReadKey().KeyChar;
                            s1.Remove(c);
                            s2.Remove(c);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    else if (keyinfo.KeyChar == 'x')
                    {
                        userinput = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                    }
                } while (userinput);
                

            }
            else if (keyinfo.KeyChar == 'x')
            {
                focused = false;
            }
            else
            {
                Console.Clear();
            }
        } while (focused);
        Console.Clear();
    }

    /// <summary>
    /// helper method for MenuA which takes in a message as a string parameter.
    /// takes in input from user and ensures it can be parsed as an int, if not parsed it plays the message.
    /// returns the number inputted from user once the program is able to parse it as a int
    /// </summary>
    /// 
    /// <param name="message"></param>
    /// 
    /// <returns>int</returns>
    public int NumberChecker(string message)
    {
        int number;
        Console.Clear();
        Console.WriteLine(message);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Clear();
            Console.WriteLine(message);
        }
        Console.Clear();
        return number;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    public void listStrings(MyString s1, MyString s2)
    {
        Console.Clear();
        Console.WriteLine("1st String:");
        s1.Print();
        Console.WriteLine("2nd String:");
        s2.Print();
    }

    public void listStrings(MyString s1)
    {
        Console.Clear();
        Console.WriteLine("selected String:");
        s1.Print();
    }

}
