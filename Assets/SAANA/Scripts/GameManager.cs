using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public AudioSource soundPlayer; //button sound effect
    public AudioSource titleMusic; // menu music
    public Animator fadeScreen;

    public AudioMixer mainMixer; //This is for Options menu's volume settings

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Loadlevel(int levelToLoad)
    {
        fadeScreen.SetTrigger("ChangeLevel");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelToLoad);

    }

    public void playThisSoundEffect()
    {
        soundPlayer.Play();

    }

    public void StartGame()
    {
        StartCoroutine(Loadlevel(1));
        titleMusic.Stop();
    }

    public void Quit()
    {
        StartCoroutine(Loadlevel(0));
    }

    public void retry()
    {
        StartCoroutine(Loadlevel(4));
    }

    //These are for Options menu

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);

    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        print("Kokonäyttö käytössä");

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Mute()
    {
        
    }

    //Options menu assets end here :) 
}
