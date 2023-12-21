using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothValue;
    private Vector3 distance;
    void Start()
    {
        distance = target.position - transform.position;
    }

    void Update()
    {
        if(target.position.y >= 0)
            Follow();
    }

    private void Follow()
    {
        Vector3 positionCurrent = transform.position;
        Vector3 positionFinal = target.position - distance;

        transform.position = Vector3.Lerp(positionCurrent, positionFinal, smoothValue * Time.deltaTime);
    }
}
