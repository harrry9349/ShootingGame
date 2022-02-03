using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject EnemyPrefab;

    [SerializeField]
    public GameObject Enemy2Prefab;

    [SerializeField]
    public GameObject Enemy3Prefab;

    [SerializeField]
    public GameObject Enemy4Prefab;

    [SerializeField]
    public GameObject Enemy5Prefab;

    [SerializeField]
    public GameObject Enemy6Prefab;

    [SerializeField]
    public GameObject Item1Prefab;

    [SerializeField]
    public GameObject Item2Prefab;

    [SerializeField]
    public GameObject GimmickPrefab;

    [SerializeField]
    public Text BulletRemainsText;

    [SerializeField]
    public GameObject FlickShottPrefab;

    [SerializeField]
    public int remainsFlickshot;

    [SerializeField]
    public int score;

    [SerializeField]
    public Text ScoreText;

    private int enemy_cnt = 0;

    // Start is called before the first frame update
    private void Start()
    {
        LoadSound();
        Sound.PlayBGM("ingame");
        InvokeRepeating("GenEnemy", 1, 1);
        BulletRemainsText.text = remainsFlickshot.ToString();
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log("左クリックを受け付けました");
            Debug.Log(objPos.x + "," + objPos.y);
            if (remainsFlickshot > 0)
            {
                Instantiate(FlickShottPrefab, objPos, Quaternion.identity);
                remainsFlickshot--;
                BulletRemainsText.text = remainsFlickshot.ToString();
            }
        }
        if (Input.GetMouseButtonDown(1)) Debug.Log("右クリックを受け付けました");
        if (Input.GetMouseButtonDown(2)) Debug.Log("中央クリックを受け付けました");
    }

    private void GenEnemy()
    {
        if (enemy_cnt % 4 == 0)
        {
            Instantiate(Item1Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 4 == 1)
        {
            Instantiate(Enemy2Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 4 == 2)
        {
            Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 4 == 3)
        {
            Instantiate(Enemy3Prefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
        }

        if (enemy_cnt % 10 == 5)
        {
            Instantiate(GimmickPrefab, new Vector3(-700f + 1400 * Random.value, 400, 0), Quaternion.identity);
        }
        enemy_cnt++;
    }

    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "Thunderbolt");
        //Sound.LoadSE("Start", "StartGong");
    }

    public void AddScore(int addscore)
    {
        score += addscore;
        ScoreText.text = score.ToString();
    }
}