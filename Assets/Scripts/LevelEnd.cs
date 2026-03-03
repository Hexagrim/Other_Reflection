using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public Animator FadeAnim;
    public string NextLevel;
    public static bool whitePass, blackPass;
    public GameObject Particle,Particle1;
    static bool done = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Particle.SetActive(Collectables.canPass);
        Particle1.SetActive(Collectables.canPass);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Escape());   
        }
        if(!done && whitePass && blackPass)
        {
            done = true;
            StartCoroutine(EndLevel());
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LevelEnd") && Collectables.canPass && gameObject.CompareTag("PlayerWhite"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            whitePass = true;
        }
        if (other.gameObject.CompareTag("LevelEnd") && Collectables.canPass && gameObject.CompareTag("PlayerBlack"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            blackPass = true;
        }
    }

    IEnumerator EndLevel()
    {
        FadeAnim.SetTrigger("fadeOut");
        GetComponent<PlayerScriptWhite>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(NextLevel);
    }
    IEnumerator Escape()
    {
        FadeAnim.SetTrigger("fadeOut");
        GetComponent<PlayerScriptWhite>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
