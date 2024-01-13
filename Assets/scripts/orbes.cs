using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbes : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float Force = 10.0f;

    void Start()
    {
        // Agrega una fuerza constante al inicio para que el enemigo se mueva inicialmente
        GetComponent<Rigidbody>().AddForce(GetRandomDirection() * Force, ForceMode.Impulse);
    }

    void Update()
    {
        // Si el enemigo está fuera de la pantalla, invierte la dirección aleatoriamente
        CheckOutOfBounds();
    }

    void CheckOutOfBounds()
    {
        // Obtiene las dimensiones de la cámara en el mundo
        float cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        float cameraHeight = Camera.main.orthographicSize * 2f;

        Vector3 currentPosition = transform.position;

        // Verifica si el enemigo está fuera de la pantalla en el eje X
        if (currentPosition.x < -cameraWidth / 2f || currentPosition.x > cameraWidth / 2f)
        {
            // Invierte la dirección en el eje X aleatoriamente
            GetComponent<Rigidbody>().velocity = new Vector3(GetRandomDirection().x * moveSpeed, GetComponent<Rigidbody>().velocity.y, 0f);
        }

        // Verifica si el enemigo está fuera de la pantalla en el eje Y
        if (currentPosition.y < -cameraHeight / 2f || currentPosition.y > cameraHeight / 2f)
        {
            // Invierte la dirección en el eje Y aleatoriamente
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetRandomDirection().y * moveSpeed, 0f);
        }
    }

    Vector3 GetRandomDirection()
    {
        // Genera una dirección aleatoria normalizada en un plano XY
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        return randomDirection;
    }
}
