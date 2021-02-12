using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    public List<GameObject> objetivos;
    public TextMeshProUGUI textoMarcador;
    public TextMeshProUGUI textoGameOver;
    public TextMeshProUGUI textoVidas;


    public bool isActive;
    public Button restartButton;
    public GameObject pantallaInicio;

    private int marcador;
    public int vidas;


    private float retrasoGeneracion = 2.0f;

    private AudioSource playerAudio;
    public AudioClip blipSound;
    public AudioClip explodeSound;
    public AudioClip gameOverSound;


    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerarObjetivos()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(retrasoGeneracion);
            int index = Random.Range(0, objetivos.Count);
            Instantiate(objetivos[index]);

        }
    }

    public void ActualizarMarcador(int puntosASumar)
    {
        playerAudio.PlayOneShot(blipSound, 1.0f);

        marcador += puntosASumar;
        textoMarcador.text = "Puntuacion: " + marcador;
    }

    public void ActualizarVidas(int v)
    {
        vidas += v;
        textoVidas.text = "Vidas: " + vidas;
        playerAudio.PlayOneShot(explodeSound, 1.0f);

    }

    public void GameOver()
    {
        playerAudio.PlayOneShot(gameOverSound, 1.0f);

        textoGameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isActive = false;

    }

    public void ReiniciarJuego()
    {
        textoGameOver.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void IniciarJuego(int dificultad)
    {
        retrasoGeneracion /= dificultad;
        if (dificultad == 1)
        {
            vidas = 5;
        } else if (dificultad == 2)
        {
            vidas = 3;
        }
        else
        {
            vidas = 1;
        }
        isActive = true;
        StartCoroutine(GenerarObjetivos());
        marcador = 0;
        ActualizarMarcador(0);
        //vidas = 3;
        ActualizarVidas(0);
        pantallaInicio.gameObject.SetActive(false);
    }


    

}
