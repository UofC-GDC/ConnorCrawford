﻿using UnityEngine;
using UnityEngine.Audio;

public class RadioInteract : Interatable3D
{   
    [SerializeField] private SlideMe radioSlider;

    public Vector3 rotateAxis = Vector3.up;
    public float rotateSpeed = 400;
    private float mouseX;
    private float angleSum = 0f;
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private BatteryInteract batterys;

    public void fixPlz()
    {
        if (radioSlider != null)
            radioSlider.SetSlide(Mathf.Abs(angleSum / 360f));

        if (masterMixer != null)
        {
            if (batterys.battery1 && batterys.battery2)
            {
                masterMixer.SetFloat("RadioPitch", 1);
                //masterMixer.SetFloat("RadioVolume", -80);
                masterMixer.SetFloat("ConnerVoice", -80);
            }
        }
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        float delta = mouseX - Input.mousePosition.x;
        float modifier = rotateSpeed / Screen.height;

        // Rotating the radio body around. 
        // I know RotateBase does this but having 2 scripts onto 1 object causes competition between the 2 making 1 not work
        transform.RotateAround(transform.position, transform.TransformDirection(rotateAxis), delta * modifier);

        angleSum += (delta * modifier);

        // Rotating the slider along the radiobody axis
        if (radioSlider != null) // if statement here in case radioSlider object isn't set
        {
            radioSlider.SetSlide(Mathf.Abs(angleSum / 360f));
            if (masterMixer != null)
            {
                if (!batterys.battery1 || !batterys.battery2)
                {
                    masterMixer.SetFloat("RadioVolume", Mathf.Clamp(Mathf.Abs(delta), 0f, 5));
                    if (delta != 0)
                        masterMixer.SetFloat("RadioPitch", Random.Range(0.50f, 2.00f));
                    else
                        masterMixer.SetFloat("RadioPitch", 1);
                }
                else
                {
                    masterMixer.SetFloat("RadioPitch", 1);
                    masterMixer.SetFloat("RadioVolume", -80);
                }

                if (delta != 0)
                {
                    masterMixer.SetFloat("RadioToneVolume", Mathf.Clamp(Mathf.Abs(delta), 0f, 5));
                    float puttemHere = 0;
                    masterMixer.GetFloat("RadioTonePitch", out puttemHere);
                    masterMixer.SetFloat("RadioTonePitch", puttemHere + Random.Range(-.15f, .15f));
                }
                else
                {
                    masterMixer.SetFloat("RadioTonePitch", 1);
                    masterMixer.SetFloat("RadioToneVolume", -80);
                }

                if (batterys.battery1 && batterys.battery2)
                {
                    masterMixer.SetFloat("RadioPitch", 1);
                    //masterMixer.SetFloat("RadioVolume", -80);
                }
            }
        }

        mouseX = Input.mousePosition.x;
    }

    [SerializeField] private AnimationCurve connerRadioVoiceIncrease;

    public void SetConnerSound(float val)
    {
        if ((batterys.battery1 || batterys.battery2) && !(batterys.battery1 && batterys.battery2))
            masterMixer.SetFloat("ConnerVoice", Mathf.Lerp(-80, -25, connerRadioVoiceIncrease.Evaluate(1-val)));
        else if (batterys.battery1 && batterys.battery2)
        {
            masterMixer.SetFloat("ConnerVoice", -80);
        }
        else
            masterMixer.SetFloat("ConnerVoice", Mathf.Lerp(-80, 5, connerRadioVoiceIncrease.Evaluate(1 - val)));
    }

    protected override void interactStart()
    {
        mouseX = Input.mousePosition.x;
    }

    protected override void interactEnd()
    {
        if (masterMixer != null)
        {
            masterMixer.SetFloat("RadioTonePitch", 1);
            masterMixer.SetFloat("RadioToneVolume", -80);
            masterMixer.SetFloat("RadioPitch", 1);
            if (batterys.battery1 && batterys.battery2)
            {
                masterMixer.SetFloat("RadioPitch", 1);
                //masterMixer.SetFloat("RadioVolume", -80);
                masterMixer.SetFloat("ConnerVoice", -80);
            }
        }
    }
}
