using UnityEngine;

[CreateAssetMenu]
public class EnemyScriptableObject : ScriptableObject
{
    public int enemyNO;
    public string enemyName;
    public GameObject enemyPrefab;
    public GameObject enemyBulletPrefab;
    public int maxHealth;
    public int attackInerval;
    public int bodyPower;
    public int bulletPower;
    public float moveSpeedX;
    public float moveSpeedY;
    public int bulletCount;
    public int gainExp;
}