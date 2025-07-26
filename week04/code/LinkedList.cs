using System.Collections;
using System.Diagnostics;
using System.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Inserts a new node containing <paramref name="value"/> at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The integer value to insert.</param>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Inserts a new node containing <paramref name="value"/> at the end of the linked list.
    /// </summary>
    /// <param name="value">The integer value to insert.</param>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Removes the first node in the list (the head).
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Removes the last node in the list (the tail).
    /// </summary>
    public void RemoveTail()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Inserts <paramref name="newValue"/> after the first occurrence of <paramref name="value"/> in the list.
    /// </summary>
    /// <param name="value">The existing value to search for.</param>
    /// <param name="newValue">The new value to insert after the existing value.</param>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Removes the first node in the list that contains the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to remove from the list.</param>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Replaces all occurrences of <paramref name="oldValue"/> in the list with <paramref name="newValue"/>.
    /// </summary>
    /// <param name="oldValue">The value to search for and replace.</param>
    /// <param name="newValue">The value to replace <paramref name="oldValue"/> with.</param>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates forward through the linked list.
    /// </summary>
    /// <returns>An enumerator for forward traversal.</returns>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Returns a non-generic enumerator for forward traversal (required by IEnumerable).
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Returns an IEnumerable that iterates backward from the tail to the head.
    /// </summary>
    /// <returns>An IEnumerable for reverse traversal.</returns>
    public IEnumerable Reverse()
    {
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    /// <summary>
    /// Returns a string representation of the linked list.
    /// </summary>
    /// <returns>A string showing the list contents.</returns>
    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    /// <summary>
    /// Checks if both head and tail are null (i.e. the list is empty).
    /// </summary>
    /// <returns>True if empty, false otherwise.</returns>
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    /// <summary>
    /// Checks if both head and tail are not null (i.e. the list is not empty).
    /// </summary>
    /// <returns>True if both are not null, false otherwise.</returns>
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

/// <summary>
/// Extension methods for displaying IEnumerable as formatted string.
/// </summary>
public static class IntArrayExtensionMethods
{
    /// <summary>
    /// Returns the string representation of an IEnumerable of integers.
    /// </summary>
    /// <param name="array">The IEnumerable to convert to string.</param>
    /// <returns>A formatted string.</returns>
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
