using UnityEngine;

public class FlickShotController : MonoBehaviour
{
    [SerializeField]
    private float deleteTime;

    // Start is called before the first frame update
    private void Start()
    {
        // deleteTime�b��ɔj��\��
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
    }
}