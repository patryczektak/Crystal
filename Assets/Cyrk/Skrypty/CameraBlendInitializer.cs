using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlendInitializer : MonoBehaviour
{
    [SerializeField] private float blendPeriod;
    [SerializeField] private Material blendMaterial;
    // Start is called before the first frame update
    void Start()
    {
        blendMaterial.SetFloat("_Period", blendPeriod);
        blendMaterial.SetFloat("_StartTime", -float.MaxValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
