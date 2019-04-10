using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private AudioSource bloop;

    private int frameCount = 0;

	void Update ()
    {
        frameCount++;   

        if (frameCount % 12 != 0) return;

        var rand = Random.value;

        switch (image.enabled)
        {
            case true:
                if (rand < 0.85) { image.enabled = false; }
                break;
            case false:
                if (rand > 0.85) { image.enabled = true; bloop.Play(); }
                break;
        }
	}
}
