using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothValue;
    [SerializeField] private Color[] colors;
    private Vector3 distance;
    void Start()
    {
        distance = target.position - transform.position;
        StartCoroutine(ChangeColor());
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

    IEnumerator ChangeColor()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);
            Camera.main.backgroundColor = colors[Random.Range(0, colors.Length)];
        }
    }
}
