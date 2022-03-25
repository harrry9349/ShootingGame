using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>出現する敵の数</summary>
    [SerializeField]
    private int numEnemy;

    /// <summary>スコア表示テキスト</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary>倒した敵の数</summary>
    public int[] numShootDown;

    /// <summary>スコア</summary>
    public int totalScore;

    /// <summary>スコア保存用スクリプタブルオブジェクト</summary>
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
    /// スコア加算
    /// </summary>
    /// <param name="pattern">敵パターン</param>
    /// <param name="score">加算スコア</param>
    public void AddScore(int pattern, int score)
    {
        numShootDown[pattern - 1]++;
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    /// <summary>
    /// スコア保存
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