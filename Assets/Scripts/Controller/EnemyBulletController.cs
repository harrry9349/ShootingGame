using UnityEngine;

public class EnemyBulletController : MonoBehaviour, IDamage
{
    [SerializeField]
    private float moveSpeedX;

    [SerializeField]
    private float moveSpeedY;

    [SerializeField]
    private float deleteTime;

    [SerializeField]
    private int Damage;

    // Start is called before the first frame update
    private void Start()
    {
        // �e�̃X�s�[�h��X,Y�Ƃ���-10f�`10f�̊�
        this.moveSpeedX = moveSpeedX * Random.value - 10f;
        this.moveSpeedY = moveSpeedY * Random.value - 10f;
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

    // �_���[�W�̎擾
    public int GetDamage()
    {
        return this.Damage;
    }
}