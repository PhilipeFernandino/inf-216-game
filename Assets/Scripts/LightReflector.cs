using UnityEngine;

public class LightReflector : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("LightParticle")) {
            Debug.Log("Colidiu com particula de luz"); 
            //obs: má prática, a decisão deveria ser da partícula e a velocidade deveria ser privada  
            float particleSpeed = other.gameObject.GetComponent<LightParticle>().speed;
            Rigidbody2D particleRb = other.gameObject.GetComponent<Rigidbody2D>();
            
            Vector3 dir = Vector3.Reflect(particleRb.transform.up, transform.up).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            particleRb.velocity = dir * particleSpeed;
            particleRb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
