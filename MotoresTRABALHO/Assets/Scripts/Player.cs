using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    public float velocidadeRotacao = 150f;

    [Header("Teclas de Controle")]
    public KeyCode frente = KeyCode.W;
    public KeyCode tras = KeyCode.S;
    public KeyCode esquerda = KeyCode.A;
    public KeyCode direita = KeyCode.D;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Leitura das Teclas de Movimento
        float moverFrenteTras = 0f;
        float girar = 0f;

        if (Input.GetKey(frente)) moverFrenteTras = 1f;
        if (Input.GetKey(tras)) moverFrenteTras = -1f;
        if (Input.GetKey(esquerda)) girar = -1f;
        if (Input.GetKey(direita)) girar = 1f;

        // 2. Rotação do Robô
        transform.Rotate(0, girar * velocidadeRotacao * Time.deltaTime, 0);

        // 3. Movimento para Frente/Trás
        Vector3 movimento = transform.forward * moverFrenteTras * velocidade;
        
        if (controller != null)
        {
            controller.SimpleMove(movimento);
        }
        else
        {
            transform.Translate(movimento * Time.deltaTime, Space.World);
        }

        // 4. Controle Seguro de Animação (Sem gerar erro na consola)
        if (animator != null)
        {
            bool estaAndando = (moverFrenteTras != 0f || girar != 0f);
            
            // Verifica se o parâmetro 'IsWalking' realmente existe antes de usar
            foreach (AnimatorControllerParameter param in animator.parameters)
            {
                if (param.name == "IsWalking")
                {
                    animator.SetBool("IsWalking", estaAndando);
                }
            }
        }
    }
}