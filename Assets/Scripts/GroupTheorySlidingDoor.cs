using System.Collections;
using UnityEngine;

public class GroupTheorySlidingDoor : SlidingDoor
{
    public GroupElement[] solutionExpression;
    GroupTheorySimplifier solution;
    GroupTheorySimplifier input = new GroupTheorySimplifier();

    public void Start()
    {
        solution = new GroupTheorySimplifier(solutionExpression);
    }

    public void PushA()
    {
        input.Push(GroupElement.a);
    }

    public void PushAI()
    {
        input.Push(GroupElement.ai);
    }

    public void PushB()
    {
        input.Push(GroupElement.b);
    }

    public void PushBI()
    {
        input.Push(GroupElement.bi);
    }

    public void Confirm()
    {
        if (input.Equals(solution))
        {
            Slide();
        }
        else
        {
            input.Clear();
        }
    }
}