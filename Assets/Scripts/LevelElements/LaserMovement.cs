using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float speed = 0.1f;
    public float height = 0.5f;
    private Vector3 startPosition;

    private BoxCollider boxCollider; // Référence au collider

    void Start()
    {
        startPosition = transform.position;
        boxCollider = GetComponent<BoxCollider>(); // Récupère le collider
    }

    void Update()
    {
        // Mouvement du laser en montée-descente
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Assure que le collider suit le laser
        if (boxCollider != null)
        {
            boxCollider.center = transform.InverseTransformPoint(transform.position);
        }
    }
}
