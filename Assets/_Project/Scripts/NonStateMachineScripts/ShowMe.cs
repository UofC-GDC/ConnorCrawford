using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMe : MonoBehaviour 
{
    private void LateUpdate()
    {
        GetComponent<SpriteRenderer>().enabled = !DarknessManager.Instance.roomLightOn && !DarknessManager.Instance.day && !DarknessManager.Instance.doorOpen;
            }
}
