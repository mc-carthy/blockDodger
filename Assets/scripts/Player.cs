using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private float moveSpeed = 25f;
    private float screenWidth = 5f;
    private float h;
    private bool isControllable = true;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.isKinematic = true;
    }

    private void Update ()
    {
        if (isControllable)
        {
            h = Input.GetAxis ("Horizontal");
        }
    }

	private void FixedUpdate ()
    {
        Vector2 newPosition = rb.position + new Vector2 (h, 0) * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp (newPosition.x, -screenWidth, screenWidth);

        rb.MovePosition (newPosition);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        isControllable = false;
        rb.isKinematic = false;
        GameManager.Instance.EndGame ();
    }

}
