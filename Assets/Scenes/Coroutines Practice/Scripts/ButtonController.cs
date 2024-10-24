using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPushed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isPushed)
        {
            isPushed = true;
            Debug.Log("Button was pushed");
            StartCoroutine(ButtonReset());
        }
    }

    IEnumerator ButtonReset()
    {
        yield return new WaitForSeconds(5);
        isPushed = false;
    }
}
