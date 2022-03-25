using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>�o������G�̐�</summary>
    [SerializeField]
    private int numEnemy;

    /// <summary>�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary>�|�����G�̐�</summary>
    public int[] numShootDown;

    /// <summary>�X�R�A</summary>
    public int totalScore;

    /// <summary>�X�R�A�ۑ��p�X�N���v�^�u���I�u�W�F�N�g</summary>
    public Score SAVE_SCORE;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = totalScore.ToString();
        numShootDown = new int[numEnemy];

        for (var i = 0; i < numEnemy; i++)
        {
            numShootDown[i] = 0;
        }
    }

    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="pattern">�G�p�^�[��</param>
    /// <param name="score">���Z�X�R�A</param>
    public void AddScore(int pattern, int score)
    {
        numShootDown[pattern - 1]++;
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    /// <summary>
    /// �X�R�A�ۑ�
    /// </summary>
    public void SaveScore()
    {
        SAVE_SCORE.numShootDown = new int[numEnemy];
        for (int i = 0; i < numEnemy; i++)
        {
            SAVE_SCORE.numShootDown[i] = numShootDown[i];
        }
        SAVE_SCORE.totalScore = totalScore;
    }
}