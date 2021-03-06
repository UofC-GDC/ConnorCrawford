﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessManager : Singleton<DarknessManager> 
{

    [SerializeField] private Light              roomLight;
    [SerializeField] private ScreenSpaceShader  nightPallete;
    [SerializeField] private ScreenSpaceShader  blueFlashlightEffect;
    [SerializeField] private GameObject         flashLightDark;
    [SerializeField] private GameObject         pureDark;
    [SerializeField] private GameObject         flashLightUI;
    [SerializeField] private GameObject         flashLightUIBlue;
    [SerializeField] private GameObject         cursor;
    [SerializeField] private Door               door;
    [SerializeField] private GameObject         doorLoc;
    [SerializeField] private Animator           starsFullAnimator;


                        public bool roomLightOn         = true;

  /*[HideInInspector]*/ public bool flashlightInHand    = false;
  /*[HideInInspector]*/ public bool flashlightPowered   = false;
  /*[HideInInspector]*/ public bool flashlightBlue      = false;

                        public bool day                 = true;
                        public bool doorOpen            = true;
                        public bool powerOn             = false;

                        public bool act2                = false;


    private void Start()
    {
        if (roomLightOn)    RoomLightOn();
        else                RoomLightOff();

        if(!act2)
            ResetFlashlight();

        if(day) SetTimeToDay();
        else    SetTimeToNight();

        if (doorOpen)   OpenDoor();
        else            CloseDoor();

        ManageLight();
    }

    #region Room Light Methods
    public void RoomLightOn()
    {
        if (!day && powerOn) return;
        roomLightOn = roomLight.enabled = true;
    }

    public void RoomLightOff()
    {
        if (!day) return;
        roomLightOn = roomLight.enabled = false;
    }
    #endregion

    #region Flashlight Methods
    public void ResetFlashlight()
    {
        flashlightPowered   = false;
        flashlightBlue      = false;
        flashlightInHand    = false;

        blueFlashlightEffect.enabled = false;
    }

    public void PowerFlashlight()
    {
        flashlightPowered = true;
        if (!flashlightBlue)
            Clock.Instance.SetClock(4);
    }

    public void DePowerFlashlight()
    {
        flashlightPowered = false;
    }

    public void BlueifyFlashlight()
    {
        flashlightBlue  = true;
        Clock.Instance.SetClock(5);
    }

    public void PickupFlashlight()
    {
        flashlightInHand = true;

        flashLightUI.transform.SetParent(cursor.transform, false);
        flashLightUI.transform.localPosition = new Vector3(0, 0, .25f);

        flashLightUIBlue.transform.SetParent(cursor.transform, false);
        flashLightUIBlue.transform.localPosition = new Vector3(0,0,1);

        flashLightDark.transform.SetParent(cursor.transform, false);
        flashLightDark.transform.localPosition = new Vector3(-0.633f, -0.202f, 0);
        flashLightDark.transform.localRotation = Quaternion.Euler(Vector3.zero);

        if(!flashlightBlue && !flashlightPowered)
            Clock.Instance.SetClock(3);
    }
    #endregion

    #region Time Of Day Methods
    [ContextMenu("Daytime Start")]
    public void SetTimeToDay()
    {
        nightPallete.enabled = false;
        day = true;

        AudioManager.Instance.MainThemeDay();
    }

    [ContextMenu("Nighttime Start")]
    public void SetTimeToNight()
    {
        nightPallete.enabled = true;
        day = false;

        AudioManager.Instance.MainThemeNight();
    }
    #endregion

    #region Door Methods
    public void OpenDoor()
    {
        doorOpen = true;
    }

    public void CloseDoor()
    {
        doorOpen = false;
    }
    #endregion

    private void LateUpdate()
    {
        ManageLight();
    }

    private float badBlackTimer = 0;

    public void ManageLight()
    {
        if (!roomLightOn && !day && !doorOpen)
        {
            StateManager.Instance.completeDarkness = true;
            if (!flashlightPowered)
            {
                pureDark.SetActive(true);
                flashLightUI.SetActive(false);
                flashLightUIBlue.SetActive(false);
                if (badBlackTimer <= 10f)
                    badBlackTimer += Time.deltaTime;
                else
                {
                    runTheDoorCutscene = true;
                }
            }
            else 
            {
                flashLightDark.SetActive(true);
                flashLightUI.SetActive(false);
                flashLightUIBlue.SetActive(false);
                if (flashlightBlue)
                {
                    blueFlashlightEffect.enabled = true;
                }
            }
            starsFullAnimator.SetBool("FadeIn", true);
            starsFullAnimator.SetBool("FadeOut", false);
        }
        else
        {
            StateManager.Instance.completeDarkness = false;
            if (flashlightPowered)
            {
                flashLightUI.SetActive(true);
                if (flashlightBlue)
                {
                    flashLightUIBlue.SetActive(true);
                    flashLightUI.SetActive(false);
                }
            }
            else
            {
                flashLightUI.SetActive(false);
                flashLightUIBlue.SetActive(false);
            }

            runTheDoorCutscene = false;
            badBlackTimer = 0;
            flashLightDark.SetActive(false);
            pureDark.SetActive(false);
            starsFullAnimator.SetBool("FadeOut", true);
            starsFullAnimator.SetBool("FadeIn", false);
            blueFlashlightEffect.enabled = false;
        }
    }

    public State DoorCutscene()
    {
        CutScene c = (CutScene)ScriptableObject.CreateInstance(typeof(CutScene));
        var line1 = new CutScene.Line();
        line1.arg = doorLoc;
        line1.verb = CutScene.Verb.WalkTo;

        var line2 = new CutScene.Line();
        line2.arg = door.gameObject;
        line2.verb = CutScene.Verb.DoAction;

        c.script = new List<CutScene.Line>();
        c.script.Add(line1);
        c.script.Add(line2);
        return   c.MakeState();
    }

    public bool runTheDoorCutscene = false;
}
