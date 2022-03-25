using UnityEngine;

public class FrameController : MonoBehaviour, IDamage
{
    /// <summary>�ړ����xX<summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>�ړ����xY<summary>
    [SerializeField]
    private float moveSpeedY;

    /// <summary>��������<summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>�_���[�W<summary>
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

    // �ڐG���̏���
    private void OnTriggerEnter2D(Collider2D coll)
    {
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