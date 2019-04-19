using UnityEngine;

public class LightSwitch : Thing
{
    [SerializeField] private Light roomLight;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource lightSound;
    [SerializeField] private Thing doorUhOhInsight;

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
        if (DarknessManager.Instance.doorOpen) return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, doorUhOhInsight, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);

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
