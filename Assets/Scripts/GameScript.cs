using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}