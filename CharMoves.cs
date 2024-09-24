using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoves : MonoBehaviour
{
    private Rigidbody2D rb; //Var�avel do personagem
    public float Velocidade = 1f; //Velocidade de Movimento do personagem
    public float Pulo = 1f; //For�a do Pulo
    private bool Chao; //Vamos utilizar para verificar se est� no Ch�o
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimenta��o horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Velocidade, rb.velocity.y);

        // Pulo
        if (Input.GetButtonDown("Jump") && Chao)
        {
            rb.velocity = new Vector2(rb.velocity.x, Pulo);
        }
        // Faz o Personagem Rotacionar
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Verifica se o Personagem est� no ch�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            Chao = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            Chao = false;
        }
    }
}
