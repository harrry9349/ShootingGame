using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>出現する敵の数</summary>
    [SerializeField]
    private int numEnemy;

    /// <summary>スコア表示テキスト</summary>
    [SerializeField]
    public Text ScoreText;

    /// <summary>倒した敵の数</summary>
    public int[] numShootDown;

    /// <summary>スコア</summary>
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