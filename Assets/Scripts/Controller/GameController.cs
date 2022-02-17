using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[���R���g���[���[�N���X
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>�G�P�v���n�u</summary>
    [SerializeField]
    public GameObject EnemyPrefab;

    /// <summary>�G�Q�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy2Prefab;

    /// <summary>�G�R�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy3Prefab;

    /// <summary>�G�S�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy4Prefab;

    /// <summary>�G�T�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy5Prefab;

    /// <summary>�G�U�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy6Prefab;

    /// <summary>�A�C�e���P�v���n�u</summary>
    [SerializeField]
    public GameObject Item1Prefab;

    /// <summary>�A�C�e���Q�v���n�u</summary>
    [SerializeField]
    public GameObject Item2Prefab;

    /// <summary>�M�~�b�N�v���n�u</summary>
    [SerializeField]
    public GameObject GimmickPrefab;

    /// <summary>
    /// �X�R�A
    /// </summary>
    [SerializeField]
    public int score;

    /// <summary>
    /// �X�R�A�\��
    /// </summary>
    [SerializeField]
    public Text ScoreText;

    /// <summary>
    /// �G�o���J�E���g
    /// </summary>
    private int enemy_cnt = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // �T�E���h
        LoadSound();
        Sound.PlayBGM("ingame");

        // �G���������̃��[�`���ݒ�
        InvokeRepeating("GenEnemy", 1, 1);

        // �X�R�A�\��
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // �G��������
    private void GenEnemy()
    {
        // 1�b��1�x�G�����������s��
        if (enemy_cnt % 5 == 0)
        {
            Instantiate(Item1Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 1)
        {
            Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 2)
        {
            Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 3)
        {
            Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 5 == 4)
        {
            Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 10 == 5)
        {
            Instantiate(GimmickPrefab, new Vector3(-700f + 1400 * Random.value, 400, 0), Quaternion.identity);
        }
        enemy_cnt++;
    }

    // �T�E���h���[�h
    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "Thunderbolt");     // �C���Q�[����ʂ̉��y
        Sound.LoadSE("pop", "Pop");                 // �A�C�e���擾
        Sound.LoadSE("damage", "damage");           // �_���[�W
        Sound.LoadSE("Explode", "Explode");         // ����
        Sound.LoadSE("shot", "Shot");               // �e�۔���
        Sound.LoadSE("unableshot", "UnableShot");   // ���˂ł��Ȃ�
        Sound.LoadSE("flickshot", "FlickShot");     // �}�E�X�e�۔���
    }

    // �X�R�A���Z
    public void AddScore(int addscore)
    {
        // �X�R�A���Z
        score += addscore;
        // �X�R�A�\���X�V
        ScoreText.text = score.ToString();
    }
}