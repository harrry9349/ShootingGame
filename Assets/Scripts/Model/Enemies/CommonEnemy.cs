using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Model.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CommonEnemy : MonoBehaviour, IDamage
    {
        public event Action Attacked;

        public event Action Exploded;

        private readonly float LimitUP = 600f;
        private readonly float LimitLeft = -920f;
        private readonly float LimitDown = -600f;
        private readonly float LimitRight = 920f;

        private readonly IntReactiveProperty health = new(100);

        /// <summary>HP</summary>
        public ReadOnlyReactiveProperty<int> Health => health.ToReadOnlyReactiveProperty();

        [SerializeField]
        public EnemyScriptableObject enemyData;

        private enum Direction
        {
            left,
            right,
            up,
            down
        }

        private enum MovePattern
        {
            horizontal,
            verticalUp,
            verticalDown,
            curve
        }

        [SerializeField]
        private MovePattern movePattern;

        public void Awake()
        {
            Observable.IntervalFrame(enemyData.attackInerval)
            .Subscribe(_ => Attack());
        }

        public void Move()
        {
            if (movePattern == MovePattern.horizontal) transform.Translate(enemyData.moveSpeedX * -1, 0, 0);
            if (movePattern == MovePattern.verticalUp) transform.Translate(enemyData.moveSpeedX * -1, enemyData.moveSpeedY, 0);
            if (movePattern == MovePattern.verticalDown) transform.Translate(enemyData.moveSpeedX * -1, enemyData.moveSpeedY * -1, 0);
            if (movePattern == MovePattern.curve) transform.Translate(enemyData.moveSpeedX * -1, enemyData.moveSpeedY * Mathf.Sin(Time.time * enemyData.angularSpeed), 0);
        }

        public void Damage(int damage) => health.Value = health.Value < damage ? 0 : health.Value - damage;

        public void Attack()
        {
            Attacked?.Invoke();
        }

        public int GetDamage()
        {
            return enemyData.bodyPower;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
            var colLayerName = LayerMask.LayerToName(collision.gameObject.layer);
            if (colLayerName == "Player")
            {
                // �ڐG�������肪�v���C���[�Ȃ�G�j��
                // ����
                Exploded?.Invoke();
            }
            else if (colLayerName == "PlayerBullet")
            {
                {
                    // �ڐG�������肪�e�ۂȂ�_���[�W�v�Z
                    Damage(collision.gameObject.GetComponent<IDamage>().GetDamage());
                    if (Health.Value == 0)
                    {
                        Exploded?.Invoke();
                    }
                }
            }
        }
    }
}