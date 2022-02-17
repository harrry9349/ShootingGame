using UnityEngine;

public class FrameController : MonoBehaviour, IDamage
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
        this.moveSpeedX = 2f * Random.value;
        this.moveSpeedY = 1f * Random.value;
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

    // �ڐG���̏���
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    // �W�O�U�O�ɓ�����
    private void ChangeTransformX()
    {
        this.moveSpeedX *= -1;
    }

    // �_���[�W�̎擾
    public int GetDamage()
    {
        return this.Damage;
    }
}