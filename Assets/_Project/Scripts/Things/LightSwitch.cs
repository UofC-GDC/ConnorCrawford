using UnityEngine;

public class LightSwitch : Thing
{
    [SerializeField] private Light roomLight;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource lightSound;

    private void Start()
    {
        animator.SetTrigger("LightOn");
        roomLight.enabled = true;
        lightSound.Stop();
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
        lightSound.Play();

        return null;
    }
}
