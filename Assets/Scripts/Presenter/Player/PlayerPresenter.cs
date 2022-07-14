using Assets.Scripts.Model.Players;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerPresenter : MonoBehaviour
{
    private GameInputs gameInputs;
    private Player player;

    // Start is called before the first frame update
    public void Awake()
    {
        gameInputs = new GameInputs();
        player = GetComponent<Player>();

        gameInputs.Player.Fire.performed += _ => player.Fire();
        gameInputs.Player.AltFire.performed += _ => player.AltFire();
        gameInputs.Player.Reload.performed += _ => player.Reload();
        gameInputs.Player.UseAbility.performed += _ => player.UseAbility();
        gameInputs.Player.ChangeWeapon.performed += _ => player.ChangeWeapon();
        gameInputs.Enable();
    }

    // Update is called once per frame
    public void Update()
    {
        if (gameInputs.Player.MoveUp.IsPressed()) player.MoveUp();
        if (gameInputs.Player.MoveLeft.IsPressed()) player.MoveLeft();
        if (gameInputs.Player.MoveDown.IsPressed()) player.MoveDown();
        if (gameInputs.Player.MoveRight.IsPressed()) player.MoveRight();
        if (player.mainWeapon.IsAuto.Value == true) if (gameInputs.Player.AutoFire.IsPressed()) player.AutoFire();
        if (player.altWeapon.IsAuto.Value == true) if (gameInputs.Player.AutoAltFire.IsPressed()) player.AutoAltFire();
    }
}