using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{

    [SerializeField] private float shakeMagnitude;
    [SerializeField] private AnimationCurve damping;

    private Vector3 initialPosition;
    private float shakeDuration = 0;

    [ContextMenu("TriggerShake")]
    private void setTriggerShake() { TriggerShake(2f); }

    public void TriggerShake(float shakeDuration)
    {
        this.shakeDuration = shakeDuration;
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update ()
    {
		if (shakeDuration > 0)
        {
           transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude * damping.Evaluate(shakeDuration);
   
           shakeDuration -= Time.deltaTime;
        }
        else
        {
           shakeDuration = 0f;
           transform.localPosition = initialPosition;
        }
	}
}
