using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject ExplodePrefab;

    [SerializeField]
    public int remainsShot;

    [SerializeField]
    public Text BulletRemainsText;

    /// 最大体力
    [SerializeField]
    private int MAXhealth;

    [SerializeField]
    public Text MAXHealthText;

    /// 体力
    [SerializeField]
    private int health;

    [SerializeField]
    public Text HealthText;

    ///  スピード
    [SerializeField]
    private float speed;

    private int interval;

    // Start is called before the first frame update
    private void Start()
    {
        // 初期値を画面に反映する
        BulletRemainsText.text = remainsShot.ToString();
        MAXHealthText.text = MAXhealth.ToString();
        HealthText.text = health.ToString();
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
        if (Input.GetMouseButtonDown(0))
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // 接触したオブジェクトのレイヤー情報読み込み
        string layername = LayerMask.LayerToName(coll.gameObject.layer);
        // 敵、マウスで攻撃する敵
        if (layername == "Enemy" || layername == "FlickEnemy")
        {
            // ダメージ
            int dmg = coll.gameObject.GetComponent<EnemyController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
            }
        }
        // 敵の弾
        else if (layername == "EnemyBullet")
        {
            // ダメージ
            int dmg = coll.gameObject.GetComponent<EnemyBulletController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
            }
        }
        // 火炎
        else if (layername == "Gmmick")
        {
            // ダメージ
            int dmg = coll.gameObject.GetComponent<FrameController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
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
        }
    }

    private void Damage(int dmg)
    {
        // ダメージ
        health = health - dmg;
        // 描画
        HealthText.text = health.ToString();
    }

    private void Breaking()
    {
        // HPの値を0に描画
        HealthText.text = "0";
        // プレイヤー破壊
        Destroy(gameObject);
        // 爆風
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
    }
}