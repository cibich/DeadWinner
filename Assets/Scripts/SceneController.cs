using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int _nextScene;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();

        if (Input.GetKeyDown(KeyCode.Q))
            LoadStartMenu();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelTransition()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLvlMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLvlOne()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLvlTwo()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLvlThree()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLvlFour()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLvlFive()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLvlSix()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLvlSeven()
    {
        SceneManager.LoadScene(8);
    }
}
