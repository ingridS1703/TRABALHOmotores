using UnityEngine;

public class MovimentoSimples : MonoBehaviour
{
    public enum TipoJogador { WASD, Setas }

    [Header("Configurações do Jogador")]
    public TipoJogador esquemaDeTeclas = TipoJogador.WASD;
    public float velocidade = 5f;
    public float velocidadeRotacao = 720f;

    private CharacterController controller;
    private Animator animator;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        // Leitura direta das teclas do teclado sem dependência do Input System
        if (esquemaDeTeclas == TipoJogador.WASD)
        {
            if (Input.GetKey(KeyCode.W)) input.y += 1;
            if (Input.GetKey(KeyCode.S)) input.y -= 1;
            if (Input.GetKey(KeyCode.A)) input.x -= 1;
            if (Input.GetKey(KeyCode.D)) input.x += 1;
        }
        else if (esquemaDeTeclas == TipoJogador.Setas)
        {
            if (Input.GetKey(KeyCode.UpArrow)) input.y += 1;
            if (Input.GetKey(KeyCode.DownArrow)) input.y -= 1;
            if (Input.GetKey(KeyCode.LeftArrow)) input.x -= 1;
            if (Input.GetKey(KeyCode.RightArrow)) input.x += 1;
        }

        bool estaAndando = input.sqrMagnitude > 0.01f;

        // Atualiza a animação
        if (animator != null)
        {
            animator.SetBool("IsWalking", estaAndando);
            animator.SetFloat("Speed", input.magnitude);
        }

        if (!estaAndando) return;

        Vector3 direcao = new Vector3(input.x, 0f, input.y).normalized;

        // Movimentação
        if (controller != null)
        {
            controller.Move(direcao * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
        }

        // Rotação suave
        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
    }
}

