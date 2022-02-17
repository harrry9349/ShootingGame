using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームコントローラークラス
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>敵１プレハブ</summary>
    [SerializeField]
    public GameObject EnemyPrefab;

    /// <summary>敵２プレハブ</summary>
    [SerializeField]
    public GameObject Enemy2Prefab;

    /// <summary>敵３プレハブ</summary>
    [SerializeField]
    public GameObject Enemy3Prefab;

    /// <summary>敵４プレハブ</summary>
    [SerializeField]
    public GameObject Enemy4Prefab;

    /// <summary>敵５プレハブ</summary>
    [SerializeField]
    public GameObject Enemy5Prefab;

    /// <summary>敵６プレハブ</summary>
    [SerializeField]
    public GameObject Enemy6Prefab;

    /// <summary>アイテム１プレハブ</summary>
    [SerializeField]
    public GameObject Item1Prefab;

    /// <summary>アイテム２プレハブ</summary>
    [SerializeField]
    public GameObject Item2Prefab;

    /// <summary>ギミックプレハブ</summary>
    [SerializeField]
    public GameObject GimmickPrefab;

    /// <summary>
    /// スコア
    /// </summary>
    [SerializeField]
    public int score;

    /// <summary>
    /// スコア表示
    /// </summary>
    [SerializeField]
    public Text ScoreText;

    /// <summary>
    /// 敵出現カウント
    /// </summary>
    private int enemy_cnt = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // サウンド
        LoadSound();
        Sound.PlayBGM("ingame");

        // 敵発生処理のルーチン設定
        InvokeRepeating("GenEnemy", 1, 1);

        // スコア表示
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // 敵発生処理
    private void GenEnemy()
    {
        // 1秒に1度敵発生処理を行う
        if (enemy_cnt % 5 == 0)
        {
            Instantiate(Item1Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 1)
        {
            Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 2)
        {
            Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 3)
        {
            Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 4)
        {
            Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 10 == 5)
        {
            Instantiate(GimmickPrefab, new Vector3(-700f + 1400 * Random.value, 400, 0), Quaternion.identity);
        }
        enemy_cnt++;
    }

    // サウンドロード
    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "Thunderbolt");     // インゲーム画面の音楽
        Sound.LoadSE("pop", "Pop");                 // アイテム取得
        Sound.LoadSE("damage", "damage");           // ダメージ
        Sound.LoadSE("Explode", "Explode");         // 爆発
        Sound.LoadSE("shot", "Shot");               // 弾丸発射
        Sound.LoadSE("unableshot", "UnableShot");   // 発射できない
        Sound.LoadSE("flickshot", "FlickShot");     // マウス弾丸発射
    }

    // スコア加算
    public void AddScore(int addscore)
    {
        // スコア加算
        score += addscore;
        // スコア表示更新
        ScoreText.text = score.ToString();
    }
}