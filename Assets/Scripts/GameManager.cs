using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject PlatformSpawn;
    [HideInInspector]
    public bool isGameStarted = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameStart();
        }
    }
    public void GameStart()
    {
        isGameStarted = true;
        PlatformSpawn.SetActive(true);
    }

    public void GameOver()
    {
        isGameStarted = false;
        PlatformSpawn.SetActive(false);

        Invoke(nameof(ReloadLevel), 2f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
