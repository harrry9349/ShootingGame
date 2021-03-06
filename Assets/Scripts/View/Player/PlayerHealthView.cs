using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{

    public void UpdateHealth(int health)
    {
        Debug.Log("PlayerHealthView:" + health);
        GetComponent<RectTransform>().sizeDelta = new Vector2(health*2, GetComponent<RectTransform>().sizeDelta.y);
        //残りHPが30以下のとき赤色にする
        if (health <= 30)
        {
            Sound.PlaySE("danger");
            GetComponent<Image>().color = new Color32(255, 0, 11, 255);
        }
        // それ以上のとき緑色にする
        else
        {
            GetComponent<Image>().color = new Color32(11, 255, 0, 255);
        }
    }
}