using UnityEngine;
public class VertMovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float highPosition = 5f;
    [SerializeField] private float lowPosition = 10f;
    [SerializeField] private bool UpMove = false;

    private void Update()
    {
        Vector3 dir = transform.up;

        if (transform.position.y > highPosition)
        {
            UpMove = false;
        }
        else if (transform.position.y < lowPosition)
        {
            UpMove = true;
        }

        if (UpMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed * Time.deltaTime);
        }
    }
}
