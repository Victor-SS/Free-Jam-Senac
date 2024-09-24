using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    public LayerMask pushableLayer; // Layer para objetos empurráveis/puxáveis
    public float pushPullSpeed = 2f; // Velocidade para puxar ou empurrar o objeto
    private GameObject objectBeingPushed; // O objeto que o jogador está interagindo
    private bool isPushing; // Verifica se o jogador está empurrando ou puxando

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Detecta se o objeto é empurrável
        if (collision.gameObject.CompareTag("Pushable"))
        {
            if (Input.GetKey(KeyCode.E)) // Pressiona 'E' para interagir
            {
                objectBeingPushed = collision.gameObject; // Guarda o objeto sendo empurrado/puxado
                isPushing = true; // Ativa o estado de empurrar/puxar
            }
        }
    }

    private void Update()
    {
        // Se o jogador estiver empurrando ou puxando
        if (isPushing && objectBeingPushed != null)
        {
            // Se o jogador soltar a tecla 'E', para de empurrar/puxar
            if (!Input.GetKey(KeyCode.E))
            {
                isPushing = false;
                objectBeingPushed = null; // Solta o objeto
            }
        }
    }

    private void FixedUpdate()
    {
        if (isPushing && objectBeingPushed != null)
        {
            PushOrPullObject(); // Aplica a lógica de puxar/empurrar a cada frame fixo
        }
    }

    private void PushOrPullObject()
    {
        // Obtém o Rigidbody2D do objeto sendo empurrado/puxado
        Rigidbody2D objectRb = objectBeingPushed.GetComponent<Rigidbody2D>();

        // Pega a posição do jogador e do objeto
        Vector2 playerPosition = transform.position;
        Vector2 objectPosition = objectBeingPushed.transform.position;

        // Calcula a direção do movimento baseado no input do jogador
        float moveInput = Input.GetAxis("Horizontal");

        // Checa se o jogador está movendo na mesma direção do objeto
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            // Define a nova posição do objeto para "seguir" o movimento do jogador
            Vector2 newPosition = new Vector2(objectPosition.x + moveInput * pushPullSpeed * Time.fixedDeltaTime, objectPosition.y);

            // Move o objeto suavemente com base na velocidade e direção do jogador
            objectRb.MovePosition(newPosition);
        }
    }
}
