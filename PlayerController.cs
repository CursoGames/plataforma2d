using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rb;//física 
    Vector2 direcao; // localização 
    SpriteRenderer sprite; // imagem (sprite)
    [Header("Velocidade com que o personagem se move:")]
    public float velocidade;
    private Animator animator;
  
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();// Pega o componente Rigidbody2D do Player
        animator = GetComponent<Animator>();//Pega o componente Animator do Player
        sprite = GetComponent<SpriteRenderer>();//Pega o componente Sprite Renderer do Player
    }
    

    public void Mover(InputAction.CallbackContext context)
    {
        if (context.performed)// se as teclas forem pressionadas
        {
            direcao = context.ReadValue<Vector2>();//Lê as entradas do movimento
            Debug.Log("Direção do personagem:" +direcao);
            animator.SetBool("estaAndando",true);//executa a animação andando
            if (direcao.x < 0) // se estiver andando para a esquerda
            {
                sprite.flipX = true; // vira o sprite para a esquerda
            }
            if (direcao.x > 0) // se estiver andando para a direita
            {
                sprite.flipX = false;// "desvira"o sprite -- vira para a direita
            }
        }
        if (context.canceled)//se parar de pressionar as teclas
        {
            animator.SetBool("estaAndando", false);//pára de executar a animação andando
            direcao = Vector2.zero;// faz o player parar de andar.
        }
    }


     
    void FixedUpdate()
    {
        //Aplica o movimento ao Rigidbody2D do jogador
        rb.linearVelocity = new Vector2(direcao.x * velocidade, rb.linearVelocity.y);
    }

  
}
