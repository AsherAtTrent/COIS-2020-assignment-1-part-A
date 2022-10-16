public class MyString
{
    private class Node
    {
        public char item;
        public Node next;


        //constructs a node with the next set to null 
        public Node()
        {
            next = null;
        }
    }
    private Node front; // Reference to the first (header) node
    private int length; // Number of characters in MyString


    /// <summary>
    /// Initialize, with a header node, an instance of MyString using a given character array
    /// </summary>
    /// 
    /// <param name="A"></param>
    public MyString(char[] A)
    {
        front = new Node(); //header node
        Node p = front;
        for(int i = 0; i < A.Length; i++)//go through the array and assign a new node to each index after the first
        {
            p.next = new Node();
            p.next.item = A[i];
            length++;
            p = p.next;
        }
    }



    // Using a stack, reverse this instance of MyString (6 marks)
    /// <summary>
    /// reverses the string that calls this method
    /// </summary>
    public void Reverse() //uses first in last out principle of a stack to reverse myString
    {
        Stack<char> S = new Stack<char>(); 
        Node p = front.next;

        while (p != null) // goes through each node adding it to the stack
        {
            S.Push(p.item);
            p = p.next;
        }

        p=front.next;// resets pointer back to first item before front

        while(p != null)// goes through each item requates it to the item in the stack
        {
            p.item = S.Pop();
            p = p.next;
        }
    }


    /// <summary>
    ///  Return the index of the first occurrence of c in this instance; otherwise -1 
    /// </summary>
    /// 
    /// <param name="c"></param>
    /// 
    /// <returns>int</returns>
    public int IndexOf(char c)
    {
        Node p = front.next;
        int index = -1;
        while(p != null) // goes through the node full not, if it finds an instnace of c, breaks out early and returns it
        {
            index++;
            if (p.item == c)
            {
                return index;
            }
            p=p.next;
        }
        return index; // if not found earlier returns -1
    }


    // Remove all occurrences of c from this instance (4 marks)
    public void Remove(char c)
    {
        //TODO
    }


    
    /// <summary>
    /// Return true if obj is both of type MyString and the same as this instance; otherwise false
    /// </summary>
    /// 
    /// <param name="obj"></param>
    /// 
    /// <returns>boolean</returns>
    public override bool Equals(object obj) 
    {
        if (obj is MyString) // if obj is Mystring, checks against null objects as well!
        {
            MyString toCompare = (MyString)obj; // casts obj as mystring
            if(toCompare.length == this.length) // if lengths are the same, we can use the same length over each, otherwise theyre note equal
            {
                if (toCompare.length == 0){ // if their length is zero theyre equal
                    return true;
                }
                Node indx = toCompare.front; 
                Node indy = this.front;
                while(indx.item == indy.item) // while both items are equal keep looping 
                {
                    indx = indx.next;
                    indy = indy.next;
                    if(indx == null)//if one reaches null, they are both equal
                    {
                        return true;
                    }

                }
            }
        }
        return false; // returns false 
    }

    /// <summary>
    /// print out the insance of mystring that called this function
    /// </summary>
    public void Print() 
    {
        Node p = front.next;
        Console.WriteLine(); 
        while (p != null) // loops through each node one by one and prints out ech item one by one
        {
            Console.Write(p.item);
            p=p.next;

        }
        Console.WriteLine();
    }
}


