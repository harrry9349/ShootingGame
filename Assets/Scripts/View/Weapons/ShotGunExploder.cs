using UnityEngine;

public class ShotGunExploder : MonoBehaviour
{
    [SerializeField]
    public GameObject bulletPrefab;

    /// <summary>¶¬‚³‚ê‚Ä‚©‚çíœ‚Ü‚Å‚Ì•b”</summary>
    public float deleteSeconds;

    /// <summary>ƒ_ƒ[ƒW</summary>
    public int damage;

    public void Start()
    {
        GenerateBullet();
        Destroy(gameObject, deleteSeconds);
    }

    public void GenerateBullet()
    {
        for (var i = 0; i < 10; i++)
        {
            var bulletSpeedX = 600 * UnityEngine.Random.value;
            var bulletSpeedY = 1200 * UnityEngine.Random.value - 600;
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<BulletView>().deleteSeconds = 0.4f * UnityEngine.Random.value + 0.2f;
            bullet.GetComponent<BulletView>().SetDamage(damage);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeedX, bulletSpeedY);
        }
    }
}