using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletRemainsView : MonoBehaviour
{
    public void UpdateBulletRemains(int loadingAmmo)
    {
        if (loadingAmmo < 1000) GetComponent<Text>().text = loadingAmmo.ToString();
        else GetComponent<Text>().text = "Åá";
    }
}