using System;
using UnityEngine;

public class WeaponMuzzle : MonoBehaviour
{
    /// <summary>プレイヤーの弾丸のプレハブ</summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>発射速度</summary>
    [SerializeField]
    private float bulletSpeed;

    // Start is called before the first frame update
    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var isRightDirection = transform.lossyScale.x > 0;
        if (!isRightDirection) bullet.transform.localScale = bullet.transform.localScale * new Vector2(-1, 1);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
            (float)Math.Cos(transform.rotation.eulerAngles.z * (Math.PI / 180)) * bulletSpeed * (isRightDirection ? 1 : -1),
            (float)Math.Sin(transform.rotation.eulerAngles.z * (Math.PI / 180)) * bulletSpeed * (isRightDirection ? 1 : -1));
    }
}