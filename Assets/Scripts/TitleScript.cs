using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        LoadSound();
        Sound.PlayBGM("title");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PushStart()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void LoadSound()
    {
        Sound.LoadBGM("title", "Introduction");
        Sound.LoadSE("Start", "StartGong");
    }
}