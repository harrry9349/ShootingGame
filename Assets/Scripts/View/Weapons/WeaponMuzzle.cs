using System;
using UniRx;
using UnityEngine;

public class WeaponMuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Fire(GameObject bulletPrefab, IWeapon weapon)
    {
        for (var cnt = 0; cnt < weapon.CntBurst.Value; cnt++)
        {
            Observable.TimerFrame(weapon.BurstInterval.Value * cnt)
            .Subscribe(_ => GenerateBullet(bulletPrefab, weapon))
            .AddTo(this);
        }
    }

    public void GenerateBullet(GameObject bulletPrefab, IWeapon weapon)
    {
        var bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x + 50, transform.position.y - 10), transform.rotation);
        bullet.GetComponent<BulletView>().deleteSeconds = weapon.Sustain.Value;
        bullet.GetComponent<BulletView>().SetDamage(weapon.Power.Value);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(
            (float)Math.Cos(transform.rotation.eulerAngles.z * (Math.PI / 180)) * weapon.BulletSpeed.Value,
            (float)Math.Sin(transform.rotation.eulerAngles.z * (Math.PI / 180)) * weapon.BulletSpeed.Value);
    }
}