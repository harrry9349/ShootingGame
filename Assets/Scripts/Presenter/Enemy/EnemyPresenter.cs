using Assets.Scripts.Model.Enemies;
using UnityEngine;

[RequireComponent(typeof(CommonEnemy), typeof(CommonEnemyView))]
public class EnemyPresenter : MonoBehaviour
{
    private CommonEnemy enemy;
    private CommonEnemyView enemyView;

    // Start is called before the first frame update
    public void Awake()
    {
        enemy = GetComponent<CommonEnemy>();
        enemyView = GetComponent<CommonEnemyView>();

        //enemy.Health.Subscribe(x => enemyView.Explode());
        enemy.Attacked += () => enemyView.Attack(enemy.enemyData);
        enemy.Exploded += () => enemyView.Explode();
    }

    public void Update()
    {
        enemy.Move();
    }



}