using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceShader : MonoBehaviour {

    public List<Material> effects;

    //void OnEnable()
    //{
    //    // dynamically create a material that will use our shader
    //    _material = new Material(Shader.Find("TKoU/ScreenSpaceSnow"));

    //    // tell the camera to render depth and normals
    //    GetComponent<Camera>().depthTextureMode |= DepthTextureMode.DepthNormals;
    //}

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // set shader properties

        // execute the shader on input texture (src) and write to output (dest)
        //Graphics.Blit(src, dest, effect);
        foreach (var effect in effects) Graphics.Blit(src, dest, effect);
    }
}
