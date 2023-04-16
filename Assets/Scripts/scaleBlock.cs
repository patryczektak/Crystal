using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleBlock : MonoBehaviour
{
    public float xB;
    public float yB;
    public float zB;

    public float xS;
    public float yS;
    public float zS;

    public float xM;
    public float yM;
    public float zM;

    public float timer;
    public float growTime;

    public int limit;
    public int fillLevel;
    public int halfFillLevel;
    public int unFillLevel;

    public int mediumLow;
    public int mediumHigh;

    public bool isMaxSize = false;
    public bool change = false;

    public bool sizeB;
    public bool sizeM;
    public bool sizeS;

    public bool needMidState;
    // Start is called before the first frame update
    void Start()
    {
        if(fillLevel >unFillLevel && fillLevel < limit)
        {
            sizeS = false;
            sizeM = true;
            sizeB = false;
        }

        if (fillLevel == limit)
        {
            sizeS = false;
            sizeM = false;
            sizeB = true;
        }

        if (fillLevel == unFillLevel)
        {
            sizeS = true;
            sizeM = false;
            sizeB = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if(fillLevel >= limit)
        //{
        //    fillLevel = limit;
        //    transform.localScale = new Vector3(xB, yB, zB);
        //}

        //if (fillLevel <= unFillLevel)
        //{
        //    fillLevel = unFillLevel;
        //    transform.localScale = new Vector3(xS, yS, zS);
        //}

        if( isMaxSize == false && change == false && fillLevel >= limit)
        {
            fillLevel = limit;
            change = true;
            StartCoroutine(Grow());
        }

        if (isMaxSize == true && change == false && fillLevel <= unFillLevel)
        {
            fillLevel = unFillLevel;
            change = true;
            StartCoroutine(Reduce());
        }

        
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 14)
        {
            fillLevel += 1;
            if(fillLevel >= limit)
            {
                fillLevel = limit;
            }

            if (change == false && fillLevel <= mediumHigh && fillLevel >= mediumLow && needMidState == true)
            {
                Debug.Log("MID");
                change = true;
                StartCoroutine(Mid());
            }
        }

        if (other.gameObject.layer == 15)
        {           
            fillLevel -= 1;
            if (fillLevel <= unFillLevel)
            {
                fillLevel = unFillLevel;
            }
        }

        if (change == false && fillLevel <= mediumHigh && fillLevel >= mediumLow && needMidState == true)
        {
            Debug.Log("MID");
            change = true;
            StartCoroutine(Mid());
        }

    }

    private IEnumerator Grow()
    {
        Vector3 startScale = transform.localScale;
        Vector3 maxScale = new Vector3(xB, yB, zB);
        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = true;
        change = false;
        timer = 0;
        fillLevel = limit;

        sizeS = false;
        sizeM = false;
        sizeB = true;
    }

    private IEnumerator Reduce()
    {
        //Debug.Log("smol");
        Vector3 startScale = transform.localScale;
        Vector3 minScale = new Vector3(xS, yS, zS);
        do
        {
            transform.localScale = Vector3.Lerp(startScale, minScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = false;
        change = false;
        timer = 0;
        fillLevel = unFillLevel;

        sizeS = true;
        sizeM = false;
        sizeB = false;
    }

    private IEnumerator Mid()
    {
        Debug.Log("mid");
        Vector3 startScale = transform.localScale;
        Vector3 minScale = new Vector3(xM, yM, zM);
        do
        {
            transform.localScale = Vector3.Lerp(startScale, minScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        change = false;
        timer = 0;

        sizeS = false;
        sizeM = true;
        sizeB = false;
    }
}
