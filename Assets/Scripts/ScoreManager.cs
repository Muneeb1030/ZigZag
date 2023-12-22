using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private Label scoreText;
    private Label HighScore;
    private VisualElement Tap;
    private VisualElement MenuScreen;
    private VisualElement root;

    private float levelScore = 0;
    private int _iscoreMultiplier = 3;
    private float levelTimeEnd = 0;


    private AudioManager _audioManager;

    public float LevelScore
    {
        get => levelScore;
    }
    public float LevelTimeEnd
    {
        get => levelTimeEnd;
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        scoreText = root.Q<Label>("GameScore");
        HighScore = root.Q<Label>("HighScore");
        Tap = root.Q<VisualElement>("Tap");
        MenuScreen = root.Q<VisualElement>("MenuScreen");

        MenuScreen.style.display = DisplayStyle.Flex;
        scoreText.style.display = DisplayStyle.None;
        scoreText.text = "0";
        HighScore.text = $"High Score: {Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore", 0))}";
        StartCoroutine(Transition());
        
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(0.1f);
        Tap.ToggleInClassList("Game-tapLabel-Transition--end");
        Tap.RegisterCallback<TransitionEndEvent>((evt) =>
        {
            Tap.ToggleInClassList("Game-tapLabel-Transition--end");
        });
    }

    private void Update()
    {
        if(_audioManager == null)
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }
        if(GameManager.instance.isGameStarted)
        {
            scoreText.style.display = DisplayStyle.Flex;
            MenuScreen.style.display = DisplayStyle.None;
            levelScore += _iscoreMultiplier * Time.deltaTime;
            scoreText.text = $"{Mathf.FloorToInt(levelScore)}";
            UpdateHighScore();
        }
    }

    public void AddScore(int value)
    {
        _audioManager.PlayNotify();
        levelScore += value;
    }

    public void SubtractScore(int value)
    {
        _audioManager.PlayNotify();
        levelScore -= value;
        if (levelScore < 0)
        {
            levelScore = 0;
        }
    }
    private void UpdateHighScore()
    {
        if (levelScore > PlayerPrefs.GetFloat("HighScore",0))
        {
            PlayerPrefs.SetFloat("HighScore", levelScore);
        }

    }
}
