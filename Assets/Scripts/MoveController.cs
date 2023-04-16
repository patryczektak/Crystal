using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 5.0f;
    public float jumpForce = 5.0f;
    private bool isOnTop = false;

    private Rigidbody rb;
    private Camera playerCamera;
    private float verticalRotation = 0.0f;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * speed;
        float sideSpeed = Input.GetAxis("Horizontal") * speed;
        Vector3 speedVector = transform.forward * forwardSpeed + transform.right * sideSpeed;
        rb.velocity = new Vector3(speedVector.x, rb.velocity.y, speedVector.z);

        // Rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (isOnTop && Input.GetKeyDown(KeyCode.Space)) // Je�li gracz jest na szczycie platformy i wci�ni�to klawisz Spacji
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Dodaj si�� skoku
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        
    }

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Fan")) // Je�li gracz opu�ci� platform�
    //    {
    //        isOnTop = false; // Ustaw zmienn� isOnTop na false
    //        rb.useGravity = true; // W��cz grawitacj�
    //        rb.constraints = RigidbodyConstraints.None; // Odblokuj pozycj� gracza i rotacj�
    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan"))
    //    {
    //        Debug.Log("kkol");
    //        isOnTop = true; // Ustaw zmienn� isOnTop na true
    //        rb.velocity = Vector3.zero; // Zatrzymaj gracza w miejscu
    //        rb.useGravity = false; // Wy��cz grawitacj�
    //        //rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; // Zablokuj pozycj� gracza w osi Y i rotacj�

    //        Vector3 topPoint = other.gameObject.transform.position + (other.gameObject.transform.up * (other.gameObject.transform.localScale.y / 2f));

    //        //rb.MovePosition(topPoint);
    //        StartCoroutine(MovePlayerToTopPoint(topPoint));
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan")) // Je�li gracz opu�ci� platform�
    //    {
    //        isOnTop = false; // Ustaw zmienn� isOnTop na false
    //        rb.useGravity = true; // W��cz grawitacj�
    //        //rb.constraints = RigidbodyConstraints.None; // Odblokuj pozycj� gracza i rotacj�
    //    }
    //}


    //IEnumerator MovePlayerToTopPoint(Vector3 topPoint)
    //{
    //    float journeyTime = 0.5f; // Czas trwania podr�y do punktu szczytowego
    //    float elapsedTime = 0f; // Czas, kt�ry up�yn�� od rozpocz�cia podr�y

    //    Vector3 startingPos = transform.position; // Pocz�tkowa pozycja gracza

    //    // Wykonaj interpolacj� liniow� pomi�dzy pocz�tkow� pozycj� gracza a punktem szczytowym przez okre�lony czas trwania podr�y
    //    while (elapsedTime < journeyTime)
    //    {
    //        transform.position = Vector3.Lerp(startingPos, topPoint, (elapsedTime / journeyTime));
    //        elapsedTime += Time.deltaTime * 0.5f;
    //        yield return null;
    //    }

    //    // Ustaw pozycj� gracza na punkt szczytowy
    //    transform.position = topPoint;
    //}
}
