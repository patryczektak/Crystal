using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyrkShow : MonoBehaviour
{

    public int entry;

    public GameObject cyrk3D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter(Collider other)
	{
        if (entry == 0) 
        {
            if (other.gameObject.layer == 8)
            {
                cyrk3D.SetActive(false);
            }
        }

        if (entry == 1)
        {
            if (other.gameObject.layer == 8)
            {
                cyrk3D.SetActive(true);
            }
        }
    }
}
