using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root; // Root of the tree

    /// <summary>
    /// Insert a new value into the BST.
    /// </summary>
    public void Insert(int value)
    {
        // If tree is empty, new node becomes root
        if (_root is null)
            _root = new Node(value);
        else
            // Otherwise, delegate to Node.Insert
            _root.Insert(value);
    }

    /// <summary>
    /// Check if the BST contains a value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Support foreach loops.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Forward iteration (smallest to largest).
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers); // Collect values in sorted order
        foreach (var number in numbers)
            yield return number;
    }

    /// <summary>
    /// In-order traversal (Left, Root, Right).
    /// </summary>
    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);   // Visit left subtree
            values.Add(node.Data);                // Visit node
            TraverseForward(node.Right, values);  // Visit right subtree
        }
    }

    /// <summary>
    /// Problem 3: Reverse iteration (largest to smallest).
    /// </summary>
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values); // Visit right subtree first
            values.Add(node.Data);                // Visit node
            TraverseBackward(node.Left, values);  // Visit left subtree
        }
    }

    /// <summary>
    /// Public method to get reversed order as IEnumerable.
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    /// <summary>
    /// Get height of the entire BST.
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
