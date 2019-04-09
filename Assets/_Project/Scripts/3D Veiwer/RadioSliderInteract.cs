using UnityEngine;

/*
 * Place this script on the radio slider game object
 */
public class RadioSliderInteract : Interatable3D
{
    [SerializeField] private AudioSource radioStaticAudio;
    [SerializeField] private AnimationCurve audioCurve;

    private Vector3 startingPos;
    Vector3 movementVector = Vector3.right;
    private float movementFactor;

    private void Start()
    {
        startingPos = transform.position;
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        // Still need to work on this
        movementFactor = Input.mousePosition.x / Screen.height;
        movementFactor = Mathf.Clamp(movementFactor, 0, 3);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
