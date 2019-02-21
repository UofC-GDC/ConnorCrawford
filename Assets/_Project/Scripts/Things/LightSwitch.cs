using UnityEngine;

public class LightSwitch : Thing
{
    [SerializeField] private Light roomLight;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetTrigger("LightOn");
        roomLight.enabled = true;
    }

    private bool lightOn;
    private string triggerString = "";

    public override State Action()
    {
        if (lightOn)
        {
            triggerString = "LightOn";
            lightOn = roomLight.enabled = true;
        }
        else
        {
            triggerString = "LightOff";
            lightOn = roomLight.enabled = false;
        }

        animator.SetTrigger(triggerString);

        return null;
    }
}
