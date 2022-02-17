using UnityEngine;

/// <summary>敵コントローラークラス</summary>
public class EnemyController : MonoBehaviour, IDamage
{
    /// <summary>移動速度</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>敵弾丸プレハブ</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    /// <summary>爆風プレハブ</summary>
    [SerializeField]
    public GameObject ExplodePrefab;

    /// <summary>体力</summary>
    [SerializeField]
    private int health;

    /// <summary>ダメージ</summary>
    [SerializeField]
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeed = 1f + 1f * Random.value;
        InvokeRepeating("GenBullet", 1, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        //移動
        transform.Translate(-moveSpeed, 0, 0, Space.World);
        //画面外に出たら破壊
        if (transform.position.x < -750f || transform.position.y < -400f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>オブジェクト接触時</summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);
        //Destroy(coll.gameObject);
        // 自分のオブジェクトのレイヤー情報読み込み
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // 接触したオブジェクトのレイヤー情報読み込み
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
        if (collayername == "Player")
        {
            // 接触した相手がプレイヤーなら敵破壊
            // 爆風
            Breaking();
        }
        else
        {
            // 接触した相手が弾丸ならダメージ計算
            // ダメージ計算
            CalcDamage(selflayername, collayername);
            if (health <= 0)
            {
                // 爆風
                Breaking();
            }
        }
    }

    /// <summary>敵の弾生成</summary>
    private void GenBullet()
    {
        Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// ダメージの取得
    /// </summary>
    /// <returns>ダメージ</returns>
    public int GetDamage()
    {
        return this.Damage;
    }

    /// <summary>破壊</summary>
    private void Breaking()
    {
        // サウンド
        Sound.PlaySE("Explode");
        // 爆風
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        // 敵オブジェクト破壊
        Destroy(gameObject);
    }

    /// <summary>ダメージ計算 </summary>
    /// <param name="selflayername">自分のオブジェクトのレイヤー</param>
    /// <param name="collayername">接触したオブジェクトのレイヤー</param>

    private void CalcDamage(string selflayername, string collayername)
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
        // ダメージ
        health = health - dmg;
    }
}