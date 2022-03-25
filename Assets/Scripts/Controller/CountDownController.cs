using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    /// <summary>
    /// スコア表示
    /// </summary>
    [SerializeField]
    public Text CountText;

    /// <summary>
    /// カウント
    /// </summary>
    [SerializeField]
    private int count;

    // Start is called before the first frame update
    private void Start()
    {
        // 1秒置きにカウント
        InvokeRepeating("CountDown", 1, 1);
        // カウント表示
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
            //カウント破壊
            Destroy(CountText);
            Destroy(gameObject);
        }
        // カウント表示
        CountText.text = count.ToString();
    }
}