using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    [SerializeField] private Material mainMaterial;
    [SerializeField] private Color desiredColor;

    public void ChangeCollor()
    {
        mainMaterial.color = desiredColor;
    }
}
