using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{

    public void UpdateHealth(int health)
    {
        Debug.Log("PlayerHealthView:" + health);
        GetComponent<RectTransform>().sizeDelta = new Vector2(health*2, GetComponent<RectTransform>().sizeDelta.y);
        //�c��HP��30�ȉ��̂Ƃ��ԐF�ɂ���
        if (health <= 30)
        {
            Sound.PlaySE("danger");
            GetComponent<Image>().color = new Color32(255, 0, 11, 255);
        }
        // ����ȏ�̂Ƃ��ΐF�ɂ���
        else
        {
            GetComponent<Image>().color = new Color32(11, 255, 0, 255);
        }
    }
}