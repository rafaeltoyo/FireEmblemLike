using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        ON_MENU,
        PLAYING,
        PAUSED
    }

    private GameStates status;

    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Start"))
        {
            Debug.Log("Loading game configuration ...");
            this.status = GameStates.ON_MENU;

            SceneManager.LoadScene("Menu");
        }
    }

    void Update()
    {
        
    }

    public void GamePause()
    {
        // TODO: Pause and show pause UI
        if (this.status == GameStates.PLAYING)
        {
            this.status = GameStates.PAUSED;
        }
    }

    public void GameResume()
    {
        // TODO: Resume and close pause UI
        if (this.status == GameStates.PAUSED)
        {
            this.status = GameStates.PLAYING;
        }
    }
}
