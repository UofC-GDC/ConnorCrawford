using UnityEngine;

public class DummyThing : Thing
{
    private AudioSource audioSource = null;
    private bool noAudio = false;

    [Range(0,2)]
    [SerializeField] private float delayTime=.345f;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!noAudio)
        {
            if (audioSource == null)
            {
                var sourceTemp = GetComponent<AudioSource>();
                if (sourceTemp == null)
                {
                    noAudio = true;
                }
                else
                {
                    audioSource = sourceTemp;
                    audioSource.PlayDelayed(delayTime);
                }
            }
            else if (!audioSource.isPlaying)
            {
                audioSource.PlayDelayed(delayTime);
            }
        }

        return base.Action(env, ref player);
    }
}
