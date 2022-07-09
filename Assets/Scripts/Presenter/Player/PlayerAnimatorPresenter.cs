using Assets.Scripts.Model.Players;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator), typeof(Player))]
public class PlayerAnimatorPresenter : MonoBehaviour
{
    private PlayerAnimator playerAnimator;

    public void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        var player = GetComponent<Player>();
        player.Fired += () => playerAnimator.Fire();
    }

    private void Update()
    {
        //if (beforeFrameVelocity != rigidbody2d.velocity)
        //{
        //    playerAnimator.UpdateMoveSpeed(rigidbody2d.velocity.x);
        //    playerAnimator.UpdateFallSpeed(rigidbody2d.velocity.y);
        //    beforeFrameVelocity = rigidbody2d.velocity;
        //}
    }
}