using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;

    private int frameCount = 0;

	void Update ()
    {
        frameCount++;   

        if (frameCount % 3 != 0) return;

        var rand = Random.value;

        switch (image.enabled)
        {
            case true:
                if (rand < 0.75) image.enabled = false;
                break;
            case false:
                if (rand > 0.75) image.enabled = true;
                break;
        }
	}
}
