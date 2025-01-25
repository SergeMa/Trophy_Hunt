using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPause : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true)
            {
                Resume();
            }
            if (IsPaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Destroy(PauseMenu);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsPaused = false;
    }
    public void Pause()
    {
        Instantiate(PauseMenu, new Vector3(0, 0, 0), Quaternion.identity);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
