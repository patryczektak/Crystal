using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public fanWind power;

    public float amplitude;
    public float frequency;

    public Transform father;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        //posOffset = transform.position + father.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (power.h == true)
        {
            amplitude = 0.05f;
            frequency = 2f;

            posOffset = father.transform.position;

            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }

        if (power.m == true)
        {
            amplitude = 0.025f;
            frequency = 1f;

            posOffset = father.transform.position;

            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
    }
}
