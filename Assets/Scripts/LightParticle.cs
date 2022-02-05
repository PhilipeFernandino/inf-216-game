using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParticle : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("LightReflector")) {
            Debug.Log("Colidiu com refletor");
            //TODO: adicionar a particula considerando a velocidade atual e a rotação da plataforma com que ela colidiu 
        }
    }
}
