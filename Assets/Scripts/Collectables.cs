using UnityEngine;

public class Collectables : MonoBehaviour
{
    public static float numOfCollectables;
    public static bool canPass;
    private static float collected;
    public GameObject Particle;


    void Start()
    {
        numOfCollectables = GameObject.FindGameObjectsWithTag("collectable").Length;
        collected = 0f;
        canPass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == numOfCollectables)
        {
            canPass = true;
        }
        else
        {
            canPass = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectable") && other != null)
        {
            collected++;
            FindFirstObjectByType<Music>().PlaySFX(FindFirstObjectByType<Music>().Collect);
            Instantiate(Particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
    }
}
