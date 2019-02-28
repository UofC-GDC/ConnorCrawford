using UnityEngine;

public class LightSwitch : Thing
{
    [SerializeField] private Light roomLight;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource lightSound;
    [SerializeField] private Door door;

    private void Start()
    {
        animator.SetTrigger("LightOn");
        roomLight.enabled = true;
        lightSound.Stop();
        lightSound.pitch = 1;
    }

    private bool lightOn = true;
    private string triggerString = "";
    private float soundPitch = 1;

    public override State Action()
    {
        if (door.open) return base.Action();

        if (!lightOn)
        {
            triggerString = "LightOn";
            lightOn = roomLight.enabled = true;
            soundPitch = 1;
        }
        else
        {
            triggerString = "LightOff";
            lightOn = roomLight.enabled = false;
            soundPitch = .6f;
        }

        lightSound.pitch = soundPitch;
        animator.SetTrigger(triggerString);
        lightSound.Play();

        return null;
    }
}
