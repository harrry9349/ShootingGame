using UnityEngine;

public class BossController : MonoBehaviour, IDamage
{
    /// <summary>
    /// ��������
    /// </summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>�����ړ����xX</summary>
    [SerializeField]
    private float moveSpeedX;

    /// <summary>�����ړ����xY</summary>
    [SerializeField]
    private float moveSpeedY;

    /// <summary>�G�e�ۃv���n�u</summary>
    [SerializeField]
    public GameObject EnemyBulletPrefab;

    /// <summary>�����G�e�ۃv���n�u</summary>
    [SerializeField]
    public GameObject EnemyPowerBulletPrefab;

    /// <summary>�̗�</summary>
    [SerializeField]
    private int health;

    /// <summary>�_���[�W</summary>
    [SerializeField]
    private int Damage;

    /// <summary>���˂���e�̐�</summary>
    [SerializeField]
    private int bullets;

    /// <summary>�|�������̃X�R�A</summary>
    [SerializeField]
    public int score;

    /// <summary>�G�p�^�[��</summary>
    [SerializeField]
    private int enemyPattern;

    /// <summary>�X�R�A�R���g���[���[</summary>
    private GameObject scoreObject;

    /// <summary>�G�N���X</summary>
    private Enemy enemy;

    /// <summary>�ړ��p�^�[��</summary>
    private int transformPattern;

    /// <summary>
    /// �����A�j���[�V����
    /// </summary>
    private Animator animator;

    /// <summary>
    /// �ړ����x
    /// </summary>
    private float transformX;

    private float transformY;

    // Start is called before the first frame update
    private void Start()
    {
        transformPattern = 0;
        InvokeRepeating("GenBullet", 2, 2);
        InvokeRepeating("SwitchTransform", 3, 3);
        enemy = new Enemy(health, Damage);
        scoreObject = GameObject.Find("ScoreController");
        // deleteTime�b��ɔj��\��
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        //�ړ�
        transform.Translate(-moveSpeedX, -moveSpeedY, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // �����̃I�u�W�F�N�g�̃��C���[���ǂݍ���
        string selflayername = LayerMask.LayerToName(gameObject.layer);
        // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
        string collayername = LayerMask.LayerToName(coll.gameObject.layer);
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

    public int GetDamage()
    {
        return enemy.GetDamage();
    }

    /// <summary>�G�̒e����</summary>
    private void GenBullet()
    {
        for (int i = 0; i < bullets; i++) Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    /// <summary>�j��</summary>
    private void Breaking()
    {
        // �T�E���h
        Sound.PlaySE("Explode");
        // ����
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
        // �I�u�W�F�N�g�j��
        Invoke("_Destroy", 0.2f);
    }

    private void SwitchTransform()
    {
        float switchMoveSpeedX = 4f;
        float switchMoveSpeedY = 4f;
        switch (transformPattern)
        {
            case 0:
                this.moveSpeedX = switchMoveSpeedX;
                this.moveSpeedY = -switchMoveSpeedY;
                transformPattern = 1;
                break;

            case 1:
                this.moveSpeedX = 0;
                this.moveSpeedY = switchMoveSpeedY;
                transformPattern = 2;
                break;

            case 2:
                this.moveSpeedX = -switchMoveSpeedX;
                this.moveSpeedY = -switchMoveSpeedY;
                transformPattern = 3;
                break;

            case 3:
                this.moveSpeedX = 0;
                this.moveSpeedY = switchMoveSpeedY;
                transformPattern = 0;
                break;

            default:
                transformPattern = 0;
                break;
        }
    }

    private void _Destroy()
    {
        Destroy(gameObject);
    }
}