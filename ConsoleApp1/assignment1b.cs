public class MyString
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
            length++;
            p = p.next;
        }
    }



    // Using a stack, reverse this instance of MyString (6 marks)
    public void Reverse() 
    {
        Stack<char> S = new Stack<char>();
        Node p = front.next;
        while (p != null)
        {
            S.Push(p.item);
            p = p.next;
        }
        p=front.next;
        while(p != null)
        {
            p.item = S.Pop();
            p = p.next;
        }
    }


    // Return the index of the first occurrence of c in this instance; otherwise -1 (4 marks)
    public int IndexOf(char c)
    {
        Node p = front.next;
        int index = -1;
        while(p != null)
        {
            index++;
            if (p.item == c)
            {
                return index;
            }
            p=p.next;
        }
        return index;
    }


    // Remove all occurrences of c from this instance (4 marks)
    public void Remove(char c)
    {

    }


    // Return true if obj is both of type MyString and the same as this instance;
    // otherwise false (6 marks)
    public override bool Equals(object obj) 
    {

        if (obj is MyString)
        {
            MyString toCompare = (MyString)obj;
            if(toCompare.length == this.length)
            {
                if (toCompare.length == 0){
                    return true;
                }
                Node indx = toCompare.front;
                Node indy = this.front;
                while(indx.item == indy.item)
                {
                    indx = indx.next;
                    indy = indy.next;
                    if(indx == null)
                    {
                        return true;
                    }

                }
            }
        }
        return false;
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


