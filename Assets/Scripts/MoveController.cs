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

        if (isOnTop && Input.GetKeyDown(KeyCode.Space)) // Jeœli gracz jest na szczycie platformy i wciœniêto klawisz Spacji
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Dodaj si³ê skoku
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
    //    if (collision.gameObject.CompareTag("Fan")) // Jeœli gracz opuœci³ platformê
    //    {
    //        isOnTop = false; // Ustaw zmienn¹ isOnTop na false
    //        rb.useGravity = true; // W³¹cz grawitacjê
    //        rb.constraints = RigidbodyConstraints.None; // Odblokuj pozycjê gracza i rotacjê
    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan"))
    //    {
    //        Debug.Log("kkol");
    //        isOnTop = true; // Ustaw zmienn¹ isOnTop na true
    //        rb.velocity = Vector3.zero; // Zatrzymaj gracza w miejscu
    //        rb.useGravity = false; // Wy³¹cz grawitacjê
    //        //rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; // Zablokuj pozycjê gracza w osi Y i rotacjê

    //        Vector3 topPoint = other.gameObject.transform.position + (other.gameObject.transform.up * (other.gameObject.transform.localScale.y / 2f));

    //        //rb.MovePosition(topPoint);
    //        StartCoroutine(MovePlayerToTopPoint(topPoint));
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Fan")) // Jeœli gracz opuœci³ platformê
    //    {
    //        isOnTop = false; // Ustaw zmienn¹ isOnTop na false
    //        rb.useGravity = true; // W³¹cz grawitacjê
    //        //rb.constraints = RigidbodyConstraints.None; // Odblokuj pozycjê gracza i rotacjê
    //    }
    //}


    //IEnumerator MovePlayerToTopPoint(Vector3 topPoint)
    //{
    //    float journeyTime = 0.5f; // Czas trwania podró¿y do punktu szczytowego
    //    float elapsedTime = 0f; // Czas, który up³yn¹³ od rozpoczêcia podró¿y

    //    Vector3 startingPos = transform.position; // Pocz¹tkowa pozycja gracza

    //    // Wykonaj interpolacjê liniow¹ pomiêdzy pocz¹tkow¹ pozycj¹ gracza a punktem szczytowym przez okreœlony czas trwania podró¿y
    //    while (elapsedTime < journeyTime)
    //    {
    //        transform.position = Vector3.Lerp(startingPos, topPoint, (elapsedTime / journeyTime));
    //        elapsedTime += Time.deltaTime * 0.5f;
    //        yield return null;
    //    }

    //    // Ustaw pozycjê gracza na punkt szczytowy
    //    transform.position = topPoint;
    //}
}
