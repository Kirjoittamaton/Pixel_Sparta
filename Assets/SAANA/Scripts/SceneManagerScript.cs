using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManagerScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject InventoryMenu;

    public bool paused = false;

    public Animator UIAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Button to toggle pause booleon
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused == true)
            {
                paused = false;
            }

            else if (paused == false)
            {
                paused = true;
            }
        }

        // Pauses the game and opens the menu
        if (paused == true)
        {
            //pauseMenu.SetActive(true);
            Time.timeScale = 0f;

        }

        else if (paused == false)
        {
            //pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Openpause()
    {
        Time.timeScale = 1f;

    }
    /*
    public void Inventory()
    {
        InventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }

    public void Openwindow()
    {
        Time.timeScale = 0f;
        UIAnimator.SetTrigger("Open");
        InventoryMenu.SetActive(true);

    }

    public void Closewindow()
    {

        pauseMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        UIAnimator.SetTrigger("Close");
        Time.timeScale = 1f;
        paused = false;
    }
*/
}

