using UnityEngine;
public class Portal : MonoBehaviour
{
    [SerializeField] private float TeleportX = 1f;
    [SerializeField] private float TeleportY = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.Teleport(TeleportX, TeleportY);
        }
    }
}
