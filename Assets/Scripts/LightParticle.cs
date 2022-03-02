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

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Colidiu com" + other.gameObject.tag);
        GameObject otherGO = other.gameObject;

        if (otherGO.CompareTag("Obstacle")) {
            Destroy(gameObject);
            return;
        }


        if (otherGO.CompareTag("LightReflector") && !justCollided) {
            justCollided = true;
            timerSinceLastCollision = 0f;

            Rigidbody2D lightReflectorRigidbody = otherGO.GetComponent<Rigidbody2D>();
            
            Vector2 dir = Vector2.Reflect(rb.velocity, lightReflectorRigidbody.transform.up).normalized;
            // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            rb.velocity = dir * keepVelocity;
            // rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            return;
        }
    }
}
