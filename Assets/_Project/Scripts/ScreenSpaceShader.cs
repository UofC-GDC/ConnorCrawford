using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceShader : MonoBehaviour {

    public Material effect;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, effect);
    }
}
