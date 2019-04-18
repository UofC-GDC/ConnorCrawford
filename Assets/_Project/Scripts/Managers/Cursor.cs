using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : Singleton<Cursor> 
{
    [SerializeField] private AudioSource mouseShake;
    [SerializeField] private new Camera camera;
    [SerializeField] private float cursorDistance;
    [SerializeField] private SpriteRenderer image;

    [SerializeField] private Sprite cursorNoInv;
    [SerializeField] private Sprite cursorInv;
    [SerializeField] private Sprite diamondCursorNoInv;
    [SerializeField] private Sprite diamondCursorInv;

    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        image.color = Color.white;
    }

    public void ShakeMouse()
    {
        Debug.Log("Mouse says you cannot", this);
        mouseShake.Play();
        StopAllCoroutines();
        StopAllCoroutines();
        StartCoroutine(MouseShake());
    }

    bool ms = false;

    private IEnumerator MouseShake()
    {
        ms = true;
        var prevCol = image.color;
        image.color = Color.red;
        yield return new WaitForSeconds(.1f);
        image.color = prevCol;
        ms = false;
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        transform.localPosition = ray.origin + ray.direction.normalized * cursorDistance;

        if (ms) return;

        if (StateManager.Instance.env.player.inventory == null)
        {
            if (DarknessManager.Instance.flashlightBlue)
                image.sprite = diamondCursorNoInv;
            else
                image.sprite = cursorNoInv;
        }
        else
        {
            if (DarknessManager.Instance.flashlightBlue)
                image.sprite = diamondCursorInv;
            else
                image.sprite = cursorInv;
        }

        if (StateManager.Instance.currentState.GetType() != typeof(GetInputState))
        {
            image.color = Color.grey;
            //var leftClicked = Input.GetMouseButtonDown(0);
            //var rightClicked = Input.GetMouseButtonDown(1);

            //if (leftClicked || rightClicked) ShakeMouse();

            //RaycastHit2D hit2D;
            //RaycastHit hit3D;

            //Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray2, out hit3D)) ;

            //hit2D = Physics2D.GetRayIntersection(ray2);
            //var target = hit2D ? hit2D.collider.gameObject.GetComponent<Thing>() : null;

            //localEnv.hit = hit2D;
            //localEnv.hit3D = hit3D;

            //new_env = localEnv;
            //if (leftClicked || rightClicked) return new WalkingState();
            //return this;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
