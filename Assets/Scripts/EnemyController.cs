using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public GameObject EnemyBulletPrefab;

    [SerializeField]
    private int Health;

    [SerializeField]
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeed = 1f + 1f * Random.value;
        InvokeRepeating("GenBullet", 1, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-moveSpeed, 0, 0, Space.World);

        if (transform.position.x < -750f || transform.position.y < -400f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(gameObject.name);
        //Destroy(coll.gameObject);
        Destroy(gameObject);
    }

    private void GenBullet()
    {
        Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    // ƒ_ƒ[ƒW‚ÌŽæ“¾
    public int GetDamage()
    {
        return this.Damage;
    }
}