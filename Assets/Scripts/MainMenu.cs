using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    bool done = false;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void Play()
    {
        if (!done)
        {
            StartCoroutine(StartPlaying());

        } 
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator StartPlaying()
    {
        done = true;
        Anim.SetTrigger("Play");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadSceneAsync("Level1");
    }
    
}
