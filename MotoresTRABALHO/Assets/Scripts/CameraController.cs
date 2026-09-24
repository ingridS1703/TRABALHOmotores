using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Alvo")]
    public Transform alvo; // O robô que a câmera vai seguir

    [Header("Posicionamento")]
    public Vector3 offset = new Vector3(0f, 3f, -5f); // Distância da câmera em relação ao robô
    public float suavidade = 10f; // Velocidade de acompanhamento

    [Header("Olhar para o Alvo")]
    public Vector3 offsetOlhar = new Vector3(0f, 1.5f, 0f); // Ponto de foco (altura do peito/cabeça do robô)

    void LateUpdate()
    {
        if (alvo == null) return;

        // 1. Posição desejada (Posição do Robô + Offset no espaço local dele)
        Vector3 posicaoDesejada = alvo.position + (alvo.rotation * offset);

        // 2. Transição suave entre a posição atual da câmera e a posição desejada
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, suavidade * Time.deltaTime);

        // 3. Faz a câmera olhar suavemente para o robô
        Vector3 pontoParaOlhar = alvo.position + offsetOlhar;
        transform.LookAt(pontoParaOlhar);
    }
}

