using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoopA");
        StartCoroutine("LoopB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable LoopA()
    {
        while(true)
        {
            print("Loop A");
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerable LoopB()
    {
        while(true)
        {
            print("Loop B");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
