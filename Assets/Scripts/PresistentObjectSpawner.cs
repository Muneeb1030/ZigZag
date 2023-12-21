using UnityEngine;

public class PresistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject presistentObjectPrefab;

    static bool hasSpawned = false;
    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPresistentObjects();

        hasSpawned = true;
    }

    private void SpawnPresistentObjects()
    {
        GameObject presistentObject = Instantiate(presistentObjectPrefab);
        DontDestroyOnLoad(presistentObject);
    }
}
