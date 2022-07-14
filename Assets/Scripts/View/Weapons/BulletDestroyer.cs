using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    /// <summary>¶¬‚³‚ê‚Ä‚©‚çíœ‚Ü‚Å‚Ì•b”</summary>
    public float deleteSeconds;

    /// <summary>ƒ_ƒ[ƒW</summary>
    public int damage;

    public void Start()
    {
        Destroy(gameObject, deleteSeconds);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}