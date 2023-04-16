using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlockMove : MonoBehaviour
{
    public Transform follower;
    public bool isOnTop = false;

    private Rigidbody rb;

    public bool freeBlock;

    private GameObject currentFan;
    //private Vector3 targetPosition; // nowy cel poruszania
    //private float moveSpeed = 3.0f;
    //public float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(freeBlock == true)
        {
            //rb.useGravity = false;
        }
    }

   
    void Update()
    {
        follower.transform.position = transform.position;
    }


    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan"))
    //    {
    //        //isOnTop = true; // Ustaw zmienn� isOnTop na true
    //        rb.velocity = Vector3.zero; // Zatrzymaj gracza w miejscu
    //        rb.useGravity = false; // Wy��cz grawitacj�


    //        if (other.gameObject.CompareTag(tag))
    //        {
    //            follower.transform.position = other.gameObject.transform.position;
    //            //elapsedTime = 0f;
    //        }

    //        Vector3 topPoint = other.gameObject.transform.position + (other.gameObject.transform.up * (other.gameObject.transform.localScale.y / 2f));

    //        //rb.MovePosition(topPoint);
    //        StartCoroutine(MovePlayerToTopPoint(topPoint));
    //    }
    //}

    //public void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan") && isOnTop == false && freeBlock == false)
    //    //if (other.gameObject.CompareTag("Fan") && isOnTop == false)
    //    {

    //        Vector3 topPoint = other.gameObject.transform.position + (other.gameObject.transform.up * (other.gameObject.transform.localScale.y / 2f));

    //        if (transform.position.y < topPoint.y)
    //        {
    //            // Uruchom procedur� poruszania si� na szczyt
    //            StartCoroutine(MovePlayerToTopPoint(topPoint));
    //        }
    //    }

    //    if (transform.position != other.gameObject.transform.position + (other.gameObject.transform.up * (other.gameObject.transform.localScale.y / 2f)))
    //    {
    //        isOnTop = false;
    //    }
    //}

   

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fan")) // Je�li gracz opu�ci� platform�
        {
            isOnTop = false; // Ustaw zmienn� isOnTop na false
            rb.useGravity = true; // W��cz grawitacj�
            rb.isKinematic = false;
        }
    }


    IEnumerator MovePlayerToTopPoint(Vector3 topPoint)
    {
        rb.isKinematic = true;
        float journeyTime = 0.5f; // Czas trwania podr�y do punktu szczytowego
        float elapsedTime = 0f; // Czas, kt�ry up�yn�� od rozpocz�cia podr�y

        Vector3 startingPos = transform.position; // Pocz�tkowa pozycja gracza

        // Wykonaj interpolacj� liniow� pomi�dzy pocz�tkow� pozycj� gracza a punktem szczytowym przez okre�lony czas trwania podr�y
        while (elapsedTime < journeyTime)
        {
            transform.position = Vector3.Lerp(startingPos, topPoint, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime * 0.5f;
            yield return null;
        }
        isOnTop = true;
        // Ustaw pozycj� gracza na punkt szczytowy
        transform.position = topPoint;

        elapsedTime = 0f;
    }

   
}
