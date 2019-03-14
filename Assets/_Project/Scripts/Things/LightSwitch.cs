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
        lightSound.pitch = 1;
    }

    private string triggerString = "";
    private float soundPitch = 1;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (DarknessManager.Instance.doorOpen) return base.Action(env, ref player);

        if (!DarknessManager.Instance.roomLightOn)
        {
            triggerString = "LightOn";
            DarknessManager.Instance.RoomLightOn();
            soundPitch = 1;
        }
        else
        {
            triggerString = "LightOff";
            DarknessManager.Instance.RoomLightOff();
            soundPitch = .6f; ;
        }

        lightSound.pitch = soundPitch;
        animator.SetTrigger(triggerString);
        lightSound.Play();

        return null;
    }
}
