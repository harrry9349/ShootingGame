using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject FlickShottPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GenEnemy", 1, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log("左クリックを受け付けました");
            Debug.Log(objPos.x + "," + objPos.y);
            Instantiate(FlickShottPrefab, objPos, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1)) Debug.Log("右クリックを受け付けました");
        if (Input.GetMouseButtonDown(2)) Debug.Log("中央クリックを受け付けました");
    }

    private void GenEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(750f, -400f + 800 * Random.value, 0), Quaternion.identity);
    }
}