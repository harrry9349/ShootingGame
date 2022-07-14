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

        //enemy.Health.Subscribe(x => if(x == 0) enemyView.Explode());
        enemy.Attacked += () => enemyView.Attack(enemy.enemyData);
    }

    public void Update()
    {
        enemy.Move();
    }
}