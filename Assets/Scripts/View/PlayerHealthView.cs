using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{

    public void UpdateHealth(int health)
    {
        Debug.Log("PlayerHealthView:" + health);
        GetComponent<RectTransform>().sizeDelta = new Vector2(health*2, GetComponent<RectTransform>().sizeDelta.y);
        //c‚èHP‚ª30ˆÈ‰º‚Ì‚Æ‚«ÔF‚É‚·‚é
        if (health <= 30)
        {
            Sound.PlaySE("danger");
            GetComponent<Image>().color = new Color32(255, 0, 11, 255);
        }
        // ‚»‚êˆÈã‚Ì‚Æ‚«—ÎF‚É‚·‚é
        else
        {
            GetComponent<Image>().color = new Color32(11, 255, 0, 255);
        }
    }
}