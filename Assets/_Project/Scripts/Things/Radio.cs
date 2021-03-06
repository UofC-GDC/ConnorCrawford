﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Thing3d
{
    [SerializeField] private List<AudioClip> radioSongs;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource talkySource;
    [SerializeField] private BatteryInteract battery;

    [SerializeField] private Animator notesAnimator;

    [SerializeField] private RadioInteract radioInteract;

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
        talkySource.enabled = !battery.battery1 || !battery.battery2;

        if (!battery.battery1 && !battery.battery2) source.enabled = false;

        notesAnimator.SetBool("NotesVisible", !battery.battery1 || !battery.battery2);

        notesAnimator.SetBool("Color", !battery.battery1 && !battery.battery2);

        radioInteract.fixPlz();
    }
}
