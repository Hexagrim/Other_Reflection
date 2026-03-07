using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindAnyObjectByType<Music>().PlaySFX(FindFirstObjectByType<Music>().Rickroll);
    }

    // Update is called once per frame
    void Update()
    {
        //yes this like the most uselsss code but ig its usper duperrr useful and o better get 10x mltiplier for this shit BRUH milkiway is so poggs
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
