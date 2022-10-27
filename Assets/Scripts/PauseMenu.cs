using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_Pause, player;
    bool paused;

    void Start()
    {
        Resume();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !paused)
        {
            paused = !paused;
            Pause();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        m_Pause.SetActive(true); 
        player.GetComponent<PlayerMovement>().canMove = false;
    }

    public void Resume()
    {
        m_Pause.SetActive(false);    
        player.GetComponent<PlayerMovement>().canMove = true;
        paused = false;
    }
}
