using UnityEngine;

public class LightEmitter : MonoBehaviour {

    public LightParticle LightParticlePrefab;
    public float particleSpeed;

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            EmitLightParticle();
        }
    }

    private void EmitLightParticle() {
        LightParticle lightParticle = Instantiate<LightParticle>(LightParticlePrefab, transform.position, transform.rotation);
        lightParticle.GetComponent<Rigidbody2D>().velocity = transform.up * particleSpeed;
        lightParticle.keepVelocity = particleSpeed;
    }
}
