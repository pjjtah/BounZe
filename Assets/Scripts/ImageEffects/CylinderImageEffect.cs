using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Image Effects Ultra/Cylinder", order = 1)]
public class CylinderImageEffect : BaseEffect
{
    [SerializeField]

    // Find the Fisheye shader source.
    public override void OnCreate()
    {
        baseMaterial = new Material(Resources.Load<Shader>("Shaders/CylinderImageEffect"));

    }

    public override void Render(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, baseMaterial);
    }
}