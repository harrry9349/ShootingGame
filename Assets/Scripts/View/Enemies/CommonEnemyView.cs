using UnityEngine;

public class CommonEnemyView : MonoBehaviour
{
    /// <summary>ê∂ê¨Ç≥ÇÍÇƒÇ©ÇÁçÌèúÇ‹Ç≈ÇÃïbêî</summary>
    public float deleteSeconds;

    public void Start()
    {
        Destroy(gameObject, deleteSeconds);
    }

    // Start is called before the first frame update
    public void Attack(EnemyScriptableObject enemyData)
    {
        for (var cnt = 0; cnt < enemyData.bulletCount; cnt++) GenerateBullet(enemyData.enemyBulletPrefab, enemyData.bulletPower);
    }

    public void GenerateBullet(GameObject bulletPrefab, int bulletPower)
    {
        var bulletSpeedX = 600 * UnityEngine.Random.value;
        var bulletSpeedY = 1200 * UnityEngine.Random.value - 600;
        var bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        bullet.GetComponent<BulletView>().deleteSeconds = 3.5f * UnityEngine.Random.value + 1.5f;
        bullet.GetComponent<BulletView>().SetDamage(bulletPower);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeedX, bulletSpeedY);
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}