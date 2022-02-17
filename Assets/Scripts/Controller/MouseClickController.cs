using UnityEngine;
using UnityEngine.UI;

public class MouseClickController : MonoBehaviour
{
    /// <summary>弾丸残り表示</summary>
    [SerializeField]
    public Text BulletRemainsText;

    /// <summary>
    /// フリックショット用弾丸プレハブ
    /// </summary>
    [SerializeField]
    public GameObject FlickShotPrefab;

    /// <summary>
    /// フリックショット用弾丸残り表示
    /// </summary>
    [SerializeField]
    public int remainsFlickshot;

    // Start is called before the first frame update
    private void Start()
    {
        // フリックショット用弾丸の残り数表示
        BulletRemainsText.text = remainsFlickshot.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (remainsFlickshot > 0)
            {
                // サウンド
                Sound.PlaySE("Explode");
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

                Debug.Log("左クリックを受け付けました");
                Debug.Log(objPos.x + "," + objPos.y);
                Instantiate(FlickShotPrefab, objPos, Quaternion.identity);

                // フリックショット用弾丸の残り数更新
                remainsFlickshot--;
                BulletRemainsText.text = remainsFlickshot.ToString();
            }
            else
            {
                // サウンドのみ再生
                Sound.PlaySE("unableshot");
            }
        }
        if (Input.GetMouseButtonDown(1)) Debug.Log("右クリックを受け付けました");
        if (Input.GetMouseButtonDown(2)) Debug.Log("中央クリックを受け付けました");
    }

    public void AddAmmo(int ammo)
    {
        // フリックショット用弾丸の残り数更新
        remainsFlickshot += ammo;
        BulletRemainsText.text = remainsFlickshot.ToString();
    }
}