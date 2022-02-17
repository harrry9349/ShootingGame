using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PushBack()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}