using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private Transform lastplatform;

    private Vector3 PosStart;
    private Vector3 PosNew;

    private bool isStopped = false;
    void Start()
    {
        PosStart = lastplatform.position;
        StartCoroutine(SpawnPlatform());
    }

    IEnumerator SpawnPlatform()
    {
        while(!isStopped)
        {
            GeneratePlatform();
            Instantiate(Platform, PosNew, Quaternion.identity);
            PosStart = PosNew;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void GeneratePlatform()
    {
        PosNew = PosStart;
        int rand = Random.Range(0, 2);
        if (rand > 0)
            PosNew.x += 2f;
        else
            PosNew.z += 2f;
    }
}
