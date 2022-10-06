using System;

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

    // Create an NxN crossword grid of WHITE squares (4 marks)
    public Puzzle(int N)
    {
        this.N = N;
        grid = new Square[N, N];
        for (int j = 0; j < N; j++)
            for (int i = 0; i < N; i++)
                grid[j, i] = new Square();
    }

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

    // Print out the crossword grid including the BLACK squares and clue numbers (5 marks)
    public void PrintGrid()
    {
        for (int j = 0; j < N; j++)
        {
            Console.WriteLine();
            for (int a = 0; a < N; a++)
                Console.Write("- ");
             Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                if (grid[j, i].Number != -1)
                {
                    Console.Write(grid[j, i].Number + " ");
                }

                else if (grid[j, i].Color == TColor.BLACK)
                {
                    Console.Write("X ");
                }

                else
                {
                    Console.Write("  ");
                }

            }
        }





    }

    // Return true if the grid is symmetric (à la New York Times); false otherwise (4 marks)
    public bool Symmetric() 
    {
        for (int j = 0; j < N; j++)
            for (int i = 0; i < (N - N % 2) / 2; i++)
                if (grid[j,i].Color != grid[j, N - (1 + i)].Color)
                {
                    return false;
                }
        return true;
    
    }
}


public class Program
{
    public static void Main()
    {
        Puzzle p = new Puzzle(3);
       
        p.Initialize(2);
        Console.WriteLine(p.Symmetric());
        p.PrintGrid();


    }
}