using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmitter : MonoBehaviour {

    public GameObject LightParticlePrefab;
    public float emitterPower = 10f;

    //Update() é uma função que a engine chama todo frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            EmitLightParticle();
        }
    }

    private void EmitLightParticle() {
        GameObject lightParticle = Instantiate(LightParticlePrefab, transform.position, Quaternion.identity);
        lightParticle.GetComponent<Rigidbody2D>().velocity = Vector2.up * emitterPower;
    }
}
