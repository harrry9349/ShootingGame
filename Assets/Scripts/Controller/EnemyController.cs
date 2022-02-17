using UnityEngine;

/// <summary>�G�R���g���[���[�N���X</summary>
public class EnemyController : MonoBehaviour, IDamage
{
    /// <summary>�ړ����x</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>�G�e�ۃv���n�u</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    /// <summary>�����v���n�u</summary>
    [SerializeField]
    public GameObject ExplodePrefab;

    /// <summary>�̗�</summary>
    [SerializeField]
    private int health;

    /// <summary>�_���[�W</summary>
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
        //�ړ�
        transform.Translate(-moveSpeed, 0, 0, Space.World);
        //��ʊO�ɏo����j��
        if (transform.position.x < -750f || transform.position.y < -400f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>�I�u�W�F�N�g�ڐG��</summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);
        //Destroy(coll.gameObject);
        // �����̃I�u�W�F�N�g�̃��C���[���ǂݍ���
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
        if (collayername == "Player")
        {
            // �ڐG�������肪�v���C���[�Ȃ�G�j��
            // ����
            Breaking();
        }
        else
        {
            // �ڐG�������肪�e�ۂȂ�_���[�W�v�Z
            // �_���[�W�v�Z
            CalcDamage(selflayername, collayername);
            if (health <= 0)
            {
                // ����
                Breaking();
            }
        }
    }

    /// <summary>�G�̒e����</summary>
    private void GenBullet()
    {
        Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// �_���[�W�̎擾
    /// </summary>
    /// <returns>�_���[�W</returns>
    public int GetDamage()
    {
        return this.Damage;
    }

    /// <summary>�j��</summary>
    private void Breaking()
    {
        // �T�E���h
        Sound.PlaySE("Explode");
        // ����
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        // �G�I�u�W�F�N�g�j��
        Destroy(gameObject);
    }

    /// <summary>�_���[�W�v�Z </summary>
    /// <param name="selflayername">�����̃I�u�W�F�N�g�̃��C���[</param>
    /// <param name="collayername">�ڐG�����I�u�W�F�N�g�̃��C���[</param>

    private void CalcDamage(string selflayername, string collayername)
    {
        int dmg = 0;
        // �v���C���[�̒e
        if (collayername == "PlayerBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 120;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 60;
            }
        }
        // �}�E�X�̒e
        else if (collayername == "MouseBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 30;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 120;
            }
        }
        // �_���[�W
        health = health - dmg;
    }
}