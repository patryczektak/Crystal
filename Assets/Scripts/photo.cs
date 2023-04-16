using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photo : MonoBehaviour
{
    //photo scale floats
    //B for biug scale
    public float xB;
    public float yB;
    public float zB;

    //S for small scale
    public float xS;
    public float yS;
    public float zS;

    //photo position floats
    public float xxB;
    public float yyB;
    public float zzB;

    public float xxS;
    public float yyS;
    public float zzS;

    public float timer;
    public float growTime;

    public bool isMaxSize = false;
    public bool change = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(change == false)
            {
                if(isMaxSize == false)
                {
                    change = true;
                    StartCoroutine(Grow());
                }
            }

            if (change == false)
            {
                if (isMaxSize == true)
                {
                    change = true;
                    StartCoroutine(Reduce());
                }
            }
        }
    }


    private IEnumerator Grow()
    {
        //Debug.Log("duz");
        Vector3 startScale = transform.localScale;
        Vector3 startPosition = transform.localPosition;
        Vector3 maxScale = new Vector3(xB, yB, zB);
        Vector3 maxPosition = new Vector3(xxB, yyB, zzB);
        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            transform.localPosition = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = true;
        change = false;
        timer = 0;
        
    }

    private IEnumerator Reduce()
    {
        //Debug.Log("smol");
        Vector3 startScale = transform.localScale;
        Vector3 startPosition = transform.localPosition;
        Vector3 minScale = new Vector3(xS, yS, zS);
        Vector3 minPosition = new Vector3(xxS, yyS, zzS);
        do
        {
            transform.localScale = Vector3.Lerp(startScale, minScale, timer / growTime);
            transform.localPosition = Vector3.Lerp(startPosition, minPosition, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = false;
        change = false;
        timer = 0;
    }
}
