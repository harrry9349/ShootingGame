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

    /// <summary>�G�V�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy7Prefab;

    /// <summary>�G�W�v���n�u</summary>
    [SerializeField]
    public GameObject Enemy8Prefab;

    /// <summary>�A�C�e���P�v���n�u</summary>
    [SerializeField]
    public GameObject Item1Prefab;

    /// <summary>�A�C�e���Q�v���n�u</summary>
    [SerializeField]
    public GameObject Item2Prefab;

    /// <summary>�A�C�e���R�v���n�u</summary>
    [SerializeField]
    public GameObject Item3Prefab;

    /// <summary>�M�~�b�N�v���n�u</summary>
    [SerializeField]
    public GameObject GimmickPrefab;

    /// <summary>���e�v���n�u</summary>
    [SerializeField]
    public GameObject BombPrefab;

    /// <summary>�{�X�v���n�u</summary>
    [SerializeField]
    public GameObject BossPrefab;

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
        InvokeRepeating("GenEnemySet", 3, 1);

        // �X�R�A�\��
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // �G��������
    private void GenEnemySet()
    {
        // 1�b��1�x�G�����������s��

        // �{�X
        GenBoss();

        //�@�A�C�e��
        GenItem();

        //�@�ʏ�G(0�b�`)
        GenEnemy();

        //�@�ǉ��ʏ�G(90�b�`)
        if (enemy_cnt > 90) GenAdditionalEnemy();

        //�@�����G(150�b�`)
        if (enemy_cnt > 150) GenPowerEnemy();

        //�@�Ή�
        GenGimmick();

        enemy_cnt++;
    }

    private void GenEnemy()
    {
        switch (enemy_cnt % 8)
        {
            case 0:
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 1:
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 2:
                break;

            case 3:
                if (enemy_cnt > 8) Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                else { Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 4:
                if (enemy_cnt > 8) Instantiate(Enemy4Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                else { Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 5:
                break;

            case 6:
                if (enemy_cnt > 16) Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                else { Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            case 7:
                if (enemy_cnt > 16) Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                else { Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity); }
                break;

            default:
                break;
        }
    }

    private void GenAdditionalEnemy()
    {
        switch (enemy_cnt % 10)
        {
            case 0:
                Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 1:
                Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 2:
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 3:
                Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 4:
                Instantiate(Enemy4Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 5:
                break;

            case 6:
                Instantiate(Enemy7Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            case 7:
                Instantiate(Enemy5Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                break;

            case 8:
                break;

            case 9:
                Instantiate(Enemy6Prefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
                Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
                break;

            default:
                break;
        }
    }

    private void GenPowerEnemy()
    {
        // 3�b�u���ɋ����G�����݂ɏo��������
        if (enemy_cnt % 6 == 0)
        {
            Instantiate(Enemy7Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 6 == 3)
        {
            Instantiate(Enemy8Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
        }
    }

    private void GenBoss()
    {
        // 60�b�A180�b�A300�b�Ƀ{�X���o��������
        int[] gen = { 60, 180, 300 };
        foreach (int cnt in gen)
            if (enemy_cnt == cnt)
            {
                Instantiate(BossPrefab, new Vector3(600f, 400f, 0), Quaternion.identity);
            }
    }

    private void GenItem()
    {
        // �J�n3�b�ォ��6�b�����Ƀv���C���[�p�e�ۂ��o��������
        if (enemy_cnt % 6 == 3) Instantiate(Item1Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);

        // �J�n8�b�ォ��12�b�����Ƀ}�E�X�p�e�ۂ��o��������
        if (enemy_cnt % 12 == 8) Instantiate(Item2Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);

        // �J�n10�b�ォ��15�b�����ɉ񕜂��o��������
        if (enemy_cnt % 15 == 10) Instantiate(Item3Prefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
    }

    private void GenGimmick()
    {
        // �J�n5�b�ォ��15�b�����ɉΉ������e�̂ǂ��炩���o��������
        if (enemy_cnt % 15 == 5)
        {
            float rand = Random.value;
            if (rand > 0.5f)
            {
                Instantiate(GimmickPrefab, new Vector3(-700f + 1400f * Random.value, 400f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(BombPrefab, new Vector3(750f, -400f + 800f * Random.value, 0), Quaternion.identity);
            }
        }
    }

    // �T�E���h���[�h
    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "Thunderbolt");     // �C���Q�[����ʂ̉��y
        Sound.LoadSE("pop", "Pop");                 // �A�C�e���擾
        Sound.LoadSE("heal", "heal");               // ��
        Sound.LoadSE("damage", "damage");           // �_���[�W
        Sound.LoadSE("Explode", "Explode");         // ����
        Sound.LoadSE("shot", "Shot");               // �e�۔���
        Sound.LoadSE("unableshot", "UnableShot");   // ���˂ł��Ȃ�
        Sound.LoadSE("flickshot", "FlickShot");     // �}�E�X�e�۔���
    }
}