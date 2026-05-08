using UnityEngine;
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour
{
    
    void Start()
    {
       
        PlayerInput inputDoJogador = GetComponent<PlayerInput>();
       
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AssignPlayerInput(inputDoJogador);
        }
    }
}
