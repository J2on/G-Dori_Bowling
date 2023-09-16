using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool buttonState;
    // Start is called before the first frame update
    void Start()
    {
        buttonState = false;
    }

    // Update is called once per frame

    public void ButtonDown()
    {
        buttonState = true;
    }

    public void ButtonUp()
    {
        buttonState = false;
    }

    public bool isButtonDown()
    {
        return buttonState;
    }
}
