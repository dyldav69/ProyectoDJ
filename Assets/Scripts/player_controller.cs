using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public Transform particulas;
    private ParticleSystem systemaParticulas;

    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        systemaParticulas=particulas.GetComponent <ParticleSystem>();
        systemaParticulas.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
            }
             
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movimiento= new Vector3 (moveHorizontal,0.0f, moveVertical);

        rb.AddForce(movimiento * speed);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Recolectable"))
        {
            posicion=other.gameObject.transform.position;
            particulas.position=posicion;
            systemaParticulas=particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();
        other.gameObject.SetActive (false);
        }
        else
        {
            
        }
    }
}
