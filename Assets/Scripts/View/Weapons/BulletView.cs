using UnityEngine;

public class BulletView : MonoBehaviour, IDamage
{
    /// <summary>��������Ă���폜�܂ł̕b��</summary>
    public float deleteSeconds;

    /// <summary>�_���[�W</summary>
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