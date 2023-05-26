using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEventButton : MonoBehaviour
{
    public bool pressButton;
    public bool IPressed;
    public float timeLeftToPress;

    //public int times = 0;

    // Update is called once per frame
    void Update()
    {
        if (pressButton)
        {
            StartCoroutine(QuickTimeEvent());
        }

        if (Input.anyKey)
        {
            //times++;
            IPressed = true;
            Debug.Log("Ura");
            StopAllCoroutines();
        }
    }

    IEnumerator QuickTimeEvent()
    {
        yield return new WaitForSeconds(timeLeftToPress);
        Debug.Log("NOOOOOO(((");
    }
}
