using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    /// <summary>�n�C�X�R�A�\���I�u�W�F�N�g</summary>
    private TitleHiscoreController HiscoreText;

    // Start is called before the first frame update
    private void Start()
    {
        // �T�E���h�̓ǂݍ���
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
        // �n�C�X�R�A���Z�b�g
        HiscoreText = GameObject.Find("HIScoreValueText").GetComponent<TitleHiscoreController>();
        HiscoreText.ResetScore();
    }

    private void LoadSound()
    {
        Sound.LoadBGM("title", "Introduction");
    }
}