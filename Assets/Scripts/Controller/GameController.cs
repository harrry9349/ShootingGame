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

    /// <summary>敵７プレハブ</summary>
    [SerializeField]
    public GameObject Enemy7Prefab;

    /// <summary>敵８プレハブ</summary>
    [SerializeField]
    public GameObject Enemy8Prefab;

    /// <summary>アイテム１プレハブ</summary>
    [SerializeField]
    public GameObject Item1Prefab;

    /// <summary>アイテム２プレハブ</summary>
    [SerializeField]
    public GameObject Item2Prefab;

    /// <summary>アイテム３プレハブ</summary>
    [SerializeField]
    public GameObject Item3Prefab;

    /// <summary>ギミックプレハブ</summary>
    [SerializeField]
    public GameObject GimmickPrefab;

    /// <summary>爆弾プレハブ</summary>
    [SerializeField]
    public GameObject BombPrefab;

    /// <summary>ボスプレハブ</summary>
    [SerializeField]
    public GameObject BossPrefab;

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
        InvokeRepeating("GenEnemySet", 3, 1);

        // スコア表示
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // 敵発生処理
    private void GenEnemySet()
    {
        // 1秒に1度敵発生処理を行う

        // ボス
        GenBoss();

        //　アイテム
        GenItem();

        //　通常敵(0秒～)
        GenEnemy();

        //　追加通常敵(90秒～)
        if (enemy_cnt > 90) GenAdditionalEnemy();

        //　強化敵(150秒～)
        if (enemy_cnt > 150) GenPowerEnemy();

        //　火炎
        GenGimmick();

        enemy_cnt++;
    }

    private void GenEnemy()
    {
        switch (enemy_cnt % 8)
        {
            case 0:
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 1:
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 2:
                break;

            case 3:
                if (enemy_cnt > 8) Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                else { Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 4:
                if (enemy_cnt > 8) Instantiate(Enemy4Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                else { Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 5:
                break;

            case 6:
                if (enemy_cnt > 16) Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                else { Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 7:
                if (enemy_cnt > 16) Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                else { Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            default:
                break;
        }
    }

    private void GenAdditionalEnemy()
    {
        switch (enemy_cnt % 10)
        {
            case 0:
                Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 1:
                Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 2:
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 3:
                Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 4:
                Instantiate(Enemy4Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 5:
                break;

            case 6:
                Instantiate(Enemy7Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 7:
                Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 8:
                break;

            case 9:
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            default:
                break;
        }
    }

    private void GenPowerEnemy()
    {
        // 3秒置きに強化敵を交互に出現させる
        if (enemy_cnt % 6 == 0)
        {
            Instantiate(Enemy7Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 6 == 3)
        {
            Instantiate(Enemy8Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
        }
    }

    private void GenBoss()
    {
        // 60秒、180秒、300秒にボスを出現させる
        int[] gen = { 60, 180, 300 };
        foreach (int cnt in gen)
            if (enemy_cnt == cnt)
            {
                Instantiate(BossPrefab, new Vector3(600f, 400f, 0), Quaternion.identity);
            }
    }

    private void GenItem()
    {
        // 開始3秒後から6秒おきにプレイヤー用弾丸を出現させる
        if (enemy_cnt % 6 == 3) Instantiate(Item1Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);

        // 開始8秒後から12秒おきにマウス用弾丸を出現させる
        if (enemy_cnt % 12 == 8) Instantiate(Item2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);

        // 開始10秒後から15秒おきに回復を出現させる
        if (enemy_cnt % 15 == 10) Instantiate(Item3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
    }

    private void GenGimmick()
    {
        // 開始5秒後から15秒おきに火炎か爆弾のどちらかを出現させる
        if (enemy_cnt % 15 == 5)
        {
            float rand = Random.value;
            if (rand > 0.5f)
            {
                Instantiate(GimmickPrefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(BombPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
            }
        }
    }

    // サウンドロード
    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "Thunderbolt");     // インゲーム画面の音楽
        Sound.LoadSE("pop", "Pop");                 // アイテム取得
        Sound.LoadSE("heal", "heal");               // 回復
        Sound.LoadSE("damage", "damage");           // ダメージ
        Sound.LoadSE("Explode", "Explode");         // 爆発
        Sound.LoadSE("shot", "Shot");               // 弾丸発射
        Sound.LoadSE("unableshot", "UnableShot");   // 発射できない
        Sound.LoadSE("flickshot", "FlickShot");     // マウス弾丸発射
    }
}