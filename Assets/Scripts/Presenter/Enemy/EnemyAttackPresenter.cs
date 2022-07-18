using Assets.Scripts.Model.Enemies;
using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(CommonEnemy), typeof(WeaponMuzzle))]
public class EnemyAttackPresenter : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        var enemy = GetComponent<CommonEnemy>();
        var weaponMuzzle = GetComponent<WeaponMuzzle>();
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ => enemy.Attack());
        //enemy.Health.Subscribe(x =>if(x == 0) enemy.Explode(x)); TODOFenemyHealthPresenter‚ÅŠÇ—
        //enemy.Attacked += () => weaponMuzzle.Fire(enemy.weaponData[player.mainWeapon.WeaponNO.Value].bulletPrefab, player.mainWeapon);
    }
}