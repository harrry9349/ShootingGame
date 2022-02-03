using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject ExplodePrefab;

    [SerializeField]
    public int remainsShot;

    [SerializeField]
    public Text BulletRemainsText;

    /// �ő�̗�
    [SerializeField]
    private int MAXhealth;

    [SerializeField]
    public Text MAXHealthText;

    /// �̗�
    [SerializeField]
    private int health;

    [SerializeField]
    public Text HealthText;

    ///  �X�s�[�h
    [SerializeField]
    private float speed;

    private int interval;

    // Start is called before the first frame update
    private void Start()
    {
        // �����l����ʂɔ��f����
        BulletRemainsText.text = remainsShot.ToString();
        MAXHealthText.text = MAXhealth.ToString();
        HealthText.text = health.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        // �ړ�
        if (Input.GetKey(KeyCode.W))
        {
            // ��
            if (transform.position.y < 400f) transform.Translate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // ��
            if (transform.position.x > -720f) transform.Translate(speed * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // ��
            if (transform.position.y > -400f) transform.Translate(0, speed * -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // �E
            if (transform.position.x < 720f) transform.Translate(speed, 0, 0);
        }

        // �U��
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetMouseButtonDown(0))
        {
            // �e���؂�ĂȂ���
            if (remainsShot > 0)
            {
                // �e����
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                Debug.Log(transform.position.x + "," + transform.position.y);

                // �e�̐������炷
                remainsShot--;
                Debug.Log(remainsShot);
                // ��ʂɔ��f
                BulletRemainsText.text = remainsShot.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
        string layername = LayerMask.LayerToName(coll.gameObject.layer);
        // �G�A�}�E�X�ōU������G
        if (layername == "Enemy" || layername == "FlickEnemy")
        {
            // �_���[�W
            int dmg = coll.gameObject.GetComponent<EnemyController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
            }
        }
        // �G�̒e
        else if (layername == "EnemyBullet")
        {
            // �_���[�W
            int dmg = coll.gameObject.GetComponent<EnemyBulletController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
            }
        }
        // �Ή�
        else if (layername == "Gmmick")
        {
            // �_���[�W
            int dmg = coll.gameObject.GetComponent<FrameController>().GetDamage();
            Damage(dmg);
            if (health <= 0)
            {
                Breaking();
            }
        }
        // �A�C�e��
        else if (layername == "Items")
        {
            // �e�̐����₷
            //int ammo = coll.gameObject.GetComponent<EnemyController>().GetAmmo();
            remainsShot += 5;
            // ��ʂɔ��f
            BulletRemainsText.text = remainsShot.ToString();
        }
    }

    private void Damage(int dmg)
    {
        // �_���[�W
        health = health - dmg;
        // �`��
        HealthText.text = health.ToString();
    }

    private void Breaking()
    {
        // HP�̒l��0�ɕ`��
        HealthText.text = "0";
        // �v���C���[�j��
        Destroy(gameObject);
        // ����
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
    }
}