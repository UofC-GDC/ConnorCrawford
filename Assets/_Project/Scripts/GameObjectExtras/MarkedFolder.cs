using UnityEngine;

[ExecuteInEditMode]
public class MarkedFolder : MonoBehaviour
{
    private void Start()
    {
        Folder();
    }
    private void Update()
    {
        Folder();
    }
    void LateUpdate ()
    {
        Folder();
    }

    private void Folder()
    {
        if (transform.localPosition != Vector3.zero)
            transform.position = Vector3.zero;
        if (transform.localRotation != Quaternion.identity)
            transform.localRotation = Quaternion.identity;
        if (transform.localScale != Vector3.zero)
            transform.localScale = Vector3.zero;

        foreach (Component component in GetComponents(typeof(Component)))
        {
            if (component != this && component != transform)
                DestroyImmediate(component);
        }
    }
}
