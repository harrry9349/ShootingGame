using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    /// <summary>ハイスコア表示オブジェクト</summary>
    private TitleHiscoreController HiscoreText;

    // Start is called before the first frame update
    private void Start()
    {
        // サウンドの読み込み
        LoadSound();
        Sound.PlayBGM("title");
    }

    public void PushStart()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void PushHowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene", LoadSceneMode.Single);
    }

    public void PushQuit()
    {
        UnityEngine.Application.Quit();
    }

    public void PushReset()
    {
        // ハイスコアリセット
        HiscoreText = GameObject.Find("HIScoreValueText").GetComponent<TitleHiscoreController>();
        HiscoreText.ResetScore();
    }

    private void LoadSound()
    {
        Sound.LoadBGM("title", "Introduction");
    }
}