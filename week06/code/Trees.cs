public static class Trees
{
    /// <summary>
    /// Create a balanced BST from a sorted array.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Problem 5: Recursively insert middle element first to maintain balance.
    /// Avoids creating sublists by using first/last index parameters.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no numbers left in this range
        if (first > last)
            return;

        // Find middle index
        int mid = (first + last) / 2;

        // Insert middle element
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively insert right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
