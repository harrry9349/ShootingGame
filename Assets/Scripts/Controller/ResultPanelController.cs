using UnityEngine;
using UnityEngine.UI;

public class ResultPanelController : MonoBehaviour
{
    /// <summary>�X�R�A�Ăяo���p�X�N���v�^�u���I�u�W�F�N�g</summary>
    [SerializeField]
    public Score SAVE_SCORE;

    /// <summary>�X�R�A�\���e�L�X�g</summary>
    [SerializeField]
    public Text scoreText;

    /// <summary> �G�p�^�[�� </summary>
    [SerializeField]
    private int pattern;

    // Start is called before the first frame update
    private void Start()
    {
        ReadScore();
    }

    /// <summary>
    /// �X�R�A�Ăяo��
    /// </summary>

    private void ReadScore()
    {
        scoreText.text = SAVE_SCORE.numShootDown[pattern - 1].ToString();
    }

    /// <summary>
    /// ������
    /// </summary>
    private void OnDestroy()
    {
        SAVE_SCORE.numShootDown[pattern - 1] = 0;
    }
}