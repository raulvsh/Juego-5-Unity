using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BotonDificultad : MonoBehaviour
{
    private Button boton;
    private ControlJuego controlJuego;
    public int dificultad;

    // Start is called before the first frame update
    void Start()
    {
        boton = GetComponent<Button>();
        controlJuego = GameObject.Find("GestorJuego").GetComponent<ControlJuego>();
        boton.onClick.AddListener(EstablecerDificultad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EstablecerDificultad()
    {
        Debug.Log("Se ha pulsado " + gameObject.name);
        controlJuego.IniciarJuego(dificultad);
    }
}
