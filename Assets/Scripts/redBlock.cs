using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBlock : MonoBehaviour
{
    public int limit;
    public int fillLevel;

    public bool fill;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fill == true)
        {
            target.SetActive(true);
        }

        if (fill == false)
        {
            target.SetActive(false);
        }

        if(fillLevel >= limit)
        {
            fill = true;
        }

        if (fillLevel < limit)
        {
            fill = false;
        }
    }

  

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 14)
        {
            fillLevel += 1;
            Debug.Log("au");
        }
    }
}
