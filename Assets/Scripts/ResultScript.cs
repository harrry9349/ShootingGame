using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // ÉTÉEÉìÉhÇÃì«Ç›çûÇ›
        LoadSound();
        Sound.PlayBGM("result");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PushTitle()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }

    private void LoadSound()
    {
        Sound.LoadBGM("result", "utakatanoyume");
        Sound.LoadSE("Start", "StartGong");
    }
}