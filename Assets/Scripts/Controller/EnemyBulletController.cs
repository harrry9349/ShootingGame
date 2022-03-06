using UnityEngine;

public class EnemyBulletController : MonoBehaviour, IDamage
{
    private float moveSpeedX;
    private float moveSpeedY;

    [SerializeField]
    private float deleteTime;

    [SerializeField]
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        // 弾のスピードはX,Yともに-1f～1fの間
        this.moveSpeedX = 2f * Random.value - 1f;
        this.moveSpeedY = 2f * Random.value - 1f;
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(moveSpeedX, moveSpeedY, 0, Space.World);

        if (transform.position.x < -750f || transform.position.x > 750f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -400f || transform.position.y > 400f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);
    }

    // ダメージの取得
    public int GetDamage()
    {
        return this.Damage;
    }
}