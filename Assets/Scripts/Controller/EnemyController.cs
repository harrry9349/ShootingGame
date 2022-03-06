using UnityEngine;

/// <summary>�G�R���g���[���[�N���X</summary>
public class EnemyController : MonoBehaviour, IDamage
{
    /// <summary>X�ړ����x</summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>Y�ړ����x</summary>
    [SerializeField]
    private float moveSpeedY;

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

    /// <summary>���˂���e�̐�</summary>
    [SerializeField]
    private int bullets;

    /// <summary>�G�p�^�[��</summary>
    [SerializeField]
    private int enemyPattern;

    /// <summary>�|�������̃X�R�A</summary>
    [SerializeField]
    public int score;

    /// <summary>�G�N���X</summary>
    private Enemy enemy;

    /// <summary>�X�R�A�R���g���[���[</summary>
    public GameObject scoreObject;

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeedX = moveSpeedX + 1f * Random.value;
        InvokeRepeating("GenBullet", 1, 1);
        enemy = new Enemy(health, Damage);
        scoreObject = GameObject.Find("ScoreController");
    }

    // Update is called once per frame
    private void Update()
    {
        //�ړ�
        transform.Translate(-moveSpeedX, -moveSpeedY, 0, Space.World);
        //��ʊO�ɏo����j��
        if (transform.position.x < -750f || transform.position.y < -500f || transform.position.y > 500f)
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
            health = health - enemy.CalcDamage(selflayername, collayername);
            if (health <= 0)
            {
                //�X�R�A�ǉ�
                scoreObject.GetComponent<ScoreController>().AddScore(enemyPattern, score);
                // ����
                Breaking();
            }
        }
    }

    /// <summary>�G�̒e����</summary>
    private void GenBullet()
    {
        for (int i = 0; i < bullets; i++) Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// �_���[�W�̎擾
    /// </summary>
    /// <returns>�_���[�W</returns>
    public int GetDamage()
    {
        return enemy.GetDamage();
    }

    /// <summary>�j��</summary>
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