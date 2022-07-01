using UnityEngine;
public class SuperPlatform : MonoBehaviour
{
    [SerializeField] private float speedX = 3f;
    [SerializeField] private float speedY = 3f;

    [SerializeField] private float leftPosition = 5f;
    [SerializeField] private float rightPosition = 10f;
    [SerializeField] private bool RightMove = true;

    [SerializeField] private float highPosition = 5f;
    [SerializeField] private float lowPosition = 10f;
    [SerializeField] private bool UpMove = false;

    private void Update()
    {
        Vector3 dirX = transform.right;
        Vector3 dirY = transform.up;

        if (transform.position.x > rightPosition)
        {
            RightMove = false;
        }
        else if (transform.position.x < leftPosition)
        {
            RightMove = true;
        }

        if (transform.position.y > highPosition)
        {
            UpMove = false;
        }
        else if (transform.position.y < lowPosition)
        {
            UpMove = true;
        }

        if (RightMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dirX, speedX * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - dirX, speedX * Time.deltaTime);
        }

        if (UpMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dirY, speedY * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - dirY, speedY * Time.deltaTime);
        }
    }
}
