using System.Collections.Generic;
using UnityEngine;

public enum GroupElement
{
    i = 0,
    a = 1, b = 2,
    ai = -1, bi = -2
}

public class GroupTheorySimplifier
{
    public List<int> expression = new List<int>();
    public GroupTheorySimplifier(int[] ints)
    {
        foreach (int i in ints)
        {
            Push(i);
        }
    }

    public GroupTheorySimplifier(GroupElement[] elements)
    {
        foreach (GroupElement i in elements)
        {
            Push((int)i);
        }
    }

    public GroupTheorySimplifier() {}

    public void Push(GroupElement a)
    {
        Push((int)a);
    }

    public void Push(int a)
    {
        if (a == 0) { return; }

        if (Peek() == -a)
        {
            Pop();
        }
        else
        {
            expression.Add(a);
        }
    }

    public void Clear()
    {
        expression = new List<int>();
    }

    private void Pop()
    {
        expression.RemoveAt(expression.Count - 1);
    }

    private int Peek()
    {
        if (expression.Count == 0) { return 0; }
        return expression[expression.Count - 1];
    }

    public bool Equals(GroupTheorySimplifier other)
    {
        if (this.expression.Count != other.expression.Count) { return false; }
        for (int i = 0; i < this.expression.Count; i++)
        {
            Debug.Log(this.expression[i]);
            Debug.Log(other.expression[i]);
            if (this.expression[i] != other.expression[i]) { return false; }
        }
        return true;
    }

    public void Main()
    {
        // Testing
        GroupTheorySimplifier testSolution = new GroupTheorySimplifier(new int[] { 1, 2, -1, -2 });
        GroupTheorySimplifier testEquivalent = new GroupTheorySimplifier(new int[] { 1, 2, -1 });
        Debug.Log(testEquivalent.Equals(testSolution));
    }
}
