using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>
    /// มิ
    /// </summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>
    /// ฺฎฌx
    /// </summary>
    [SerializeField]
    private float speed;

    public GameObject ExplodePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        // deleteTimebใษj๓\๑
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        // ฺฎ
        transform.Translate(speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // j๓
        Destroy(gameObject);
    }
}