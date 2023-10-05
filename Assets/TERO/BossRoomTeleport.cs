using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class BossRoomTeleport : MonoBehaviour
{

    //public AudioClip  audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel(int levelNumber)
    {

        //fadeScreen.SetTrigger("ChangeLevel");
        StartCoroutine(NewLevel(levelNumber));
    }

    public IEnumerator NewLevel(int levelNumber)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelNumber);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Spartan_Final")
        {
            ChangeLevel(5);
        }
    }
}
