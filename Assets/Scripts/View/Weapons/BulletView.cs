using UnityEngine;

public class BulletView : MonoBehaviour, IDamage
{
    /// <summary>¶¬‚³‚ê‚Ä‚©‚çíœ‚Ü‚Å‚Ì•b”</summary>
    public float deleteSeconds;

    /// <summary>ƒ_ƒ[ƒW</summary>
    private int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void Start()
    {
        Destroy(gameObject, deleteSeconds);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}