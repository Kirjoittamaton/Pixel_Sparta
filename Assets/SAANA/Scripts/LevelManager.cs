using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public PauseScript pause;
    public float transitionTime = 1f;
    public Animator fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
       // pause = GetComponent<PauseScript>();
       fadeScreen = GameObject.Find("FadeScreen").GetComponent<Animator>();
        print("löysin fadenäytön");
    }

    public void ChangeLevel(int levelNumber)
    {

        fadeScreen.SetTrigger("ChangeLevel");
        StartCoroutine(NewLevel(levelNumber));
    }

    public IEnumerator NewLevel(int levelNumber)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelNumber);
    }
}
