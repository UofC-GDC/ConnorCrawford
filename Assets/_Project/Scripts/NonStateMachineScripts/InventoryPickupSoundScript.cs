using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickupSoundScript : MonoBehaviour 
{
	object pastInv = null;

    [SerializeField] private AudioClip gain;
    [SerializeField] private AudioClip loss;

    private void Update () 
    {
        if (pastInv != (object)StateManager.Instance.env.player.inventory)
        {
            GetComponent<AudioSource>().clip = StateManager.Instance.env.player.inventory == null ? loss : gain;
            GetComponent<AudioSource>().Play();
            pastInv = StateManager.Instance.env.player.inventory;
        }
	}
}
