using UnityEngine;

public class CommonEnemyView : MonoBehaviour
{
    /// <summary>¶¬‚³‚ê‚Ä‚©‚çíœ‚Ü‚Å‚Ì•b”</summary>
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
        bullet.GetComponent<BulletDestroyer>().deleteSeconds = 3.5f * UnityEngine.Random.value + 1.5f;
        bullet.GetComponent<BulletDestroyer>().damage = bulletPower;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeedX, bulletSpeedY);
    }
}