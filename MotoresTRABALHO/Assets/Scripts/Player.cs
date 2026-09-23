using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    public float velocidadeRotacao = 720f;

    
    [Header("Esquema de Controlo")]
    
    public string defaultControlScheme = "WASD";

    
    [Header("Câmera do Jogador")]
    public Camera cameraDoJogador;
    public Vector3 offsetCamera = new Vector3(0f, 3f, -5f);
    public float velocidadeCamera = 5f;

    private PlayerInput playerInput;
    private Vector2 inputMovimento;
    private CharacterController controller;
    private Animator animator;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>(); // Encontra o Animator no corpo/filhos do robô
    }

    void OnEnable()
    {
        
        if (playerInput != null)
        {
            playerInput.ActivateInput();
            ForcarEsquemaDeControlo();
        }
    }

    void OnDisable()
    {
        
        if (playerInput != null)
        {
            playerInput.DeactivateInput();
        }
    }

    
    public void OnMove(InputValue value)
    {
        inputMovimento = value.Get<Vector2>();
    }

    void Update()
    {
        MoverJogador();
    }

    void LateUpdate()
    {
        AtualizarPosicaoCamera();
    }

    private void MoverJogador()
    {
        // Atualiza a animação (saber se está a andar ou parado)
        bool estaAndando = inputMovimento.sqrMagnitude > 0.01f;
        if (animator != null)
        {
            animator.SetBool("IsWalking", estaAndando);
            animator.SetFloat("Speed", inputMovimento.magnitude);
        }

        if (!estaAndando) return;

        Vector3 direcao = new Vector3(inputMovimento.x, 0f, inputMovimento.y);

        
        if (controller != null)
        {
            controller.Move(direcao * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
        }

        
        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
    }

    private void AtualizarPosicaoCamera()
    {
        if (cameraDoJogador == null) return;

        // Calcula a posição da câmera em relação ao robô e move suavemente
        Vector3 posicaoDesejada = transform.position + offsetCamera;
        cameraDoJogador.transform.position = Vector3.Lerp(cameraDoJogador.transform.position, posicaoDesejada, velocidadeCamera * Time.deltaTime);
        cameraDoJogador.transform.LookAt(transform.position + Vector3.up * 1.5f);
    }

    public void ForcarEsquemaDeControlo()
    {
        if (playerInput != null && !string.IsNullOrEmpty(defaultControlScheme))
        {
            
            playerInput.SwitchCurrentControlScheme(defaultControlScheme, Keyboard.current);
        }
    }
}

