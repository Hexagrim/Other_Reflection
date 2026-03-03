using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float numOfCollectables;
    public bool canPass;
    private float collected;
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
            Instantiate(Particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
    }
}
