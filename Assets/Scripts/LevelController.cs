using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    private int currentLevel;
    private int maxLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        maxLevel = 2;
        DontDestroyOnLoad(this.gameObject);
        GetLevel();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("keyLevel", 1);
        LoadLevel();
    }

    public void LoadLevel()
    {
        string strLevel = "LevelScene" + currentLevel;
        SceneManager.LoadScene(strLevel);
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("keyLevel", currentLevel);
        LoadLevel();
    }
}
