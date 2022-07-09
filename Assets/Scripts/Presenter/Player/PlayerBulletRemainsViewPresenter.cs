using Assets.Scripts.Model.Players;
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

    public void Start()
    {
        player.mainWeapon.LoadingAmmo.Subscribe(x => playerBulletRemainsView.UpdateBulletRemains(x));
        player.mainWeapon.CurrentAmmo.Subscribe(x => playerMaxBulletView.UpdateCurrentBullet(x));
    }
}