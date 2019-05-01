using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteract : Interatable3D
{
    // SO SORRY, CHANGE OF PLANS. This great code was done by Zahra VVV.


    //public Vector3 rotateAxis = Vector3.right;
    //public float rotateSpeed = 400;
    //private float mouseY;
    //private float angle;
    //private Dictionary<int, char> lockCombo = new Dictionary<int, char>
    //   {
    //       { 0, 'a'}, { 24, 'b' }, { 48, 'c' },
    //	{ 72, 'd'}, { 96, 'e' }, { 120, 'f' },
    //	{ 144, 'g'}, { 168, 'h' }, { 192, 'i' },
    //	{ 216, 'j'}, { 240, 'k' }, { 264, 'l' },
    //	{ 288, 'm'}, { 312, 'n' }, { 336, 'o' }
    //   };

    //public override void interact(StateManager.Env env, ref Player player)
    //   {
    //       float delta = mouseY - Input.mousePosition.y;
    //	float modifier = rotateSpeed / Screen.width;
    //       UpdateFields();
    //       //transform.RotateAround(transform.position, transform.TransformDirection(rotateAxis), delta * modifier);
    //       transform.Rotate(Vector3.right, delta * angle);
    //}

    //protected override void interactStart()
    //   {
    //	//get mouse's y position
    //	UpdateFields();
    //}

    //protected override void interactEnd()
    //   {
    //	//snap to nearest degree
    //}

    //private void UpdateFields()
    //   {
    //	mouseY = Input.mousePosition.y;
    //	//angle's origin is the middle of screen 
    //	//and measured from positive y-axis instead of x-axis
    //	float realtiveY = Input.mousePosition.y/Screen.height - 0.5f;
    //	float relativeX = Input.mousePosition.x/Screen.width - 0.5f;
    //	angle = Mathf.Atan2(realtiveY, relativeX) + Mathf.PI/2;  //in radians.
    //}


    // And this great code was done by Caelum VVVV.

    [SerializeField] private char startLetter;

    [SerializeField] private SafeManager safeManager;

    private List<char> letters = new List<char>() {'K', 'U', 'B', 'Q', 'O', 'X', 'N', 'L'};

    public int currentIndex = -1;
     
    private void Start()
    {
        letters.Reverse();
        for (int i = 0; i < letters.Count; i++)
        {
            if (letters[i] == startLetter) currentIndex = i;
        }
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        if (safeManager.CompleteCheck())
        {
            if (safeManager.key != null)
            {
                Debug.Log("YOU GOT THE KEY");
                safeManager.keyVis.SetActive(false);
                player.inventory = safeManager.key;
                safeManager.key = null;
            }
        }
    }

    protected override void interactStart()
    {
        transform.RotateAround(GetComponent<MeshCollider>().bounds.center, transform.up,  360f / 8f);
        currentIndex = (currentIndex+1) % letters.Count;
    }
}
