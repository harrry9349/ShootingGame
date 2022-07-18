using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�e�ۃv���n�u
    /// </summary>
    [SerializeField]
    public GameObject BulletPrefab;

    /// <summary>
    /// �}�E�X�e�ۃR���g���[���[
    /// </summary>
    public MouseClickController mouseClickController;

    /// <summary>
    /// �Q�[���V�[���}�l�[�W���[
    /// </summary>
    public GameScript GameManager;

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

    /// <summary>
    ///  �X�s�[�h
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// �����A�j���[�V����
    /// </summary>
    private Animator animator;

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
        if (Input.GetMouseButtonDown(0))
        {
            // �e���؂�ĂȂ���
            if (remainsShot > 0)
            {
                // �e����
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);

                // �e�̐������炷
                remainsShot--;
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
                //���y��~
                Sound.StopBGM();
                // �I�u�W�F�N�g�j��
                Invoke("_Destroy", 0.2f);
            }
        }

        // �A�C�e��
        else if (layername == "Items")
        {
            // �A�C�e���p�^�[���ǂݍ���
            int pattern = coll.gameObject.GetComponent<ItemController>().GetItemPattern();

            // �v���C���[�e
            if (pattern == 0)
            {
                // �e�̐����₷
                remainsShot += 15;
                // ��ʂɔ��f
                BulletRemainsText.text = remainsShot.ToString();
                // �T�E���h
                Sound.PlaySE("pop");
            }
            else if (pattern == 1)
            {
                // �e�̐����₷
                mouseClickController.AddAmmo(15);
                // �T�E���h
                Sound.PlaySE("pop");
            }
            // �V�[���h�i�񕜁j
            else if (pattern == 2)
            {
                // ��
                Heal(30);
                // �T�E���h
                Sound.PlaySE("heal");
            }
        }
    }

    public void Damage(int dmg)
    {
        // �_���[�W
        health = health - dmg;
        // HP�\���X�V
        ReloadHealthImage(health);
    }

    private void Heal(int healing)
    {
        // ��
        health += healing;
        if (health > 100) health = 100;
        // HP�\���X�V
        ReloadHealthImage(health);
    }

    // HP�\���X�V
    private void ReloadHealthImage(int health)
    {
        HealthImage.GetComponent<RectTransform>().sizeDelta = new Vector2(health, HealthImage.GetComponent<RectTransform>().sizeDelta.y);

        //�c��HP��30�ȉ��̂Ƃ��ԐF�ɂ���
        if (health <= 30)
        {
            HealthImage.GetComponent<Image>().color = new Color32(255, 0, 11, 255);
        }
        // ����ȏ�̂Ƃ��ΐF�ɂ���
        else
        {
            HealthImage.GetComponent<Image>().color = new Color32(11, 255, 0, 255);
        }
    }

    // ����
    private void Breaking()
    {
        // �T�E���h
        Sound.PlaySE("Explode");

        // ����
        this.animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
    }

    private void _Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // �Q�[���I�[�o�[�Ăяo��
        GameManager.GameOver();
    }
}