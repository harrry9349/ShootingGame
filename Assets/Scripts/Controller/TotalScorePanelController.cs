using UnityEngine;
using UnityEngine.UI;

public class TotalScorePanelController : MonoBehaviour
{
    /// <summary>�X�R�A�Ăяo���p�X�N���v�^�u���I�u�W�F�N�g</summary>
    [SerializeField]
    public Score SAVE_SCORE;

    /// <summary>�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary>�n�C�X�R�A�Ăяo���p�X�N���v�^�u���I�u�W�F�N�g</summary>
    [SerializeField]
    public HiScore HISCORE;

    /// <summary>�V�L�^�\���e�L�X�g</summary>
    [SerializeField]
    public Text newrecordText;

    // Start is called before the first frame update
    private void Start()
    {
        // �X�R�A�ǂݍ���
        ReadScore();
        // �n�C�X�R�A����
        UpdateHighScoreIfHighest();
    }

    // Update is called once per frame
    private void ReadScore()
    {
        // �X�R�A�\��
        scoreText.text = SAVE_SCORE.totalScore.ToString();
    }

    public void UpdateHighScoreIfHighest()
    {
        // �V�L�^����
        if (SAVE_SCORE.totalScore > HISCORE.CurrentHiScore)
        {
            // �n�C�X�R�A�X�V
            HISCORE.CurrentHiScore = SAVE_SCORE.totalScore;
            // �V�L�^�\��
            newrecordText.text = "New Record!";
        }
    }

    private void OnDestroy()
    {
        // �X�R�A�\��������
        SAVE_SCORE.totalScore = 0;
        newrecordText.text = "";
    }
}