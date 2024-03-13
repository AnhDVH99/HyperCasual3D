using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public GameObject StartMenuPanel;
    public GameObject SuccessPanel; 

    // Singleton
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void StartButton()
    {
        StartMenuPanel.gameObject.SetActive(false);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = playerGO.GetComponent<PlayerController>();
        playerController.GameStarted();
    }

    public void NextButton()
    {
        SuccessPanel.gameObject.SetActive(false);
        LevelController.instance.NextLevel();
    }

    public void ShowSuccessMenu()
    {
        SuccessPanel.gameObject.SetActive(true);
    }
}
