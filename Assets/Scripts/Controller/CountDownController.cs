using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    /// <summary>
    /// �X�R�A�\��
    /// </summary>
    [SerializeField]
    public Text CountText;

    /// <summary>
    /// �J�E���g
    /// </summary>
    [SerializeField]
    private int count;

    // Start is called before the first frame update
    private void Start()
    {
        // 1�b�u���ɃJ�E���g
        InvokeRepeating("CountDown", 1, 1);
        // �J�E���g�\��
        CountText.text = count.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void CountDown()
    {
        count--;
        if (count == 0)
        {
            //�J�E���g�j��
            Destroy(CountText);
            Destroy(gameObject);
        }
        // �J�E���g�\��
        CountText.text = count.ToString();
    }
}