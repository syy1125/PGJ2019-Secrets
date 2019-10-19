using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplay : MonoBehaviour
{
    public GroupTheorySlidingDoor door;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.input.expression.Count == 0)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.green;
            text.text = "";
            foreach (int i in door.input.expression)
            {
                switch (i)
                {
                    case 1: { text.text += "A"; break; }
                    case -1: { text.text += "a"; break; }
                    case 2: { text.text += "B"; break; }
                    case -2: { text.text += "b"; break; }
                    default: { text.text += "?"; break; }
                }
            }
        }
    }
}
