using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        Restart();
    }

    public void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
