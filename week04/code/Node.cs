// DO NOT MODIFY THIS FILE
public class Node
{
    public int Data { get; set; } // Instead of directly accessing a field, we can access it through these property accessors.
    public Node? Next { get; set; } // Using properties provides a level of control over how values are accessed or changed. This allows validation logic or protective encapsulation.
    public Node? Prev { get; set; } // Without properties, we may need to write separate methods like GetData() and SetData(), making the code more verbose.

    public Node(int data)
    {
        this.Data = data;
    }
}