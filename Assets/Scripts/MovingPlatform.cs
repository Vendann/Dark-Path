using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float leftPosition = 5f;
    [SerializeField] private float rightPosition = 10f;
    [SerializeField] private bool RightMove = true;

    private void Update()
    {
        Vector3 dir = transform.right;

        if (transform.position.x > rightPosition)
        {
            RightMove = false;
        }
        else if (transform.position.x < leftPosition)
        {
            RightMove = true;
        }

        if (RightMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed * Time.deltaTime);
        }
    }

}
