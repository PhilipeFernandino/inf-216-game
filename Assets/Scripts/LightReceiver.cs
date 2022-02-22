using UnityEngine;

public class LightReceiver : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("LightParticle")) {
            Debug.Log("Sucesso"); 
            Destroy(other.gameObject);
        }
    }
}
