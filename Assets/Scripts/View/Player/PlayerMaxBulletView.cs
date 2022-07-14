using UnityEngine;
using UnityEngine.UI;

public class PlayerMaxBulletView : MonoBehaviour
{
    // Start is called before the first frame update
    public void UpdateCurrentBullet(int currentAmmo)
    {
        if (currentAmmo < 1000) GetComponent<Text>().text = currentAmmo.ToString();
        else GetComponent<Text>().text = "Åá";
    }
}