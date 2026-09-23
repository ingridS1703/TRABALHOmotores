using UnityEngine;
using UnityEngine.InputSystem;

public class GerenciadorTeclado : MonoBehaviour
{
    [Header("Player 1")]
    public GameObject roboPlayer1;
    public Camera cameraPlayer1;

    [Header("Player 2")]
    public GameObject roboPlayer2;
    public Camera cameraPlayer2;

    void Start()
    {
        // Desativa os robôs inicialmente, mas deixa a Camera 1 ativa para não dar "No cameras rendering"
        if (roboPlayer1 != null) roboPlayer1.SetActive(false);
        if (roboPlayer2 != null) roboPlayer2.SetActive(false);

        if (cameraPlayer1 != null)
        {
            cameraPlayer1.enabled = true;
            cameraPlayer1.rect = new Rect(0f, 0f, 1f, 1f); // Começa em Tela Cheia
        }

        if (cameraPlayer2 != null)
        {
            cameraPlayer2.enabled = false;
        }
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // Ativa o Player 1 ao apertar 1
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            AtivarPlayer1();
        }

        // Ativa o Player 2 e divide a tela ao apertar 2
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            AtivarPlayer2();
        }
    }

    void AtivarPlayer1()
    {
        if (roboPlayer1 != null) roboPlayer1.SetActive(true);
        AtualizarViewports();
    }

    void AtivarPlayer2()
    {
        if (roboPlayer2 != null) roboPlayer2.SetActive(true);
        if (cameraPlayer2 != null) cameraPlayer2.enabled = true;
        AtualizarViewports();
    }

    void AtualizarViewports()
    {
        // Se ambos os robôs/câmeras estiverem ativos, divide 50/50
        if (cameraPlayer1 != null && cameraPlayer2 != null && cameraPlayer2.enabled)
        {
            cameraPlayer1.rect = new Rect(0f, 0f, 0.5f, 1f);
            cameraPlayer2.rect = new Rect(0.5f, 0f, 0.5f, 1f);
        }
        else if (cameraPlayer1 != null)
        {
            cameraPlayer1.rect = new Rect(0f, 0f, 1f, 1f);
        }
    }
}

