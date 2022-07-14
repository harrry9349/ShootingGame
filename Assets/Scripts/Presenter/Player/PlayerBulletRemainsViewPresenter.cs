using Assets.Scripts.Model.Players;
using System;
using UniRx;
using UnityEngine;

public class PlayerBulletRemainsViewPresenter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Player player;

    [SerializeField]
    private PlayerBulletRemainsView playerBulletRemainsView;

    [SerializeField]
    private PlayerMaxBulletView playerMaxBulletView;

    [SerializeField]
    private PlayerBulletRemainsView playerSubBulletRemainsView;

    [SerializeField]
    private PlayerMaxBulletView playerSubMaxBulletView;

    private IDisposable[] subscribeDisposable;

    public void Start()
    {
        SetSubscribe();
        player.ChangedWeapon += SetSubscribe;
    }

    private void SetSubscribe()
    {
        foreach (var disposable in subscribeDisposable ?? Array.Empty<IDisposable>()) disposable.Dispose();
        subscribeDisposable = new[]
        {
            player.mainWeapon.LoadingAmmo.Subscribe(x => playerBulletRemainsView.UpdateBulletRemains(x)),
            player.mainWeapon.CurrentAmmo.Subscribe(x => playerMaxBulletView.UpdateCurrentBullet(x)),
            player.altWeapon.LoadingAmmo.Subscribe(x => playerSubBulletRemainsView.UpdateBulletRemains(x)),
            player.altWeapon.CurrentAmmo.Subscribe(x => playerSubMaxBulletView.UpdateCurrentBullet(x)),
        };
    }
}