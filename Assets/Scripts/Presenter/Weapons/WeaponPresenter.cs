using Assets.Scripts.Model.Players;

using UnityEngine;

[RequireComponent(typeof(WeaponMuzzle), typeof(Player))]
public class WeaponPresenter : MonoBehaviour
{
    public void Awake()
    {
        var weapon = GetComponent<Player>();
        var weaponMuzzle = GetComponent<WeaponMuzzle>();
        weapon.Fired += () => weaponMuzzle.Fire();
    }
}