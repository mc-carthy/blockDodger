using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private float moveSpeed = 25f;
    private float screenWidth = 5f;
    private float h;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.isKinematic = true;
    }

    private void Update ()
    {
        h = Input.GetAxis ("Horizontal");
    }

	private void FixedUpdate ()
    {
        Vector2 newPosition = rb.position + new Vector2 (h, 0) * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp (newPosition.x, -screenWidth, screenWidth);

        rb.MovePosition (newPosition);
    }

}
