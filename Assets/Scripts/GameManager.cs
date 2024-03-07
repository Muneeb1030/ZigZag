using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    VisualElement veroot;
    VisualElement pnlMain;
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
    private void OnEnable()
    {
        veroot = GetComponent<UIDocument>().rootVisualElement;
        pnlMain = veroot.Q<VisualElement>("Main");
        pnlMain.RegisterCallback<ClickEvent>(evt =>
        {
            isGameStarted = true;
        });
    }

    void Update()
    {
        if(isGameStarted)
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
