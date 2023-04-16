using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanHeight : MonoBehaviour
{
    //fan height elements

    public int scaleSize1;
    public int scaleSize2;
    public int scaleSize3;
    public int scaleSize4;

    public float height1;
    public float height2;
    public float height3;
    public float height4;


    public float scaleDuration = 1f;
    public float positionOffsetY = 0f;
    public float positionDuration = 1f;

    private bool isScaling = false;

    public Transform parentYPosition;
    public Transform heightTarget;

    private Animator anim;

    public float animSpeed1;
    public float animSpeed2;
    public float animSpeed3;
    public float animSpeed4;

    [Header("Start Height 1-4")]
    public int startHeight;

    // Start is called before the first frame update
    void Start()
    {
        //positionOffsetY = parentYPosition.transform.localPosition.y;
        anim = gameObject.GetComponent<Animator>();
        if (startHeight == 0)
            Height();

        if (startHeight == 1)
            Height1();

        if (startHeight == 2)
            Height2();

        if (startHeight == 3)
            Height3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Height();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Height1();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Height2();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Height3();
        }
    }

    public void Height()
    {
        ChangeScaleAndPosition(1, height1);
        anim.speed = animSpeed1;
    }

    public void Height1()
    {
        ChangeScaleAndPosition(2, height2);
        anim.speed = animSpeed2;
    }

    public void Height2()
    {
        ChangeScaleAndPosition(3, height3);
        anim.speed = animSpeed3;
    }

    public void Height3()
    {
        ChangeScaleAndPosition(4, height4);
        anim.speed = animSpeed4;
    }

    public void ChangeScaleAndPosition(int variant, float newYPosition)
    {

        if (isScaling)
        {
            Debug.Log("Cannot change scale. Scaling in progress.");
            return;
        }
        // Utw�rz klas� coroutine i przeka� do niej docelowy rozmiar i pozycj� obiektu
        StartCoroutine(ScaleAndMoveTo(new Vector3(variant switch
        {
            1 => 4,
            2 => 4,
            3 => 4,
            4 => 4,
            _ => transform.localScale.x
        }, variant switch
        {
            1 => scaleSize1,
            2 => scaleSize2,
            3 => scaleSize3,
            4 => scaleSize4,
            _ => transform.localScale.y
        }, variant switch
        {
            1 => 4,
            2 => 4,
            3 => 4,
            4 => 4,
            _ => transform.localScale.z
        }), new Vector3(transform.localPosition.x, newYPosition + positionOffsetY, transform.localPosition.z), scaleDuration, positionDuration));
    }

    // Coroutine, kt�ra p�ynnie skaluje i przesuwa obiekt w czasie
    private IEnumerator ScaleAndMoveTo(Vector3 targetScale, Vector3 targetPosition, float scaleDuration, float positionDuration)
    {
        isScaling = true;

        // Pobierz pocz�tkowy rozmiar i pozycj� obiektu
        Vector3 originalScale = heightTarget.transform.localScale;
        Vector3 originalPosition = heightTarget.transform.localPosition;

        // P�ynnie skaluj obiekt w kierunku docelowego rozmiaru przez okre�lony czas
        float scaleElapsedTime = 0f;
        while (scaleElapsedTime < scaleDuration)
        {
            heightTarget.transform.localScale = Vector3.Lerp(originalScale, targetScale, (scaleElapsedTime / scaleDuration));
            heightTarget.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, (scaleElapsedTime / positionDuration));
            scaleElapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ustaw dok�adny rozmiar obiektu na koniec animacji
        heightTarget.transform.localScale = targetScale;

        // P�ynnie przesu� obiekt w kierunku docelowej pozycji przez okre�lony czas
        //float positionElapsedTime = 0f;
        //while (positionElapsedTime < positionDuration)
        //{
        //    transform.position = Vector3.Lerp(originalPosition, targetPosition, (positionElapsedTime / positionDuration));
        //    positionElapsedTime += Time.deltaTime;
        //    yield return null;
        //}

        // Ustaw dok�adn� pozycj� obiektu na koniec animacji
        heightTarget.transform.localPosition = targetPosition;

        isScaling = false;
    }



}
