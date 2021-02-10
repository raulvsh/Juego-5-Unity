using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public List<GameObject> objetivos;
    public TextMeshProUGUI textoMarcador;
    public TextMeshProUGUI textoGameOver;

    public bool isActive;

    private int marcador;

    private float retrasoGeneracion = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        StartCoroutine(GenerarObjetivos());
        marcador = 0;
        ActualizarMarcador(0);

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
        marcador += puntosASumar;
        textoMarcador.text = "Puntuacion: " + marcador;
    }

    public void GameOver()
    {
        textoGameOver.gameObject.SetActive(true);
        isActive = false;

    }
}
