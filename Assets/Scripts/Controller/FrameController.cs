using UnityEngine;

public class FrameController : MonoBehaviour, IDamage
{
    /// <summary>移動速度X<summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>移動速度Y<summary>
    [SerializeField]
    private float moveSpeedY;

    /// <summary>消去時間<summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>ダメージ<summary>
    [SerializeField]
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeedX = moveSpeedX * Random.value;
        this.moveSpeedY = moveSpeedY * Random.value;
        InvokeRepeating("ChangeTransformX", 1, 1);
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-moveSpeedX, -moveSpeedY, 0, Space.World);

        if (transform.position.y < -400f)
        {
            Destroy(gameObject);
        }
    }

    // 接触時の処理
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);
    }

    // ジグザグに動かす
    private void ChangeTransformX()
    {
        this.moveSpeedX *= -1;
    }

    // ダメージの取得
    public int GetDamage()
    {
        return this.Damage;
    }
}