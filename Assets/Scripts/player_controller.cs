using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public Transform particulas;
    private ParticleSystem systemaParticulas;

    public AudioSource sonido;

    private int puntaje = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movimiento * speed);
    }

void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Recolectable"))
    {
        puntaje += 1;

        Debug.Log("Objeto bueno +1 punto. Puntaje total: " + puntaje);

        GameManager.BonusTiempo(2f);

        particulas.position = other.transform.position;
        systemaParticulas.Play();

        if(sonido != null)
        sonido.Play();

        other.gameObject.SetActive(false);
    }

    else if(other.CompareTag("Malo"))
    {
        puntaje -= 1;

        Debug.Log("Objeto malo -1 punto. Puntaje total: " + puntaje);

        GameManager.PenalizacionTiempo(2f);

        particulas.position = other.transform.position;
        systemaParticulas.Play();

        if(sonido != null)
        sonido.Play();

        other.gameObject.SetActive(false);
    }

    else if(other.CompareTag("Final"))
    {
        GameManager.GanarJuego(puntaje);
    }

    else if(other.CompareTag("Death"))
    {
        GameManager.ReiniciarJuego();
    }
}
}