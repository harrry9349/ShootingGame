using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Model.Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public event Action Fired;

        private readonly float LimitUP = 400f;
        private readonly float LimitLeft = -720f;
        private readonly float LimitDown = -400f;
        private readonly float LimitRight = 720f;
        private readonly int maxHealth = 100;
        private readonly IntReactiveProperty health = new(100);

        private int moveMaxSpeedX;

        private int moveMaxSpeedY;

        private IWeapon mainWeapon;
        private IWeapon subWeapon;

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
            mainWeapon = new OneShotWeapon(15, 30, 25, 30, 200, 25, 2);
            IDisposable subscription = Health.Subscribe(x =>
            {
                Debug.Log(x);
            });
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

        private void _Fire(bool primal)
        {
            if (primal) mainWeapon.Fire();
            Fired?.Invoke();
        }

        public void Reload()
        {
            Debug.Log("Reload");
            mainWeapon.Reload();
            health.Value -= 1;
        }

        public void UseAbility()
        {
            Debug.Log("UseAbility");
            mainWeapon.AddPower(1);
            mainWeapon.SubtractInterval(1);
            mainWeapon.AddMaxAmmo(1);
            mainWeapon.AddSustain(1);
        }

        public void AttachWeapon(IWeapon attachingWeapon, IWeapon attachedWeapon)
        {
            attachedWeapon = attachingWeapon;
        }

        public void Damage(int damage) => health.Value = health.Value < damage ? 0 : health.Value - damage;

        public void Heal(int cure) => health.Value = health.Value > maxHealth ? 0 : health.Value + cure;

        private void Update()
        {
        }
    }
}