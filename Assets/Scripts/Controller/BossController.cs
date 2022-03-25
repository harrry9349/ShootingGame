using UnityEngine;

public class BossController : MonoBehaviour, IDamage
{
    /// <summary>
    /// 消去時間
    /// </summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>初期移動速度X</summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>初期移動速度Y</summary>
    [SerializeField]
    private float moveSpeedY;

    /// <summary>敵弾丸プレハブ</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    /// <summary>強化敵弾丸プレハブ</summary>
    [SerializeField]
    public GameObject EnemyPowerBulletPrefab;

    /// <summary>体力</summary>
    [SerializeField]
    private int health;

    /// <summary>ダメージ</summary>
    [SerializeField]
    private int Damage;

    /// <summary>発射する弾の数</summary>
    [SerializeField]
    private int bullets;

    /// <summary>倒した時のスコア</summary>
    [SerializeField]
    public int score;

    /// <summary>敵パターン</summary>
    [SerializeField]
    private int enemyPattern;

    /// <summary>スコアコントローラー</summary>
    private GameObject scoreObject;

    /// <summary>敵クラス</summary>
    private Enemy enemy;

    /// <summary>移動パターン</summary>
    private int transformPattern;

    /// <summary>
    /// 爆風アニメーション
    /// </summary>
    private Animator animator;

    /// <summary>
    /// 移動速度
    /// </summary>
    private float transformX;

    private float transformY;

    // Start is called before the first frame update
    private void Start()
    {
        transformPattern = 0;
        InvokeRepeating("GenBullet", 2, 2);
        InvokeRepeating("SwitchTransform", 3, 3);
        enemy = new Enemy(health, Damage);
        scoreObject = GameObject.Find("ScoreController");
        // deleteTime秒後に破壊予約
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        //移動
        transform.Translate(-moveSpeedX, -moveSpeedY, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // 自分のオブジェクトのレイヤー情報読み込み
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // 接触したオブジェクトのレイヤー情報読み込み
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
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

    public int GetDamage()
    {
        return enemy.GetDamage();
    }

    /// <summary>敵の弾生成</summary>
    private void GenBullet()
    {
        for (int i = 0; i < bullets; i++) Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>破壊</summary>
    private void Breaking()
    {
        // サウンド
        Sound.PlaySE("Explode");
        // 爆風
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
        // オブジェクト破壊
        Invoke("_Destroy", 0.2f);
    }

    private void SwitchTransform()
    {
        float switchMoveSpeedX = 4f;
        float switchMoveSpeedY = 4f;
        switch (transformPattern)
        {
            case 0:
                this.moveSpeedX = switchMoveSpeedX;
                this.moveSpeedY = -switchMoveSpeedY;
                transformPattern = 1;
                break;

            case 1:
                this.moveSpeedX = 0;
                this.moveSpeedY = switchMoveSpeedY;
                transformPattern = 2;
                break;

            case 2:
                this.moveSpeedX = -switchMoveSpeedX;
                this.moveSpeedY = -switchMoveSpeedY;
                transformPattern = 3;
                break;

            case 3:
                this.moveSpeedX = 0;
                this.moveSpeedY = switchMoveSpeedY;
                transformPattern = 0;
                break;

            default:
                transformPattern = 0;
                break;
        }
    }

    private void _Destroy()
    {
        Destroy(gameObject);
    }
}