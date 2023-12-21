using UnityEngine;

public class Platform : MonoBehaviour
{
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
