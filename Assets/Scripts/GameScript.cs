using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    /// <summary>�X�R�A�R���g���[���[</summary>
    public GameObject scoreObject;

    public void Start()
    {
        scoreObject = GameObject.Find("ScoreController");
    }

    public void GameOver()
    {
        // 2�b��ɉ�ʑJ�ڏ���
        Invoke("_GameOver", 2f);

    }

    private void _GameOver()
    {
        // �X�R�A�̈ꎞ�ۑ�
        scoreObject.GetComponent<ScoreController>().SaveScore();
        // ���U���g��ʂ֑J��
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}