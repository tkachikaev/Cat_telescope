using UnityEngine;

public class Potion : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().AddHealth(health);
            Destroy(this.gameObject);
        }
    }
}
