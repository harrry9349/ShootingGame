using Assets.Scripts.Model.Players;

using UnityEngine;

[RequireComponent(typeof(WeaponMuzzle), typeof(Player))]
public class WeaponPresenter : MonoBehaviour
{
    public void Awake()
    {
        var player = GetComponent<Player>();
        var weaponMuzzle = GetComponent<WeaponMuzzle>();
        player.Fired += () => weaponMuzzle.Fire(player.weaponData);
        //player.AltFired += () => weaponMuzzle.Fire(player.subWeaponData);
    }
}