using UnityEngine;

public class ExplodeController : MonoBehaviour
{
    [SerializeField]
    private float deleteTime;

    // Start is called before the first frame update
    private void Start()
    {
        // deleteTime•bŒã‚É”j‰ó—\–ñ
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}