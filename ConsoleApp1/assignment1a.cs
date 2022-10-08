using System;
using static System.Net.Mime.MediaTypeNames;

public enum TColor { WHITE, BLACK };
public class Square
{
    public TColor Color { set; get; } // Either WHITE or BLACK
    public int Number { set; get; } // Either a clue number or -1 (Note: A BLACK square is always -1)
    public Square()                // Initialize a square to WHITE and its clue number to -1 (2 marks)
    {
        Color = TColor.WHITE;
        Number = -1;
    }
}

public class Puzzle
{
    private Square[,] grid;

    private int N;

    /// <summary>
    /// Takes in a parameter N, then creates an N by N grid of initially all white squares.
    /// </summary>
    /// <param name="N"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    // Create an NxN crossword grid of WHITE squares (4 marks)
    public Puzzle(int N)
    {
        //maybe throw an exception if n is not atleast 1?
        if (N<0)
        {
            throw new ArgumentOutOfRangeException("puzzle size must be greater than 0");
        }
        this.N = N;
        grid = new Square[N, N];
        for (int j = 0; j < N; j++)
            for (int i = 0; i < N; i++)
                grid[j, i] = new Square();
    }
    /// <summary>
    /// Takes in a parameter M, then adds M amount of black squares to the Puzzle object that called this method.
    /// If M is Greater than the amount of squares the Puzzle object has, InvalidOperationException is thrown.
    /// </summary>
    /// 
    /// <param name="M"></param>
    /// <exception cref="InvalidOperationException"></exception>
    // Randomly initialize a crossword grid with M black squares (5 marks)
    public void Initialize(int M)
    {
        if (M > (N * N))
        {
            throw new InvalidOperationException("cannot have more black squares than white");
        }
        else
        {
            Random rand = new Random();
            while (M != 0)
            {
                int x = rand.Next(0, N);
                int y = rand.Next(0, N);
                if (grid[x, y].Color != TColor.BLACK)
                {
                    grid[x, y].Color = TColor.BLACK;
                    M--;
                }
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
    // Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
    public void PrintGrid()
    {
        for(int a = 0; a < N; a++)
                Console.Write(" - |");

        for (int j = 0; j < N; j++)
        {
            Console.WriteLine();
            for (int i = 0; i < N; i++)
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

            Console.WriteLine();
            for (int a = 0; a < N; a++)
                Console.Write(" - |");
        }

    }

    // Return true if the grid is symmetric (à la New York Times); false otherwise (4 marks)

    public bool Symmetric()
    {
        //nested forloop goes through each item, until middle row has been compared   
        for (int j = 0; j<= (N/2); j++) // n/2 truncates to give middlerow
        {
            for (int i = 0; i <N; i++)
            {
                Console.WriteLine("[{0},{1}]", j, i);
                if (grid[j, i].Color != grid[(N - 1) - j, (N - 1) - i].Color)//compares current item, to item 180 degree away
                {
                    return false;
                }   
            }  
        }
        
        return true;   
    }

    public bool Sym()
    {
        //one before the middle element of an odd size 2d array, or the final element in the middle row of an even size 2d array
        int middwayItem = ((N * N) - (2 * N % 2)) / 2;
        Console.WriteLine(middwayItem);
        for (int i = 0; i != middwayItem; i++) 
        {
            int x = i / N;//current x is calculated by truncated value of i/N
            int y = i % N;//current y is calculated by reminder of i%N
            if (grid[x, y].Color != grid[(N - 1) - x, (N - 1) - y].Color)//compares current item, to item 180 degree away
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


