using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public int speed = 3;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        pos = player.position;
        pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
