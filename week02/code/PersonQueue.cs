/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the back of the queue (FIFO)
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // ✅ Correct order
    }

    /// <summary>
    /// Remove the person at the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() => _queue.Count == 0;

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
