using UnityEngine;

/// <summary>敵コントローラークラス</summary>
public class EnemyController : MonoBehaviour, IDamage
{
    /// <summary>X移動速度</summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>Y移動速度</summary>
    [SerializeField]
    private float moveSpeedY;

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

    /// <summary>発射する弾の数</summary>
    [SerializeField]
    private int bullets;

    /// <summary>敵パターン</summary>
    [SerializeField]
    private int enemyPattern;

    /// <summary>倒した時のスコア</summary>
    [SerializeField]
    public int score;

    /// <summary>敵クラス</summary>
    private Enemy enemy;

    /// <summary>スコアコントローラー</summary>
    public GameObject scoreObject;

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeedX = moveSpeedX + 1f * Random.value;
        InvokeRepeating("GenBullet", 1, 1);
        enemy = new Enemy(health, Damage);
        scoreObject = GameObject.Find("ScoreController");
    }

    // Update is called once per frame
    private void Update()
    {
        //移動
        transform.Translate(-moveSpeedX, -moveSpeedY, 0, Space.World);
        //画面外に出たら破壊
        if (transform.position.x < -750f || transform.position.y < -500f || transform.position.y > 500f)
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
            health = health - enemy.CalcDamage(selflayername, collayername);
            if (health <= 0)
            {
                //スコア追加
                scoreObject.GetComponent<ScoreController>().AddScore(enemyPattern, score);
                // 爆風
                Breaking();
            }
        }
    }

    /// <summary>敵の弾生成</summary>
    private void GenBullet()
    {
        for (int i = 0; i < bullets; i++) Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// ダメージの取得
    /// </summary>
    /// <returns>ダメージ</returns>
    public int GetDamage()
    {
        return enemy.GetDamage();
    }

    /// <summary>破壊</summary>
    private void Breaking()
    {
        // サウンド
        Sound.PlaySE("Explode");
        // 爆風
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        // オブジェクト破壊
        Destroy(gameObject);
    }
}