using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LightReceiver : MonoBehaviour
{

    [SerializeField] private ParticleSystem onWin;

    private void Start()
    {
        onWin.Stop();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LightParticle"))
        {
            LevelData.won[LevelData.levelIndexLoaded] = true;
            onWin.Play();
            Destroy(other.gameObject);
            StartCoroutine(BackToMenu());
        }
    }

    private IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
