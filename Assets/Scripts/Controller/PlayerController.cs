using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�e�ۃv���n�u
    /// </summary>
    [SerializeField]
    public GameObject BulletPrefab;

    /// <summary>
    /// �����v���n�u
    /// </summary>
    [SerializeField]
    public GameObject ExplodePrefab;

    /// <summary>
    /// �c��e��
    /// </summary>
    [SerializeField]
    public int remainsShot;

    /// <summary>
    /// �c��e���\��
    /// </summary>
    [SerializeField]
    public Text BulletRemainsText;

    /// <summary>
    /// �ő�HP
    /// </summary>
    [SerializeField]
    private int MAXhealth;

    /// <summary>
    /// ����HP
    /// </summary>
    [SerializeField]
    private int health;

    /// <summary>
    /// ����HP�}
    /// </summary>
    [SerializeField]
    public GameObject HealthImage;

    ///  �X�s�[�h
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        // �����l����ʂɔ��f����
        BulletRemainsText.text = remainsShot.ToString();
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
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetKeyDown(KeyCode.E))
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
                // �T�E���h
                Sound.PlaySE("shot");
            }
            else
            {
                // �T�E���h�̂ݍĐ�
                Sound.PlaySE("unableshot");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // �ڐG�����I�u�W�F�N�g�̃��C���[���ǂݍ���
        string layername = LayerMask.LayerToName(coll.gameObject.layer);
        // �G�A�}�E�X�ōU������G�A �G�̒e�A�Ή�
        if (layername == "Enemy" || layername == "FlickEnemy" || layername == "EnemyBullet" || layername == "Gimmick")
        {
            // �C���^�t�F�[�X����ǂ̃I�u�W�F�N�g�ɐڐG���������肷��
            int dmg = coll.gameObject.GetComponent<IDamage>().GetDamage();
            // �_���[�W
            Damage(dmg);
            // �T�E���h
            Sound.PlaySE("damage");
            if (health <= 0)
            {
                // HP��0�ɂȂ�����j��
                Breaking();
                // �Q�[���I�[�o�[����
                GameOver();
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
            // �T�E���h
            Sound.PlaySE("pop");
        }
    }

    private void Damage(int dmg)
    {
        // �_���[�W
        health = health - dmg;
        // HP�\���X�V
        HealthImage.GetComponent<RectTransform>().sizeDelta = new Vector2((HealthImage.GetComponent<RectTransform>().sizeDelta.x - dmg), HealthImage.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void Breaking()
    {
        // �T�E���h
        Sound.PlaySE("Explode");
        // �v���C���[�j��
        Destroy(gameObject);
        // ����
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}