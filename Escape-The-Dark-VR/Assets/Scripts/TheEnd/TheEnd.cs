using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayLittle());
    }

    IEnumerator DelayLittle()
    {
        yield return new WaitForSeconds(5); //wait 5 secconds
        Application.Quit();
    }
}
