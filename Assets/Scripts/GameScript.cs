using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    /// <summary>スコアコントローラー</summary>
    public GameObject scoreObject;

    public void Start()
    {
        scoreObject = GameObject.Find("ScoreController");
    }

    public void GameOver()
    {
        // 2秒後に画面遷移処理
        Invoke("_GameOver", 2f);

    }

    private void _GameOver()
    {
        // スコアの一時保存
        scoreObject.GetComponent<ScoreController>().SaveScore();
        // リザルト画面へ遷移
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}