using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour



{

    private int moedasColetadas = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda"))
        {
            moedasColetadas++;
            
            PlayerObserverMnager.SetCoinCollected(moedasColetadas);
            
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
       
        PlayerInput inputDoJogador = GetComponent<PlayerInput>();
       
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AssignPlayerInput(inputDoJogador);
        }
    }
    
}
