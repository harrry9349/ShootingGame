using UnityEngine;
using UnityEngine.UI;

public class TotalScorePanelController : MonoBehaviour
{
    /// <summary>スコア呼び出し用スクリプタブルオブジェクト</summary>
    [SerializeField]
    public Score SAVE_SCORE;

    /// <summary>スコア表示テキスト</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary>ハイスコア呼び出し用スクリプタブルオブジェクト</summary>
    [SerializeField]
    public HiScore HISCORE;

    /// <summary>新記録表示テキスト</summary>
    [SerializeField]
    public Text newrecordText;

    // Start is called before the first frame update
    private void Start()
    {
        // スコア読み込み
        ReadScore();
        // ハイスコア判定
        UpdateHighScoreIfHighest();
    }

    // Update is called once per frame
    private void ReadScore()
    {
        // スコア表示
        scoreText.text = SAVE_SCORE.totalScore.ToString();
    }

    public void UpdateHighScoreIfHighest()
    {
        // 新記録判定
        if (SAVE_SCORE.totalScore > HISCORE.CurrentHiScore)
        {
            // ハイスコア更新
            HISCORE.CurrentHiScore = SAVE_SCORE.totalScore;
            // 新記録表示
            newrecordText.text = "New Record!";
        }
    }

    private void OnDestroy()
    {
        // スコア表示初期化
        SAVE_SCORE.totalScore = 0;
        newrecordText.text = "";
    }
}