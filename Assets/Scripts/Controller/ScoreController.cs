using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>�o������G�̐�</summary>
    [SerializeField]
    private int numEnemy;

    /// <summary>�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    public Text ScoreText;

    /// <summary>�|�����G�̐�</summary>
    public int[] numShootDown;

    /// <summary>�X�R�A</summary>
    public int Score;

    // Start is called before the first frame update
    private void Start()
    {
        ScoreText.text = Score.ToString();
        numShootDown = new int[numEnemy];

        for (var i = 0; i < numEnemy; i++)
        {
            numShootDown[i] = 0;
        }
    }

    public void AddScore(int pattern, int score)
    {
        numShootDown[pattern - 1]++;
        Score += score;
        ScoreText.text = Score.ToString();
    }
}