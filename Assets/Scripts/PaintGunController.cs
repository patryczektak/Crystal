using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGunController : MonoBehaviour
{
    public ParticleSystem paintBlue;
    public ParticleSystem paintBlueRed;
    public ParticleSystem paintRed;
    public ParticleSystem paintRedGreen;
    public ParticleSystem paintGreen;
    public ParticleSystem paintGreenBlue;
    public ParticleSystem paintRedGreenBlue;




    public GameObject red;
    public GameObject redA;
    public GameObject green;
    public GameObject greenA;
    public GameObject blue;
    public GameObject blueA;

    public bool redB;
    public bool greenB;
    public bool blueB;

    public bool redUnlock;
    public bool blueUnlock;
    public bool greenUnlock;
    // Start is called before the first frame update
    void Start()
    {
        redB = false;
        greenB = false;
        blueB = false;

        redUnlock = true;
        blueUnlock = true;
        greenUnlock = true;
        //basicPaint.SetActive(false);
        ParticleSystem paintBlue = GetComponent<ParticleSystem>();
        ParticleSystem paintBlueRed = GetComponent<ParticleSystem>();
        ParticleSystem paintRed = GetComponent<ParticleSystem>();
        ParticleSystem paintRedGreen = GetComponent<ParticleSystem>();
        ParticleSystem paintGreen = GetComponent<ParticleSystem>();
        ParticleSystem paintGreenBlue = GetComponent<ParticleSystem>();
        ParticleSystem paintRedGreenBlue = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (redB == false && greenB == false && blueB == true)
            {
                paintBlue.Play();
            }

            if (redB == true && greenB == false && blueB == true)
            {
                paintBlueRed.Play();
            }

            if (redB == true && greenB == false && blueB == false)
            {
                paintRed.Play();
            }

            if (redB == true && greenB == true && blueB == false)
            {
                paintRedGreen.Play();
            }

            if (redB == false && greenB == true && blueB == false)
            {
                paintGreen.Play();
            }

            if (redB == false && greenB == true && blueB == true)
            {
                paintGreenBlue.Play();
            }

            if (redB == true && greenB == true && blueB == true)
            {
                paintRedGreenBlue.Play();
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            // basicPaint.SetActive(false);
            paintBlue.Stop();
            paintBlueRed.Stop();
            paintRed.Stop();
            paintRedGreen.Stop();
            paintGreen.Stop();
            paintGreenBlue.Stop();
            paintRedGreenBlue.Stop();
        }


        //kontrola widocznych farb
        //czerwona
        if(redB == false && redUnlock == true)
        {
            red.SetActive(true);
            redA.SetActive(false);
        }

        if (redB == true && redUnlock == true)
        {
            red.SetActive(false);
            redA.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //if(redB == false)
            //{
            //    redB = true;
            //}

            //if (redB == true)
            //{
            //    redB = false;
            //}

            redB = !redB;
        }

        if (blueB == false && blueUnlock == true)
        {
            blue.SetActive(true);
            blueA.SetActive(false);
        }

        if (blueB == true && blueUnlock == true)
        {
            blue.SetActive(false);
            blueA.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            blueB = !blueB;
        }

        if (greenB == false && greenUnlock == true)
        {
            green.SetActive(true);
            greenA.SetActive(false);
        }

        if (greenB == true && greenUnlock == true)
        {
            green.SetActive(false);
            greenA.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            greenB = !greenB;
        }
    }
}
