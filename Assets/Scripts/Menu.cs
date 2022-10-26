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
        m_mainMenu.SetActive(true);
        m_tutorialMenu.SetActive(false);
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
}