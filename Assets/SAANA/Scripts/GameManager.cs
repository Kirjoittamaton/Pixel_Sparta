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

    public GameObject OptionsPanel;

    public static bool mute = false;

    public GameObject muteText;

    // Start is called before the first frame update
    void Start()
    {
        titleMusic.volume = 0.5f;
        OptionsPanel = GameObject.Find("Optionspanel");
        muteText = GameObject.Find("MuteText");
        OptionsPanel.SetActive(false);
        DontDestroyOnLoad(gameObject);
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
        titleMusic.volume = volume * 0.02f;
        //mainMixer.SetFloat("volume", volume);
        print("volumen säätö");

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
      
        mute = !mute;
        print("bool");

        if (mute)
        {
            muteText.GetComponent<TextMeshProUGUI>().text = "Mute On";
            titleMusic.volume = 0f;
        }
       
        else if(!mute)
        {
            muteText.GetComponent<TextMeshProUGUI>().text = "Mute Off";
            titleMusic.volume = 0.5f;
        }
    }

    //Options menu assets end here :) 
}
