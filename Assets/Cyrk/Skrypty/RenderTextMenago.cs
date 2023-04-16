using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextMenago : MonoBehaviour
{
    [SerializeField] private Material setToMaterial;
    //powinno byæ 8 dla proby
    public int depth;
    private void Awake()
    {
        var tex = new RenderTexture(Screen.width, Screen.height, depth);
        Debug.Assert(tex.Create(), "Nie zblendowalo");

        Camera cam = GetComponent<Camera>();
        cam.targetTexture = tex;
        setToMaterial.SetTexture("_BlendTex", tex);
    }


}
