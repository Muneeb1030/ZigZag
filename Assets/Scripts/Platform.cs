using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _diamond;

    private void Start()
    {
        //making the spawing of diamonds random and not every time
        if(Random.Range(0, 10) < 1)
        {
            //spawning the diamond
            //arguments: what to spawn, where to spawn, rotation, parent
            Instantiate(_diamond, transform.position + Vector3.up, _diamond.transform.rotation, transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke(nameof(Fall), 0.2f);
        }
    }
    private void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 0.5f);
    }


}
