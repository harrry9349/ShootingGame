using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletRemainsView : MonoBehaviour
{
    public void UpdateBulletRemains(int loadingAmmo)
    {
        GetComponent<Text>().text = loadingAmmo.ToString();
    }
}