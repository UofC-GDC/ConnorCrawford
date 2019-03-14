using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessManager : Singleton<DarknessManager> 
{
    public enum FlashLightState
    {
        ground,
        inHand,
        blue
    }

    [SerializeField] private Light              roomLight;
    [SerializeField] private ScreenSpaceShader  nightPallete;
    [SerializeField] private GameObject         flashLightDark;
    [SerializeField] private GameObject         pureDark;
    [SerializeField] private Door               door;


                        public bool roomLightOn     = true;

    [HideInInspector]   public FlashLightState currentFlashLightState = FlashLightState.ground;
    [HideInInspector]   public bool flashlightOn    = false;
    [HideInInspector]   public bool flashlightBlue  = false;

                        public bool day             = true;
                        public bool doorOpen        = true;


    private void Start()
    {
        if (roomLightOn)    RoomLightOn();
        else                RoomLightOff();

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
        roomLightOn = roomLight.enabled = true;
    }

    public void RoomLightOff()
    {
        roomLightOn = roomLight.enabled = false;
    }
    #endregion

    #region Flashlight Methods
    public void ResetFlashlight()
    {
        currentFlashLightState = FlashLightState.ground;
        flashlightOn    = false;
        flashlightBlue  = false;
    }

    public void PickupFlashlight()
    {
        currentFlashLightState = FlashLightState.inHand;
        flashlightOn    = true;
        flashlightBlue  = false;
    }

    public void BlueifyFlashlight()
    {
        currentFlashLightState = FlashLightState.inHand;
        flashlightOn    = true;
        flashlightBlue  = true;
    }
    #endregion

    #region Time Of Day Methods
    public void SetTimeToDay()
    {
        nightPallete.enabled = false;
        day = true;
    }

    public void SetTimeToNight()
    {
        nightPallete.enabled = true;
        day = false;
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
            if (flashlightOn)
            {
                flashLightDark.SetActive(true);
            }
            else
            {
                pureDark.SetActive(true);
                if (badBlackTimer <= 5f)
                    badBlackTimer += Time.deltaTime;
                else
                {
                    runTheDoorCutscene = true;
                }
            }
        }
        else
        {
            runTheDoorCutscene = false;
            badBlackTimer = 0;
            flashLightDark.SetActive(false);
            pureDark.SetActive(false);
        }
    }

    public State DoorCutscene()
    {
        CutScene c = (CutScene)ScriptableObject.CreateInstance(typeof(CutScene));
        var line1 = new CutScene.Line();
        line1.arg = door.gameObject;
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
