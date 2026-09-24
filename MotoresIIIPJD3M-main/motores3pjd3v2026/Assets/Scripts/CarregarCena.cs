using UnityEngine;

public class CarregarCena : MonoBehaviour
{
    public void Iniciar()
    {
        GameManager.Instance.LoadScene("GetStarted_Scene");
    }

    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}