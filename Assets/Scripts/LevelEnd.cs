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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        whitePass = false;
        blackPass = false;
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


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LevelEnd") && Collectables.canPass && gameObject.CompareTag("PlayerWhite"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            if (blackPass)
            {
                StartCoroutine(EndLevel());
            }
            whitePass = true;
        }
        if (other.gameObject.CompareTag("LevelEnd") && Collectables.canPass && gameObject.CompareTag("PlayerBlack"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            if (whitePass)
            {
                StartCoroutine(EndLevel());
            }
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
