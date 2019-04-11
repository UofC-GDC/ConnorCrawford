using UnityEngine;

public class RadioInteract : Interatable3D
{   
    [SerializeField] private GameObject radioSlider;

    public Vector3 rotateAxis = Vector3.up;
    public float rotateSpeed = 400;
    private float mouseX;

    public override void interact(StateManager.Env env, ref Player player)
    {
        float delta = mouseX - Input.mousePosition.x;
        float modifier = rotateSpeed / Screen.height;

        // Rotating the radio body around. 
        // I know RotateBase does this but having 2 scripts onto 1 object causes competition between the 2 making 1 not work
        transform.RotateAround(transform.position, transform.TransformDirection(rotateAxis), delta * modifier);

        // Rotating the slider along the radiobody axis
        if (radioSlider != null) // if statement here in case radioSlider object isn't set
        {
            radioSlider.transform.RotateAround(transform.position, transform.up, delta * modifier);
        }

        mouseX = Input.mousePosition.x;
    }

    protected override void interactStart()
    {
        mouseX = Input.mousePosition.x;
    }
}
