using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public float speed = 5f;
    public string fanTag = "fan";

    private bool isCollidingWithFan = false;
    private Rigidbody rb;
    private GameObject currentFanObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.useGravity = false;
        rb.mass = 1;
    }

    private void FixedUpdate()
    {
        if (isCollidingWithFan)
        {
            Vector3 targetPosition = currentFanObject.transform.position + (Vector3.up * currentFanObject.transform.localScale.y);

            if (transform.position.y < targetPosition.y)
            {
                Vector3 moveDirection = targetPosition - transform.position;
                rb.MovePosition(transform.position + (moveDirection.normalized * speed * Time.fixedDeltaTime));
            }
            else
            {
                isCollidingWithFan = false;
            }
        }
        else
        {
           // rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(fanTag))
        {
            isCollidingWithFan = true;
            currentFanObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(fanTag) && other.gameObject == currentFanObject)
        {
            isCollidingWithFan = false;
            currentFanObject = null;
            rb.useGravity = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(fanTag) && other.gameObject != currentFanObject)
        {
            isCollidingWithFan = true;
            currentFanObject = other.gameObject;
            rb.useGravity = false;
        }
    }
}
