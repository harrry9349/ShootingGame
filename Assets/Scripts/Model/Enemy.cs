public class Enemy
{
    /// <summary>移動速度</summary>
    private float moveSpeed;

    /// <summary>体力</summary>
    private int Health;

    /// <summary>ダメージ</summary>
    private int Damage;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="movespeed">移動速度</param>
    /// <param name="health">体力</param>
    /// <param name="damage">ダメージ</param>
    public Enemy(int health, int damage)
    {
        Health = health;
        Damage = damage;
    }

    /// <summary>
    /// ダメージの取得
    /// </summary>
    /// <returns>ダメージ</returns>
    public int GetDamage()
    {
        return Damage;
    }

    /// <summary>ダメージ計算 </summary>
    /// <param name="selflayername">自分のオブジェクトのレイヤー</param>
    /// <param name="collayername">接触したオブジェクトのレイヤー</param>
    public int CalcDamage(string selflayername, string collayername)
    {
        int dmg = 0;
        // プレイヤーの弾
        if (collayername == "PlayerBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 120;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 60;
            }
        }
        // マウスの弾
        else if (collayername == "MouseBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 30;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 120;
            }
        }
        return dmg;
    }
}