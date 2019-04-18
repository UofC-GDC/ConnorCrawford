using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Thing3d
{
    [SerializeField] private List<AudioClip> radioSongs;
    [SerializeField] private AudioSource source;
    [SerializeField] private BatteryInteract battery;

    [SerializeField] private Animator notesAnimator;

    private int i = 0;

    //protected new void Start()
    //{
    //    base.Start();
    //    source.loop = false;
    //    source.clip = radioSongs[i];
    //    source.Play();
    //}

    private void Update()
    {
        //if (!source.isPlaying)
        //{
        //    if (i >= radioSongs.Count - 1)
        //        i = 0;
        //    else
        //        i++;
        //    source.clip = radioSongs[i];
        //    source.Play();
        //}

        source.enabled = !battery.battery1 || !battery.battery2;
        notesAnimator.SetBool("NotesVisible", !battery.battery1 || !battery.battery2);

        notesAnimator.SetBool("Color", !battery.battery1 && !battery.battery2);
    }
}
