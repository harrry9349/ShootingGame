using UnityEngine;
using UnityEngine.UI;

public class ResultPanelController : MonoBehaviour
{
    /// <summary>スコア呼び出し用スクリプタブルオブジェクト</summary>
    [SerializeField]
    public Score SAVE_SCORE;

    /// <summary>スコア表示テキスト</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary> 敵パターン </summary>
    [SerializeField]
    private int pattern;

    // Start is called before the first frame update
    private void Start()
    {
        ReadScore();
    }

    /// <summary>
    /// スコア呼び出し
    /// </summary>

    private void ReadScore()
    {
        scoreText.text = SAVE_SCORE.numShootDown[pattern - 1].ToString();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void OnDestroy()
    {
        SAVE_SCORE.numShootDown[pattern - 1] = 0;
    }
}