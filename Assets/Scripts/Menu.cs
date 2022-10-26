using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_tutorialMenu;

    private void Start()
    {
        Back();
    }

    public void ShowTutorial()
    {
        m_mainMenu.SetActive(false);
        m_tutorialMenu.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        m_mainMenu.SetActive(true);
        m_tutorialMenu.SetActive(false);
    }
}