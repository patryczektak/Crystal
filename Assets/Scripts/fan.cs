using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    public float limit;
    public float fillLevel;
    public float unFillLevel;

    public bool isMaxSpeed = false;
    public bool isMinSpeed = false;
    public bool isNeutral = true;
    public bool change = false;

    public float xRotation;
    public float xRotation1;
    public float RotationSpeedSlow;
    public float RotationSpeedFast;
    public float RotationSpeedNormal;

    public Transform onlyFan;



    // Start is called before the first frame update
    void Start()
    {
        fillLevel = limit / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMaxSpeed == false && change == false && fillLevel >= limit)
        //{
        //    fillLevel = limit;
        //    change = true;
        //    StartCoroutine(SpeedUp());
        //}

        //if (isMaxSpeed == true && change == false && fillLevel <= unFillLevel)
        //{
        //    fillLevel = unFillLevel;
        //    change = true;
        //    StartCoroutine(SpeedDown());
        //}

        //transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, transform.eulerAngles.z);

        if (isMaxSpeed == false && isNeutral == false && isMinSpeed == true) 
        {
            onlyFan.transform.Rotate(Vector3.up * (RotationSpeedSlow * Time.deltaTime));
        }

        if (isMaxSpeed == true && isNeutral == false && isMinSpeed == false)
        {
            onlyFan.transform.Rotate(Vector3.up * (RotationSpeedFast * Time.deltaTime));
        }

        if (isMaxSpeed == false && isNeutral == true && isMinSpeed == false)
        {
            onlyFan.transform.Rotate(Vector3.up * (RotationSpeedNormal * Time.deltaTime));
        }



    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 17)
        {
            //Debug.Log("14");
            fillLevel += 1;
            if (fillLevel >= limit)
            {
                fillLevel = limit;
                isMaxSpeed = true;
                isMinSpeed = false;
                isNeutral = false;
            }

            if(fillLevel >= 10 && fillLevel <= 30)
            {
                //Debug.LogError("yeay");
                isMaxSpeed = false;
                isMinSpeed = false;
                isNeutral = true;
            }

        }

        if (other.gameObject.layer == 18)
        {

            fillLevel -= 1;

            if (fillLevel <= unFillLevel)
            {
                fillLevel = unFillLevel;
                isMinSpeed = true;
                isMaxSpeed = false;
                isNeutral = false;
            }

            if (fillLevel >= 10 && fillLevel <= 30)
            {
                //Debug.LogError("yeay2");
                isNeutral = true;
                isMaxSpeed = false;
                isMinSpeed = false;
            }
        }
    }

    //private IEnumerator SpeedUp()
    //{
    //    Debug.Log("duz");
    //    Vector3 startScale = transform.localScale;
    //    Vector3 maxScale = new Vector3(xB, yB, zB);
    //    do
    //    {
    //        transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //    while (timer < growTime);

    //    isMaxSpeed = true;
    //    change = false;
    //    timer = 0;
    //    fillLevel = limit;
    //}

    //private IEnumerator SpeedDown()
    //{
    //    Debug.Log("smol");
    //    Vector3 startScale = transform.localScale;
    //    Vector3 minScale = new Vector3(xS, yS, zS);
    //    do
    //    {
    //        transform.localScale = Vector3.Lerp(startScale, minScale, timer / growTime);
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //    while (timer < growTime);

    //    isMaxSpeed = false;
    //    change = false;
    //    timer = 0;
    //    fillLevel = unFillLevel;
    //}
}
