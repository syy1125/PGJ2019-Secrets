using System.Collections;
using UnityEngine;

public class GroupTheorySlidingDoor : MonoBehaviour
{
    public GroupElement[] solutionExpression;
    GroupTheorySimplifier solution;
    GroupTheorySimplifier input = new GroupTheorySimplifier();

    SlidingDoor door;

    public void Start()
    {
        solution = new GroupTheorySimplifier(solutionExpression);
        door = GetComponent<SlidingDoor>();
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
            door.Slide();
        }
        else
        {
            input.Clear();
        }
    }
}