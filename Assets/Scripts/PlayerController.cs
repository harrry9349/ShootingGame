using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;

    private int interval;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 1f, 0);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-1f, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, -1f, 0);
        if (Input.GetKey(KeyCode.D)) transform.Translate(1f, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Debug.Log(transform.position.x + "," + transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        string layername = LayerMask.LayerToName(coll.gameObject.layer);
        if (layername == "Enemy")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}