using Assets.Scripts.Model.Players;
using UniRx;
using UnityEngine;

public class PlayerHealthViewPresenter : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private PlayerHealthView playerHealthView;

    public void Start()
    {
        player.Health.Subscribe(x => playerHealthView.UpdateHealth(x));
    }
}