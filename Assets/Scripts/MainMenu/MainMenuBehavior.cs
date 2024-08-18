using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructions;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowInstructions()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        instructions.SetActive(false);
    }
}
