/// <summary>
/// Simple Linked List Class
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="Value"></param>
class LinkedList<T>(T Value) where T : IEquatable<T>
{
    public Node<T> Head = new(Value);
    public int Length = 1;

    /// <summary>
    /// Returns the value at a give index.
    /// O(n)
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Value at index</returns>
    public T Get(int index)
    {
        Node<T>? CurrentNode = Head;

        while (CurrentNode.Next != null)
        {
            if (index == 0)
                break;

            index --;
            CurrentNode = CurrentNode.Next;
        }

        return CurrentNode.Value;
    }

    /// <summary>
    /// Finds and returns the index at which the specified value occurs first.
    /// O(n)
    /// </summary>
    /// <param name="Value">The value that should be searched for</param>
    /// <returns>Index of the value</returns>
    public int Find(T Value)
    {
        Node<T>? CurrentNode = Head;
        int Index = 0;

        while (CurrentNode.Next != null)
        {
            if (CurrentNode.Value.Equals(Value))
                break;
            CurrentNode = CurrentNode.Next;
            Index++;
        }

        if (CurrentNode.Next == null)
            return -1;

        return Index;
    }

    /// <summary>
    /// Returns the first value in the list.
    /// O(1)
    /// </summary>
    /// <returns>The first value in the list</returns>
    public T First()
    {
        return Head.Value;
    }

    /// <summary>
    /// Returns the last value in the list.
    /// O(n)
    /// </summary>
    /// <returns>The last value in the list</returns>
    public T Last()
    {
        Node<T>? CurrentNode = Head;

        while (CurrentNode.Next != null)
        {
            CurrentNode = CurrentNode.Next;
        }

        return CurrentNode.Value;
    }

    /// <summary>
    /// Concatinates the second linked list with the first one in place.
    /// O(n)
    /// </summary>
    /// <param name="other">The list that should be concatinated</param>
    public void Concat(LinkedList<T> other)
    {
        Node<T>? CurrentNode = other.Head;

        while (CurrentNode != null)
        {
            Append(CurrentNode.Value);
            CurrentNode = CurrentNode.Next;
        }
    }

    /// <summary>
    /// Checks if a value is in the list.
    /// O(n)
    /// </summary>
    /// <param name="Value">The value that should be checked</param>
    /// <returns>true if the value is found otherwise false</returns>
    public bool Contains(T Value)
    {
        Node<T>? CurrentNode = Head;

        while (CurrentNode != null)
        {
            if (CurrentNode.Value.Equals(Value))
                return true;

            CurrentNode = CurrentNode.Next;
        }

        return false;
    }

    /// <summary>
    /// Adds the specified value to the end of the list.
    /// O(n)
    /// </summary>
    /// <param name="Value">The value that should be appended</param>
    public void Append(T Value)
    {
        Node<T>? CurrentNode = Head;

        while (CurrentNode.Next != null)
        {
            CurrentNode = CurrentNode.Next;
        }

        CurrentNode.Next = new Node<T>(Value);
        Length++;
    }

    /// <summary>
    /// Inserts the specified value at the specified index.
    /// O(n)
    /// </summary>
    /// <param name="Index">The index where the value should be inserted</param>
    /// <param name="Value">The value that should be inserted</param>
    public void Insert(int Index, T Value)
    {
        Node<T>? CurrentNode = Head;

        if (Index == 0)
        {
            Head = new Node<T>(Value, CurrentNode);
            return;
        }

        while (CurrentNode.Next != null && Index - 1 > 0)
        {
            CurrentNode = CurrentNode.Next;
            Index -= 1;
        }

        Node<T>? NewNode = new(Value, CurrentNode.Next);

        CurrentNode.Next = NewNode;
        Length++;
    }

    /// <summary>
    /// Deletes the first occurence of the value in the list.
    /// O(n)
    /// </summary>
    /// <param name="Value">The value that must be deleted</param>
    public void Delete(T Value)
    {
        Node<T>? CurrentNode = Head;

        while (CurrentNode.Next != null)
        {
            if (CurrentNode.Next.Value.Equals(Value))
                break;
            else
                CurrentNode = CurrentNode.Next;
        }

        if (CurrentNode.Next != null)
        {
            if (CurrentNode.Next.Next != null)
                CurrentNode.Next = CurrentNode.Next.Next;
            else
                CurrentNode.Next = null;
        }

        Length--;
    }

    public override string ToString()
    {
        string result = "";
        Node<T>? currentNode = Head;

        while (currentNode != null)
        {
            result += $"{currentNode.Value} -> ";
            currentNode = currentNode.Next;
        }

        return result + "_";
    }
}

/// <summary>
/// Single Node of Linked list
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="Value"></param>
/// <param name="Next"></param>
internal class Node<T>(T Value, Node<T>? Next=null)
{
    public T Value { get; set; } = Value;
    public Node<T>? Next { get; set; } = Next;
}