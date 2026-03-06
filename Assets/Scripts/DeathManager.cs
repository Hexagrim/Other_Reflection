using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public Animator FadeAnim;
    public GameObject Particle,Particle1;
    public float transitionTime = 0.8f;
    static bool died;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(StartScene());
        died = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Kill()
    {
        StartCoroutine(StartKilling());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !died)
        {
            Kill();
        }
    }
    IEnumerator StartKilling()
    {
        died = true;
        FindFirstObjectByType<Music>().PlaySFX(FindFirstObjectByType<Music>().Die);
        FadeAnim.SetTrigger("fadeOut");
        if (gameObject.CompareTag("PlayerBlack") )Instantiate(Particle, transform.position, Quaternion.identity);
        else Instantiate(Particle1, transform.position, Quaternion.identity);
        
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject.FindWithTag("PlayerBlack").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindWithTag("PlayerWhite").GetComponent<SpriteRenderer>().enabled = false;
        
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    IEnumerator StartScene()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 1f;
    }
}
