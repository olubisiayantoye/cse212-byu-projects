public class Node
{
    public int Data { get; set; }    // Value stored in this node
    public Node? Right { get; private set; } // Right child
    public Node? Left { get; private set; }  // Left child

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert a value into the BST while preventing duplicates.
    /// </summary>
    public void Insert(int value)
    {
        // If the value already exists in this node, do nothing (no duplicates allowed)
        if (value == Data)
            return;

        // If the value is smaller, go left
        if (value < Data)
        {
            // If no left child, insert here
            if (Left is null)
                Left = new Node(value);
            else
                // Otherwise, recurse left
                Left.Insert(value);
        }
        // If the value is larger, go right
        else
        {
            // If no right child, insert here
            if (Right is null)
                Right = new Node(value);
            else
                // Otherwise, recurse right
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Check if the BST contains a given value (recursive search).
    /// </summary>
    public bool Contains(int value)
    {
        // Match found
        if (value == Data)
            return true;

        // Search left if smaller
        if (value < Data)
            return Left != null && Left.Contains(value);

        // Search right if larger
        return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Problem 4: Get the height of this node’s subtree.
    /// Height = 1 + max height of left or right subtree.
    /// </summary>
    public int GetHeight()
    {
        // Recursively get heights of left and right subtrees (0 if null)
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Current height = 1 for this node + max of left/right
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
