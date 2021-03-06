using UnityEngine;

public class BulletView : MonoBehaviour, IDamage
{
    /// <summary>生成されてから削除までの秒数</summary>
    public float deleteSeconds;

    /// <summary>ダメージ</summary>
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