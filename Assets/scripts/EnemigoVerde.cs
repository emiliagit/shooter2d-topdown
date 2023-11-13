using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVerde : MonoBehaviour
{

    private Transform jugador; // Referencia al transform del jugador
    public float velocidad = 2.0f;   // Velocidad a la que el enemigo seguirá al jugador

    //datos para daño de jugador
    public int daño = 20;
    //private VidaJugador VidaPlayer;
    GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador == null)
        {
            Debug.LogWarning("No se ha asignado una referencia al jugador.");
            return;
        }

        // Calcular la dirección hacia el jugador
        Vector2 direccion = jugador.position - transform.position;
        direccion.Normalize(); // Normalizar para obtener una dirección unitaria

        // Mover al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World); // Usar Space.World para mover en el mundo

        transform.LookAt(jugador);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jugador = player.transform;

    }
}
