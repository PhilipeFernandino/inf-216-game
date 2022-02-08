using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReflector : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("LightParticle")) {
            Debug.Log("Colidiu com particula de luz"); 
            float particleSpeed = other.gameObject.GetComponent<LightParticle>().speed;
            Rigidbody2D particleRb = other.gameObject.GetComponent<Rigidbody2D>();
            
            //Não entendo bem as direções (pra mim deveria ser considerando o transform.up da particula + da plataforma)
            //mas assim funciona
            Vector3 dir = (particleRb.transform.right - transform.up).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            //Adiciona velocidade no vetor resultante e rotaciona na direção dele
            particleRb.velocity = (particleRb.transform.right + transform.up).normalized * particleSpeed;
            particleRb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
