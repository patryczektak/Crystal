using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class plaer : MonoBehaviour
{
   // public TextMeshPro time;
    public TMPro.TMP_Text timeM;
    public TMPro.TMP_Text time;
    public int konce;
    public int czas;
    public int czasM;

    public int s1;
    public int s2;
    public int s3;

    // Start is called before the first frame update
    void Start()
    {
        s1 = 0;
        s2 = 0;
        s3 = 0;
        konce = 0;
        czas = 0;
        czasM = 0;
        StartCoroutine(czasem());
    }

    // Update is called once per frame
    void Update()
    {
        konce = s1 + s2 + s3;
        if(czas == 60)
        {
            czasM += 1;
            czas = 0;
        }
    }

    public void OnC()
    {
        Application.Quit();
    }

    public void OffC()
    {

    }

    IEnumerator czasem()
    {
        yield return new WaitForSeconds(1f);
        if(konce != 3)
        {
            czas += 1;
            time.text = czas.ToString();
            timeM.text = czasM.ToString();
            StartCoroutine(czasem());
        }
    }
}
