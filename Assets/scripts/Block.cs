using UnityEngine;

public class Block : MonoBehaviour {

	private void Update ()
    {
        if (transform.position.y < -10f)
        {
            Destroy (gameObject);
        }
    }

}
