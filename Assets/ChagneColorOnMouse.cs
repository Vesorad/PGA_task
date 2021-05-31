using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagneColorOnMouse : MonoBehaviour
{
    [SerializeField] private Material material;
    private void OnMouseEnter()
    {
        material.color = Color.gray;
    }

    private void OnMouseExit()
    {
        material.color = Color.white;
    }
}
