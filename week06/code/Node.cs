public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; } // ?: property can be nullable; it may hold a reference to a Node object or it may be null
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TO DO Start Problem 1
        // This function takes a value, compares it, and
        // inserts it.  To avoid duplicate insertions, 
        // either add an "if (value == Data)" block that 
        // returns nothing, or change the "else" block 
        // to an "else if (value > Data)" block and 
        // leave the equals condition undefined
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right != null)
                Right.Insert(value);
            else
                Right = new Node(value);
        }
    }

    public bool Contains(int value)
    {
        // TO DO Start Problem 2
        // This function should search for the value and 
        // return "true" if it finds it
        if (value == Data) return true;
        else if (value < Data && Left != null)
            return Left.Contains(value);
        else if (value > Data && Right != null)
            return Right.Contains(value);
        else return false;
    }

    public int GetHeight()
    {
        // TO DO Start Problem 4
        // return 0; // Replace this line with the correct return statement(s)
        // This needs to recursively calculate itself and all 
        // children.  BUT, it then needs to return only the 
        // height of itself and its largest child.
        if (this is null)
            return 0;
        int ownHeight = 1;
        int leftHeight = 0;
        // int rightHeight = 0; // or use single-line null-conditional / null-coaelescing assignment
        if (Left != null) // or use Left?.GetHeight() ?? 0;
        {
            leftHeight = Left.GetHeight();
        }
        // if (Right != null)
        //     rightHeight = Right.GetHeight();
        int rightHeight = Right?.GetHeight() ?? 0;
        if (leftHeight > rightHeight) // or use Math.Max(leftHeight, rightHeight);
            return leftHeight + ownHeight;
        else return rightHeight + ownHeight;
    }
}