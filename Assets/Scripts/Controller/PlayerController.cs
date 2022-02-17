using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// プレイヤー弾丸プレハブ
    /// </summary>
    [SerializeField]
    public GameObject BulletPrefab;

    /// <summary>
    /// 爆風プレハブ
    /// </summary>
    [SerializeField]
    public GameObject ExplodePrefab;

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

    ///  スピード
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
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
        //if (Input.GetKeyDown(KeyCode.Space))
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 弾が切れてないか
            if (remainsShot > 0)
            {
                // 弾生成
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                Debug.Log(transform.position.x + "," + transform.position.y);

                // 弾の数を減らす
                remainsShot--;
                Debug.Log(remainsShot);
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
                // ゲームオーバー処理
                GameOver();
            }
        }

        // アイテム
        else if (layername == "Items")
        {
            // 弾の数増やす
            //int ammo = coll.gameObject.GetComponent<EnemyController>().GetAmmo();
            remainsShot += 5;
            // 画面に反映
            BulletRemainsText.text = remainsShot.ToString();
            // サウンド
            Sound.PlaySE("pop");
        }
    }

    private void Damage(int dmg)
    {
        // ダメージ
        health = health - dmg;
        // HP表示更新
        HealthImage.GetComponent<RectTransform>().sizeDelta = new Vector2((HealthImage.GetComponent<RectTransform>().sizeDelta.x - dmg), HealthImage.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void Breaking()
    {
        // サウンド
        Sound.PlaySE("Explode");
        // プレイヤー破壊
        Destroy(gameObject);
        // 爆風
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}