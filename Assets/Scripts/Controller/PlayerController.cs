using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// プレイヤー弾丸プレハブ
    /// </summary>
    [SerializeField]
    public GameObject BulletPrefab;

    /// <summary>
    /// マウス弾丸コントローラー
    /// </summary>
    public MouseClickController mouseClickController;

    /// <summary>
    /// ゲームシーンマネージャー
    /// </summary>
    public GameScript GameManager;

    /// <summary>
    /// 残り弾数
    /// </summary>
    [SerializeField]
    public int remainsShot;

    /// <summary>
    /// 残り弾数表示
    /// </summary>
    [SerializeField]
    public Text BulletRemainsText;

    /// <summary>
    /// 最大HP
    /// </summary>
    [SerializeField]
    private int MAXhealth;

    /// <summary>
    /// 現在HP
    /// </summary>
    [SerializeField]
    private int health;

    /// <summary>
    /// 現在HP図
    /// </summary>
    [SerializeField]
    public GameObject HealthImage;

    /// <summary>
    ///  スピード
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// 爆風アニメーション
    /// </summary>
    private Animator animator;

    private void Start()
    {
        // 初期値を画面に反映する
        BulletRemainsText.text = remainsShot.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        // 移動
        if (Input.GetKey(KeyCode.W))
        {
            // 上
            if (transform.position.y < 400f) transform.Translate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // 左
            if (transform.position.x > -720f) transform.Translate(speed * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // 下
            if (transform.position.y > -400f) transform.Translate(0, speed * -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // 右
            if (transform.position.x < 720f) transform.Translate(speed, 0, 0);
        }

        // 攻撃
        if (Input.GetMouseButtonDown(0))
        {
            // 弾が切れてないか
            if (remainsShot > 0)
            {
                // 弾生成
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);

                // 弾の数を減らす
                remainsShot--;
                // 画面に反映
                BulletRemainsText.text = remainsShot.ToString();
                // サウンド
                Sound.PlaySE("shot");
            }
            else
            {
                // サウンドのみ再生
                Sound.PlaySE("unableshot");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // 接触したオブジェクトのレイヤー情報読み込み
        string layername = LayerMask.LayerToName(coll.gameObject.layer);
        // 敵、マウスで攻撃する敵、 敵の弾、火炎
        if (layername == "Enemy" || layername == "FlickEnemy" || layername == "EnemyBullet" || layername == "Gimmick")
        {
            // インタフェースからどのオブジェクトに接触したか判定する
            int dmg = coll.gameObject.GetComponent<IDamage>().GetDamage();
            // ダメージ
            Damage(dmg);
            // サウンド
            Sound.PlaySE("damage");
            if (health <= 0)
            {
                // HPが0になったら破壊
                Breaking();
                //音楽停止
                Sound.StopBGM();
                // オブジェクト破壊
                Invoke("_Destroy", 0.2f);
            }
        }

        // アイテム
        else if (layername == "Items")
        {
            // アイテムパターン読み込み
            int pattern = coll.gameObject.GetComponent<ItemController>().GetItemPattern();

            // プレイヤー弾
            if (pattern == 0)
            {
                // 弾の数増やす
                remainsShot += 15;
                // 画面に反映
                BulletRemainsText.text = remainsShot.ToString();
                // サウンド
                Sound.PlaySE("pop");
            }
            else if (pattern == 1)
            {
                // 弾の数増やす
                mouseClickController.AddAmmo(15);
                // サウンド
                Sound.PlaySE("pop");
            }
            // シールド（回復）
            else if (pattern == 2)
            {
                // 回復
                Heal(30);
                // サウンド
                Sound.PlaySE("heal");
            }
        }
    }

    public void Damage(int dmg)
    {
        // ダメージ
        health = health - dmg;
        // HP表示更新
        ReloadHealthImage(health);
    }

    private void Heal(int healing)
    {
        // 回復
        health += healing;
        if (health > 100) health = 100;
        // HP表示更新
        ReloadHealthImage(health);
    }

    // HP表示更新
    private void ReloadHealthImage(int health)
    {
        HealthImage.GetComponent<RectTransform>().sizeDelta = new Vector2(health, HealthImage.GetComponent<RectTransform>().sizeDelta.y);

        //残りHPが30以下のとき赤色にする
        if (health <= 30)
        {
            HealthImage.GetComponent<Image>().color = new Color32(255, 0, 11, 255);
        }
        // それ以上のとき緑色にする
        else
        {
            HealthImage.GetComponent<Image>().color = new Color32(11, 255, 0, 255);
        }
    }

    // 爆発
    private void Breaking()
    {
        // サウンド
        Sound.PlaySE("Explode");

        // 爆風
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
    }

    private void _Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // ゲームオーバー呼び出し
        GameManager.GameOver();
    }
}