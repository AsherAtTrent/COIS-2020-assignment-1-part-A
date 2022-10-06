﻿public class MyString
{
    private class Node
    {
        public char item;
        public Node next;


        // Constructor (2 marks)
        public Node()
        {
            next = null;
        }
    }
    private Node front; // Reference to the first (header) node
    private int length; // Number of characters in MyString
    
    // Initialize with a header node an instance of MyString to the given character array A (4 marks)
    public MyString(char[] A)
    {
        front = new Node();
        Node p = front;
        for(int i = 0; i < A.Length; i++)
        {
            p.next = new Node();
            p.next.item = A[i];
            p = p.next;
        }

    }



    // Using a stack, reverse this instance of MyString (6 marks)
    public void Reverse() 
    { 
        Stack<char> S; 
    }


    // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
    public int IndexOf(char c)
    {
        return 0;
    }


    // Remove all occurrences of c from this instance (4 marks)
    public void Remove(char c)
    {

    }


    // Return true if obj is both of type MyString and the same as this instance;
    // otherwise false (6 marks)
    public override bool Equals(object obj) 
    {
        return true;
    }

    // Print out this instance of MyString (3 marks)
    public void Print() 
    {
        Node p = front.next;
        Console.WriteLine();
        while (p != null)
        {
            Console.Write(p.item);
            p=p.next;
        }
        Console.WriteLine();
    }
}


