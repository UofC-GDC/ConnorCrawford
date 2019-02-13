using UnityEngine;
using UnityEngine.EventSystems;

public class PauseClosingField : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject UIWithPauseMenu;
    PauseMenu pauseMenu;

    // Resume when clicked
    public void OnPointerDown(PointerEventData eventData)
    {
        pauseMenu = UIWithPauseMenu.GetComponent<PauseMenu>();

        Debug.Log("Being clicked!!");
        pauseMenu.Resume();
    }
}
