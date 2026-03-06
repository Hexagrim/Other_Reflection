using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music instance;
    public AudioSource SFX;
    float vol;
    public AudioClip Die,LevelEnd,Collect,Jump,Rickroll;
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        vol = GetComponent<AudioSource>().volume;

    }
    public  void PlaySFX(AudioClip clip)
    {
        SFX.pitch = Random.Range(0.95f, 1.05f);
        SFX.PlayOneShot(clip);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "End")
        {
            GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            GetComponent<AudioSource>().volume = vol;
        }
    }
}
