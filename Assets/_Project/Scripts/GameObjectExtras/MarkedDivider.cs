using UnityEngine;

[ExecuteInEditMode]
public class MarkedDivider : MonoBehaviour
{
    private void Start()
    {
        Divider();
    }
    private void Update()
    {
        Divider();
    }
    void LateUpdate()
    {
        Divider();
    }

    private void Divider()
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

        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}
