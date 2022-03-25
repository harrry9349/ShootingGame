using UnityEngine;
using UnityEngine.UI;

public class TitleHiscoreController : MonoBehaviour
{
    /// <summary>�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    private HiScore HISCORE;

    /// <summary>�n�C�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    public Text HiscoreText;

    // Start is called before the first frame update
    private void Start()
    {
        HiscoreText.text = HISCORE.CurrentHiScore.ToString();
    }

    public void ResetScore()
    {
        HISCORE.CurrentHiScore = 0;
        HiscoreText.text = HISCORE.CurrentHiScore.ToString();
    }
}