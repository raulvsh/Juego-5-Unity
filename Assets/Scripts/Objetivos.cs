using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    private Rigidbody rbObjetivo;

    private ControlJuego controlJuego;

    private float rangoX = 4.0f;
    private float posY = -1.0f;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float torqueForce = 10.0f;
    public ParticleSystem explosion;

    public int valorPuntos;



    // Start is called before the first frame update
    void Start()
    {
        rbObjetivo = GetComponent<Rigidbody>();


        transform.position = PosGenerator();

        rbObjetivo.AddForce(ImpulseForce(), ForceMode.Impulse);

        rbObjetivo.AddTorque(ValorTorsion(),  ValorTorsion(), ValorTorsion(), ForceMode.Impulse);

        controlJuego = GameObject.Find("GestorJuego").GetComponent<ControlJuego>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 PosGenerator()
    {
        return new Vector3(Random.Range(-rangoX, rangoX), posY);
    }

    Vector3 ImpulseForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float ValorTorsion()
    {
        return Random.Range(-torqueForce, torqueForce);
    }

    private void OnMouseDown()
    {
        if (controlJuego.isActive)
        {

            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);
            controlJuego.ActualizarMarcador(valorPuntos);

        }


    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        if (gameObject.CompareTag("Bueno") && controlJuego.vidas!=0) 
        {
            controlJuego.ActualizarVidas(-1);
        }
        if(controlJuego.vidas==0)
        {
            controlJuego.GameOver();
        }
    }
}
