using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanWind : MonoBehaviour
{
    public fan fan;
    public scaleBlock scale;

    public Transform target;
    public Transform low;
    public Transform mid;
    public Transform high;

    public Transform midBig;
    public Transform highBig;

    public Transform midSmol;
    public Transform highSmol;

    public float timer;
    public float growTime;

    public bool h;
    public bool m;
    public bool l;
    //target on high position
    private bool ll = false;
    private bool mm = false;
    private bool hh = false;

    private bool mmB = false;
    private bool hhB = false;

    private bool mmS = false;
    private bool hhS = false;

    //small fan
    public ParticleSystem smol;
    //medium medium
    public ParticleSystem norm;
    //high high
    public ParticleSystem duzel;


    // Start is called before the first frame update
    void Start()
    {
        //smol = GetComponent<ParticleSystem>();
        //norm = GetComponent<ParticleSystem>();
        //duzel = GetComponent<ParticleSystem>();

        smol.Stop();
        norm.Stop();
        duzel.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        h = fan.isMaxSpeed;
        m = fan.isNeutral;
        l = fan.isMinSpeed;

        //clear bools
        if(l == true)
        {
            mm = false;
            hh = false;
            smol.Play();
            norm.Stop();
            duzel.Stop();
        }

        if (m == true)
        {
            ll = false;
            hh = false;
            norm.Play();
            smol.Stop();
            duzel.Stop();
        }

        if (h == true)
        {
            mm = false;
            ll = false;
            duzel.Play();
            norm.Stop();
            smol.Stop();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 20)
        {
            if (h == true && hh == false && scale.sizeB == false && scale.sizeS == false)
            {
                StartCoroutine(Up());
            }

            if (m == true && mm == false && scale.sizeB == false && scale.sizeS == false)
            {
                StartCoroutine(Mid());
            }

            if (h == true && hhB == false && scale.sizeB == true)
            {
                Debug.Log("wyzej");
                StartCoroutine(UpBig());
            }

            if (m == true && mmB == false &&  scale.sizeB == true)
            {
                StartCoroutine(MidBig());
            }

            if (h == true && hhS == false && scale.sizeS == true)
            {
                Debug.Log("nizej");
                StartCoroutine(UpSmol());
            }

            if (m == true && mmS == false && scale.sizeS == true)
            {
                StartCoroutine(MidSmol());
            }



            if (l == true && ll == false)
            {
                StartCoroutine(Low());
            }

            if (h == true && hh == true && target.transform.position.y <= high.transform.position.y)
            {
                target.transform.position = new Vector3(target.transform.position.x, high.transform.position.y, target.transform.position.z);
            }

            if (m == true && mm == true && target.transform.position.y<=mid.transform.position.y)
            {
                target.transform.position = new Vector3(target.transform.position.x, mid.transform.position.y, target.transform.position.z);
            }
        }
    }

    private IEnumerator Up()
    {       
            Debug.Log("UP");
            Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            Vector3 maxPosition = new Vector3(target.transform.position.x, high.transform.position.y, target.transform.position.z);
            do
            {
                target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
                timer += Time.deltaTime;
            hh = true;
            yield return null;
            }
            while (timer < growTime);
            timer = 0;
        hhB = false;
        hhS = false;
    }

    private IEnumerator Mid()
    {
        Debug.Log("Mid");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, mid.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            mm = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;
        mmS = false;
        mmB = false;
    }

    private IEnumerator Low()
    {
        Debug.Log("Low");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, low.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            ll = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;

    }

    private IEnumerator UpBig()
    {
        Debug.Log("UP");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, highBig.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            hhB = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;
        hh = false;
        hhS = false;

    }

    private IEnumerator MidBig()
    {
        Debug.Log("Mid");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, midBig.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            mmB = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;
        mm = false;
        mmS = false;
    }

    private IEnumerator UpSmol()
    {
        Debug.Log("UP");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, highSmol.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            hhS = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;
        hhB = false;
        hh = false;

    }

    private IEnumerator MidSmol()
    {
        Debug.Log("Mid");
        Vector3 startPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 maxPosition = new Vector3(target.transform.position.x, midSmol.transform.position.y, target.transform.position.z);
        do
        {
            target.transform.position = Vector3.Lerp(startPosition, maxPosition, timer / growTime);
            timer += Time.deltaTime;
            mmS = true;
            yield return null;
        }
        while (timer < growTime);
        timer = 0;
        mm = false;
        mmB = false;
    }

}
