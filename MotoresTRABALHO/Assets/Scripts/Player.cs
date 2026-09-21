using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int moedasColetadas = 0;
    [SerializeField] private float forcaPulo = 8f;
    [SerializeField] private float velocidadeMove = 5f;

    private Rigidbody rb;
    private PlayerInput inputDoJogador;
    private Vector2 direcaoMove;

    void Start()
    {

        
        rb = GetComponent<Rigidbody>();
        inputDoJogador = GetComponent<PlayerInput>();

        if (GameManager.Instance != null && inputDoJogador != null)
        {
            GameManager.Instance.AssignPlayerInput(inputDoJogador);
        }
    }

    // Chamado automaticamente quando o robô move no WASD ou Setas
    public void OnMove(InputValue value)
    {
        direcaoMove = value.Get<Vector2>();
    }

    // Chamado automaticamente quando a ação "Jump" é pressionada
    public void OnJump()
    {
        if (rb != null)
        {
            // Aplica o pulo no robô correspondente
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, forcaPulo, rb.linearVelocity.z);
        }
    }

    void Update()
    {
        // Aplica a movimentação no Robô (X e Z no espaço 3D)
        if (rb != null)
        {
            Vector3 movimento = new Vector3(direcaoMove.x * velocidadeMove, rb.linearVelocity.y, direcaoMove.y * velocidadeMove);
            rb.linearVelocity = movimento;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda"))
        {
            moedasColetadas++;
            PlayerObserverMnager.SetCoinCollected(moedasColetadas);
            Destroy(other.gameObject);
        }
    }
}