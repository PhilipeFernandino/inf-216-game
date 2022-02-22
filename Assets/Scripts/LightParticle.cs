using UnityEngine;

public class LightParticle : MonoBehaviour {

    public float speed;
        
    private Rigidbody2D rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Colidiu com" + other.gameObject.tag);
        GameObject otherGO = other.gameObject;

        if (otherGO.CompareTag("Obstacle")) {
            Destroy(gameObject);
            return;
        }


        if (otherGO.CompareTag("LightReflector")) {
            Rigidbody2D lightReflectorRigidbody = otherGO.GetComponent<Rigidbody2D>();
            
            Vector3 dir = Vector3.Reflect(rb.velocity, lightReflectorRigidbody.transform.up).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            rb.velocity = dir * speed;
            rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            return;
        }
    }
}
