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
    //        //isOnTop = true; // Ustaw zmienn¹ isOnTop na true
    //        rb.velocity = Vector3.zero; // Zatrzymaj gracza w miejscu
    //        rb.useGravity = false; // Wy³¹cz grawitacjê


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
    //            // Uruchom procedurê poruszania siê na szczyt
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
        if (other.gameObject.CompareTag("Fan")) // Jeœli gracz opuœci³ platformê
        {
            isOnTop = false; // Ustaw zmienn¹ isOnTop na false
            rb.useGravity = true; // W³¹cz grawitacjê
            rb.isKinematic = false;
        }
    }


    IEnumerator MovePlayerToTopPoint(Vector3 topPoint)
    {
        rb.isKinematic = true;
        float journeyTime = 0.5f; // Czas trwania podró¿y do punktu szczytowego
        float elapsedTime = 0f; // Czas, który up³yn¹³ od rozpoczêcia podró¿y

        Vector3 startingPos = transform.position; // Pocz¹tkowa pozycja gracza

        // Wykonaj interpolacjê liniow¹ pomiêdzy pocz¹tkow¹ pozycj¹ gracza a punktem szczytowym przez okreœlony czas trwania podró¿y
        while (elapsedTime < journeyTime)
        {
            transform.position = Vector3.Lerp(startingPos, topPoint, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime * 0.5f;
            yield return null;
        }
        isOnTop = true;
        // Ustaw pozycjê gracza na punkt szczytowy
        transform.position = topPoint;

        elapsedTime = 0f;
    }

   
}
