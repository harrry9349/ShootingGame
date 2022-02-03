using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float deleteTime;

    [SerializeField]
    private float speed;

    public GameObject ExplodePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Destroy(coll.gameObject);
        //Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}