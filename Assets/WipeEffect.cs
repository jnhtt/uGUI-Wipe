using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeEffect : MonoBehaviour
{
    [SerializeField]
    private Material wipeMaterial;

    private Camera wipeCamera;
    private Transform target;

    public float Radius { get; set; }

    public void Init(Camera cam, Transform target, float radius)
    {
        wipeCamera = cam;
        this.target = target;
        Radius = radius;
        wipeMaterial.SetFloat("_CenterX", 0f);
        wipeMaterial.SetFloat("_CenterY", 0f);
        wipeMaterial.SetFloat("_Radius", radius);
    }

    public void UpdateMaterial()
    {
        if (wipeCamera != null && wipeMaterial != null) {
            Vector3 screenPos = wipeCamera.WorldToScreenPoint(target.transform.position);

            float r = Screen.height * Radius;
            wipeMaterial.SetFloat("_CenterX", screenPos.x);
            wipeMaterial.SetFloat("_CenterY", screenPos.y);
            wipeMaterial.SetFloat("_Radius", r);
        }
    }
}