using UnityEngine;

public class FlickShotController : MonoBehaviour
{
    private int count;

    [SerializeField]
    private float deleteTime;

    // Start is called before the first frame update
    private void Start()
    {
        count = 0;
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Destroy(coll.gameObject);
        //Destroy(gameObject);
    }
}