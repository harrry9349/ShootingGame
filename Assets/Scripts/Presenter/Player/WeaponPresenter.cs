using Assets.Scripts.Model.Players;

using UnityEngine;

[RequireComponent(typeof(Player), typeof(WeaponMuzzle))]
public class WeaponPresenter : MonoBehaviour
{
    public void Awake()
    {
        var player = GetComponent<Player>();
        var weaponMuzzle = GetComponent<WeaponMuzzle>();
        player.Fired += () => weaponMuzzle.Fire(player.weaponData[player.mainWeapon.WeaponNO.Value].bulletPrefab, player.mainWeapon);
        player.AltFired += () => weaponMuzzle.Fire(player.weaponData[player.altWeapon.WeaponNO.Value].bulletPrefab, player.altWeapon);
    }
}