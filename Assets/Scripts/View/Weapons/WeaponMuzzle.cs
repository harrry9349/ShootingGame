using System;
using UniRx;
using UnityEngine;

public class WeaponMuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Fire(WeaponScriptableObject weaponData)
    {
        for (var cnt = 0; cnt < weaponData.cntBurst; cnt++)
        {
            Observable.TimerFrame(weaponData.burstInterval * cnt)
            .Subscribe(_ => GenerateBullet(weaponData))
            .AddTo(this);
        }
    }

    public void GenerateBullet(WeaponScriptableObject weaponData)
    {
        var bullet = Instantiate(weaponData.bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<BulletDestroyer>().deleteSeconds = weaponData.sustain;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
            (float)Math.Cos(transform.rotation.eulerAngles.z * (Math.PI / 180)) * weaponData.bulletSpeed,
            (float)Math.Sin(transform.rotation.eulerAngles.z * (Math.PI / 180)) * weaponData.bulletSpeed);
    }
}