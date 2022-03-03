using UnityEngine;

public class LightParticle : MonoBehaviour {

    [HideInInspector]
    public float keepVelocity;

    public float timeBetweenCollisions;
     
    private Rigidbody2D rb;
    private float timerSinceLastCollision;
    private bool justCollided;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (justCollided) {
            if (timerSinceLastCollision > timeBetweenCollisions) justCollided = false;
            timerSinceLastCollision += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       
        if (justCollided || !rb.isKinematic) return;
        Debug.Log("Colidiu com: " + other.gameObject.tag);
        
        GameObject otherGO = other.gameObject;
        
        if (otherGO.CompareTag("Obstacle")) {
            Destroy(gameObject);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (justCollided || !rb.isKinematic) return;
        Debug.Log("Colidiu com: " + other.gameObject.tag);
        
        foreach (var contact in other.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.red, 2f);
            Debug.Log("Hit normal: " + contact.normal);
        }

        GameObject otherGO = other.gameObject;
        if (otherGO.CompareTag("LightReflector")) {
            justCollided = true;
            timerSinceLastCollision = 0f;

            Collider2D lightReflectorCollider = otherGO.GetComponent<Collider2D>();
            Vector2 dir = Vector2.Reflect(rb.velocity, other.GetContact(0).normal).normalized;

            rb.velocity = dir * keepVelocity;
            return;
        }
    }
}
