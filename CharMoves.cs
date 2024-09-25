using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoves : MonoBehaviour
{
    private Rigidbody2D rb; //Variável do personagem
    private SpriteRenderer rbSprite;
    //private Animator animator; //Variável da Animação

    public float Velocidade = 5f; //Velocidade de Movimento do personagem
    public float Pulo = 12f; //Força do Pulo

    //Tudo para Verificar o chão
    public bool Chao; 
    public Transform EstaChao; 
    public float ChaoRaio;
    public LayerMask LayerTerreno;

    // Start is called before the first frame update
    void Start()
    {
        rbSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Pular();
    }
    private void FixedUpdate()
    {
        Movimentar();
    }
    //Movimenta o personagem
    private void Movimentar()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*Velocidade,rb.velocity.y);

        if (moveInput > 0)
        {
            rbSprite.flipX = false;
        }
        else if(moveInput < 0)
        {
            rbSprite.flipY = true;
        }
    }
    //Faz o Personagem Pular
    private void Pular()
    {
        Chao = Physics2D.OverlapCircle(EstaChao.position, ChaoRaio, LayerTerreno);
        if (Input.GetButtonDown("Jump") && Chao)
        {
            rb.velocity = new Vector2(rb.velocity.x, Pulo);
        }
    }
}
