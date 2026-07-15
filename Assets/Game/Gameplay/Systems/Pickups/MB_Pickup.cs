using UnityEngine;

public abstract class MB_Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    protected Collider collision;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        collision = other;
        OnPickUp();
    }

    protected abstract void OnPickUp();
}
