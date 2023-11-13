using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;
    private Rigidbody2D rb;


    private float limiteIzquierdo = -8.35f;
    private float limiteDerecho = 8.42f;
    private float limiteSuperior = 4.49f;
    private float limiteInferior = -4.42f;

    


    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //CalculateScreenBounds();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        float x = transform.position.x;
        float y = transform.position.y;

        // Limitar las coordenadas dentro de los límites de la pantalla
        x = Mathf.Clamp(x, limiteIzquierdo, limiteDerecho);
        y = Mathf.Clamp(y, limiteInferior, limiteSuperior);

        // Aplicar las nuevas coordenadas al jugador
        transform.position = new Vector3(x, y, transform.position.z);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDireccion = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDireccion.y, lookDireccion.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
