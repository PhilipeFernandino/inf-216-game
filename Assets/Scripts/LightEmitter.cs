using UnityEngine;

//A maioria dos scripts serão derivados do MonoBehaviour, que é a classe base para todos os objetos do jogo (gameObjects)
public class LightEmitter : MonoBehaviour {

    //Variáveis públicas podem ser acessadas por outras classes e também podem ser editadas pelo Inspector da engine
    public GameObject LightParticlePrefab;
    public float emitterPower = 10f;

    //Update() é uma função que a engine chama todo frame
    private void Update() {
        //Se for detectado um clique com o botão direito
        if (Input.GetMouseButtonDown(0)) {
            EmitLightParticle();
        }
    }

    private void EmitLightParticle() {
        
        //Instanciando um prefab (pense como uma classe, mas que existe no jogo) usando a 
        //posição do objeto (transform.position --> é derivada do monobehaviour) ao qual esse script (LightEmitter) está acoplado
        GameObject lightParticle = Instantiate(LightParticlePrefab, transform.position, Quaternion.identity);
        
        //Usando a referência do prefab, pegamos o Rigidbody2D (que é apenas um script que está acoplado ao prefab) e definimos sua
        //velocidade, usando a rotação do LightEmitter (transform.up (um vetor que aponta para cima do lightEmitter)) e multiplicamos
        //pela força que podemos definir no editor ou no script
        lightParticle.GetComponent<Rigidbody2D>().velocity = transform.up * emitterPower;
    }
}
