
using UnityEngine;
using UnityEngine.InputSystem; // Certifique-se de que esta linha está no topo!

public class Player : MonoBehaviour
{
    
    private int moedasColetadas = 0;
    [SerializeField] private float forcaPulo = 8f; 
    private Rigidbody rb;
    
    // Guardamos o componente aqui para usar no Update
    private PlayerInput inputDoJogador; 
    private InputAction jumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputDoJogador = GetComponent<PlayerInput>();

        // Procura a ação chamada "Jump" dentro do Input System do robô
        if (inputDoJogador != null)
        {
            jumpAction = inputDoJogador.actions.FindAction("Jump");
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AssignPlayerInput(inputDoJogador);
        }
    }

    void Update()
    {
        // Força a leitura direta da tecla de espaço do Novo Input System
        if (InputSystem.GetDevice<Keyboard>() != null && InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
        {
            if (rb != null)
            {
                // Em vez de somar força, nós definimos a velocidade vertical diretamente para 15 (um valor bem forte para testar!)
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 15f, rb.linearVelocity.z);
                
                // Se a sua Unity usar a versão mais recente e der erro na linha de cima, use esta:
                // rb.linearVelocity = new Vector3(rb.linearVelocity.x, 15f, rb.linearVelocity.z);
                
                Debug.LogWarning("PULO EXECUTADO VIA CÓDIGO!");
            }
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
