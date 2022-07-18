using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Model.Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public event Action Fired;

        public event Action AltFired;

        public event Action Exploded;

        public event Action ChangedWeapon;

        private readonly float LimitUP = 400f;
        private readonly float LimitLeft = -720f;
        private readonly float LimitDown = -400f;
        private readonly float LimitRight = 720f;
        private readonly int maxHealth = 100;
        private readonly IntReactiveProperty health = new(100);

        private int moveMaxSpeedX;

        private int moveMaxSpeedY;

        public IWeapon mainWeapon;
        public IWeapon altWeapon;

        public PlayerLevel playerLevel;

        private int weaponNO;

        [SerializeField]
        public WeaponScriptableObject[] weaponData;

        /// <summary>HP</summary>
        public ReadOnlyReactiveProperty<int> Health => health.ToReadOnlyReactiveProperty();

        //private Rigidbody2D rigidbody2d;

        private enum Direction
        {
            left,
            right,
            up,
            down
        }

        public void Awake()
        {
            //rigidbody2d = GetComponent<Rigidbody2D>();
            moveMaxSpeedX = 10;
            moveMaxSpeedY = 10;
            weaponNO = 0;
            mainWeapon = new OneShotWeapon(weaponData[weaponNO]);
            altWeapon = new OneShotWeapon(weaponData[1]);
        }

        public void MoveUp() => Move(Direction.up);

        public void MoveLeft() => Move(Direction.left);

        public void MoveDown() => Move(Direction.down);

        public void MoveRight() => Move(Direction.right);

        private void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    if (transform.position.y < LimitUP) transform.Translate(0, moveMaxSpeedY, 0);
                    break;

                case Direction.left:
                    if (transform.position.x > LimitLeft) transform.Translate(moveMaxSpeedX * -1, 0, 0);
                    break;

                case Direction.down:
                    if (transform.position.y > LimitDown) transform.Translate(0, moveMaxSpeedY * -1, 0);
                    break;

                case Direction.right:
                    if (transform.position.x < LimitRight) transform.Translate(moveMaxSpeedX, 0, 0);
                    break;
            }
        }

        public void Fire() => _Fire(true);

        public void AltFire() => _Fire(false);

        public void AutoFire() => _Fire(true);

        public void AutoAltFire() => _Fire(false);

        private void _Fire(bool primal)
        {
            if (primal) if (mainWeapon.Fire()) Fired?.Invoke();
            if (!primal) if (altWeapon.Fire()) AltFired?.Invoke();
        }

        public void Reload()
        {
            Sound.PlaySE("reload");
            Debug.Log("Reload");
            mainWeapon.Reload();
            health.Value -= 1;
        }

        public void UseAbility()
        {
            Sound.PlaySE("useAbility");
            Debug.Log("UseAbility");
            mainWeapon.AddPower(1);
            mainWeapon.SubtractInterval(1);
            mainWeapon.AddMaxAmmo(1);
            mainWeapon.AddSustain(1);
        }

        public void ChangeWeapon()
        {
            Debug.Log("ChangeWeapon:" + mainWeapon.WeaponViewName.Value);
            weaponNO += 1;
            weaponNO = weaponNO % 13;
            //mainWeapon = null;
            mainWeapon = new OneShotWeapon(weaponData[weaponNO]);
            ChangedWeapon?.Invoke();
            Debug.Log("ChangeWeapon:" + mainWeapon.WeaponViewName.Value);
        }

        public void Damage(int damage) => health.Value = health.Value < damage ? 0 : health.Value - damage;

        public void Heal(int cure) => health.Value = health.Value > maxHealth ? maxHealth : health.Value + cure;

        public void Explode()
        {
            Destroy(gameObject);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            var colLayerName = LayerMask.LayerToName(collision.gameObject.layer);
            if (colLayerName == "Enemy" || colLayerName == "EnemyBullet")
            {
                Damage(collision.gameObject.GetComponent<IDamage>().GetDamage());
                if (Health.Value == 0)
                {
                    Explode();
                }
            }
        }
    }
}