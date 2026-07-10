using UnityEngine;

public class MB_Weapon : MonoBehaviour
{


    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);

        if (hit.collider == null) return;

        Debug.Log(hit.collider.name);
    }
}
