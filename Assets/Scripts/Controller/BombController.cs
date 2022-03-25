using UnityEngine;

public class BombController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>�폜����</summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>�����̍ۂ΂�܂��e��</summary>
    [SerializeField]
    private int bullets;

    /// <summary>�����v���n�u</summary>
    [SerializeField]
    public GameObject ExplodePrefab;

    /// <summary>�G�e�ۃv���n�u</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed = moveSpeed + 1f * Random.value;
        // deleteTime�b��ɔj��\��
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        //�ړ�
        transform.Translate(-moveSpeed, 0, 0, Space.World);
        //��ʊO�ɏo����j��
        if (transform.position.x < -750f || transform.position.y < -400f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // �����̃I�u�W�F�N�g�̃��C���[���ǂݍ���
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
        if (collayername == "PlayerBullet" || collayername == "MouseBullet")
        {
            // �ڐG�������肪�e�ۂȂ狭���e�ۂ��΂�܂�
            for (int i = 0; i < bullets; i++)
            {
                Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
            }
            // ����
            Breaking();
        }
    }

    private void Breaking()
    {
        // �T�E���h
        Sound.PlaySE("Explode");
        // ����
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        // �I�u�W�F�N�g�j��
        Destroy(gameObject);
    }
}