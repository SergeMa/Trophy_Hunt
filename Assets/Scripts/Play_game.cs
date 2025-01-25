using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_game : MonoBehaviour
{
    public Animator ForArenaRewards;

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
            Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene(1);
    }
    public void Return()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PlayArena()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayStory()
    {
        SceneManager.LoadScene(5);
    }
    public void Settings()
    {
        SceneManager.LoadScene(4);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ArenaRewardsOpen()
    {
        ForArenaRewards.SetBool("IsOpen", true);
    }

    public void ArenaRewardsClose()
    {
        ForArenaRewards.SetBool("IsOpen", false);
    }
    public void goToLevel2 ()
    {
        SceneManager.LoadScene(6);
    }

    public void goToLevel3()
    {
        SceneManager.LoadScene(7);
    }

    public void goToLevel4()
    {
        SceneManager.LoadScene(8);
    }

    public void goToLevel5()
    {
        SceneManager.LoadScene(9);
    }
}
