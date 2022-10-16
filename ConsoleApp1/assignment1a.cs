public enum TColor { WHITE, BLACK };
public class Square
{
    public TColor Color { set; get; } // Either WHITE or BLACK
    public int Number { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
    public Square()                // Initialize a square to WHITE and its clue number to -1 
    {
        Color = TColor.WHITE;
        Number = -1;
    }
}

public class Puzzle
{
    private Square[,] grid; 

    private int N;

    private int M;

    private int[] acrossClues = new int[0];
    private int[] downClues = new int[0];

    /// <summary>
    /// Takes in a parameter N, then creates an N by N grid of initially all white squares.
    /// </summary>
    /// 
    /// <param name="N"></param>
    /// 
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Puzzle(int N)
    {
        //throws exception if number of squares isnt atleast 1
        if (N<0)
        {
            throw new ArgumentOutOfRangeException("puzzle size must be greater than 0");
        }
        this.N = N;
        init(N);
    }

    /// <summary>
    /// Initializes a grid for the crossword.
    /// </summary>
    /// 
    /// <param name="N"></param>
    private void init(int N)//this is made into a seperate method, so that Initialize(int M) can be called on the same Puzzle object multiple times to recreate the grid, instead of making new object
    {
        grid = new Square[N, N]; // creates a new array delegated to be squares
        for (int j = 0; j < N; j++)
            for (int i = 0; i < N; i++)
                grid[j, i] = new Square(); // calls square constructer on each index
    }

    /// <summary>
    /// Takes in a parameter M, then creates M amount of black squares to the Puzzle object that called this method.
    /// If M is Greater than the amount of squares the Puzzle object has, InvalidOperationException is thrown.
    /// If M is less than 0, InvalidOperationException is thrown.
    /// </summary>
    /// 
    /// <param name="M"></param>
    /// 
    /// <exception cref="InvalidOperationException"></exception>
    public void Initialize(int M)
    {
        if (this.M != 0) //checks to see if black squares were added to this already, if so resets puzzle object
        {
            init(N);
        }

        if (M < 0) //if M is negative throw exception
        {
            throw new InvalidOperationException("cannot have negative black squares");
        }
        else if (M > (N * N)) // if M is greater than available amount of black squares throw exception
        {
            throw new InvalidOperationException("cannot have more black squares than white");
        }
        else
        {
            //creates a list of coords and randomly selects a spot 
            //then removes it from list to ensure the same spot cant be selected again
            //adds black squares and removes from list, M amount of times
            this.M = M;
            int puzzleSize = N* N;

            Random rand = new Random();

            //creates a list of strings with each index being a comma delimited coordinate. ie: (x,y)
            //will go through the list and add the coords sequentially from 0,0 .. N,N
            List<string> coords = new List<String>(puzzleSize); 
            for (int i = 0; i != puzzleSize; i++)
            {
                int x = i / N;//current x is calculated by truncated value of i/N, ensuring wraparound of row
                int y = i % N;//current y is calculated by reminder of i%N, ensuring a wraparound of column
                coords.Add(x + "," + y);
            } 
            //generates a random number from 0 to #squares
            //and then access the List at that random number, splits x and y components of index via comma delimiter,
            //then removes it that index from list
            for (int i = M;i != 0; i--)
            {
                int randNum = rand.Next(0,i);    
                
                string[] randCoords =  coords[randNum].Split(',') ;
                grid[int.Parse(randCoords[0]),int.Parse( randCoords[1])].Color = TColor.BLACK; //converts string at index[0] and index[1] to x and y coords
                coords.RemoveAt(randNum);
            }
            
        }
    }


    // Number the crossword grid (6 marks)
    public void Number()
    {


    }


    // Print out the numbers for the Across and Down clues (in order) (4 marks)
    public void PrintClues()
    {


    }
    /// <summary>
    /// Prints out Puzzle object that called this method onto the console, seperating each row with dashes.
    /// Black squares are denoted with X, Numbered white squares are denoted by their number, and white squares are depicted as blank spots.
    /// </summary>
    public void PrintGrid()
    {
        for(int a = 0; a < N; a++) // makes top row of dashes and lines
                Console.Write(" - |");

        //for loop that will go through each 
        for (int j = 0; j < N; j++) // goes through each row, doing a writeline to break into next line
        {
            Console.WriteLine();

            for (int i = 0; i < N; i++)//goes through each column, using write() based on number and colour, and then to draw a line
            {
                if (grid[j, i].Number != -1)
                {
                    Console.Write(" "+grid[j, i].Number);
                }

                else if (grid[j, i].Color == TColor.BLACK)
                {
                    Console.Write(" X");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.Write(" |");
            }

            Console.WriteLine(); //a bottom row of dashes and lines
            for (int a = 0; a < N; a++)
                Console.Write(" - |");
        }

    }

    // Return true if the grid is symmetric (à la New York Times); false otherwise (4 marks)

    /// <summary>
    /// checks if the puzzle object that called this method has 180 degree rotational symmetry. returns true if symmetrical false otherwise.
    /// </summary>
    /// 
    /// <returns>boolean</returns>
    public bool Symmetric()
    {
        //nested forloop goes through each item, until middle row has been compared   
        for (int j = 0; j<= (N/2); j++) // n/2 truncates to give middlerow
        {
            for (int i = 0; i <N; i++)
            {
                if (grid[j, i].Color != grid[(N - 1) - j, (N - 1) - i].Color)//compares current item, to its 180 degree counterpart
                {
                    return false;
                }   
            }  
        }
        
        return true;   
    }

    /// <summary>
    /// checks if the puzzle object that called this method has 180 degree rotational symmetry. returns true if symmetrical false otherwise.
    /// </summary>
    /// 
    /// <returns>boolean</returns>
    public bool Sym() //goes through half the square objects in the puzzle grid, comparing against its 180 degree counterpart
    {
        //one before the middle element of an odd size 2d array, or the final element in the middle row of an even size 2d array (half -1 or half of all squares respectively)
        //this calculation ensures all squares with a 180 degree counterpart are compared exactly once only
        int middwayItem = ((N * N) - (2 * N % 2)) / 2; 
       
        for (int i = 0; i != middwayItem; i++)
        {
            int x = i / N;//current x is calculated by truncated value of i/N, ensuring wraparound of row
            int y = i % N;//current y is calculated by reminder of i%N, ensuring a wraparound of column

            if (grid[x, y].Color != grid[(N - 1) - x, (N - 1) - y].Color)//compares current item, to its 180 degree counterpart
            {
                return false; 
            }
        }
        return true;
    }

    public void printSymmetric()
    {
        Console.WriteLine();
        for (int i = N-1; i >= 0; i--)
        {
            for (int j = N-1; j >= 0; j--)
            {
                Console.Write(grid[i, j].Color + " ");
            }
            Console.WriteLine();
        }
    }
}


