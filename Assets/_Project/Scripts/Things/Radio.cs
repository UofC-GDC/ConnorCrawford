﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Thing3d
{
    [SerializeField] private List<AudioClip> radioSongs;
    [SerializeField] private AudioSource source;

    private int i = 0;

    protected new void Start()
    {
        base.Start();
        source.loop = false;
        source.clip = radioSongs[i];
        source.Play();
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            if (i >= radioSongs.Count - 1)
                i = 0;
            else
                i++;
            source.clip = radioSongs[i];
            source.Play();
        }
    }
}