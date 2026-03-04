using UnityEngine;

public class InfiniteRightLoop : MonoBehaviour
{
    public Transform left;
    public Transform middle;
    public Transform right;

    public float speed = 2f;

    private float width;
    private Transform[] pieces;

    void Start()
    {
        pieces = new Transform[] { left, middle, right };

        // Grab width from the renderer
        width = left.GetComponent<SpriteRenderer>().bounds.size.x;

        // Optional: Snap pieces into perfect position at start to avoid gaps
        // This assumes 'middle' is at 0,0. Adjust if your setup differs.
        left.localPosition = new Vector3(-width, 0, 0);
        middle.localPosition = new Vector3(0, 0, 0);
        right.localPosition = new Vector3(width, 0, 0);
    }

    void Update()
    {
        float move = speed * Time.deltaTime;

        foreach (Transform t in pieces)
        {
            // Move right
            t.position += Vector3.right * move;

            // Logic: If a piece moves past the 'right' boundary, 
            // shift it back to the far left of the sequence.
            if (t.localPosition.x >= width * 1.5f)
            {
                t.localPosition -= new Vector3(width * 3f, 0, 0);
            }
        }
    }
}