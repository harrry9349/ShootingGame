using UnityEngine;

public class BombController : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>削除時間</summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>爆発の際ばらまく弾数</summary>
    [SerializeField]
    private int bullets;

    /// <summary>爆風プレハブ</summary>
    [SerializeField]
    public GameObject ExplodePrefab;

    /// <summary>敵弾丸プレハブ</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed = moveSpeed + 1f * Random.value;
        // deleteTime秒後に破壊予約
        Destroy(gameObject, deleteTime);
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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // 自分のオブジェクトのレイヤー情報読み込み
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // 接触したオブジェクトのレイヤー情報読み込み
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
        if (collayername == "PlayerBullet" || collayername == "MouseBullet")
        {
            // 接触した相手が弾丸なら強化弾丸をばらまく
            for (int i = 0; i < bullets; i++)
            {
                Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
            }
            // 爆風
            Breaking();
        }
    }

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