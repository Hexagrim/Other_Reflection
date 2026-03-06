using Unity.VisualScripting;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;
    public AudioSource SFX;
    public AudioClip Die,LevelEnd,Collect,Jump;
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
    public  void PlaySFX(AudioClip clip)
    {
        SFX.pitch = Random.Range(0.95f, 1.05f);
        SFX.PlayOneShot(clip);
    }
}
