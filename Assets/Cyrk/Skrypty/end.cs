using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    public bool e1;
    public bool e2;
    public bool e3;

    public plaer p;

    // Start is called before the first frame update
    void Start()
    {
        if (e1 == true)
        {
            p.s1 = 1;
        }

        if (e2 == true)
        {
            p.s2 = 1;
        }

        if (e3 == true)
        {
            p.s3 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
