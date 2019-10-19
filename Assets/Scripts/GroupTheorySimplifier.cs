using System.Collections.Generic;

public enum GroupElement
{
    i = 0,
    a = 1, b = 2,
    ai = -1, bi = -2
}

public class GroupTheorySimplifier
{
    List<int> expression = new List<int>();
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
            if (this.expression[i] != other.expression[i]) { return false; }
        }
        return true;
    }
}

//    GroupTheorySimplifier solution = new GroupTheorySimplifier(new GroupElement[] {GroupElement.a, GroupElement.b, GroupElement.ai, GroupElement.bi});

//    public void Start()
//    {
//        // Testing
//        GroupTheorySimplifier testSolution = new GroupTheorySimplifier(new int[] { 1, 2, 3, 4, 5 });
//        GroupTheorySimplifier testEquivalent = new GroupTheorySimplifier(new int[] { 1, -1, 1, 3, -2, 5, -5, 2, -3, 2, 3, 4, -3, 4, -4, 3, 5 });
//        print(testEquivalent.Equals(testSolution));
//    }
//}
