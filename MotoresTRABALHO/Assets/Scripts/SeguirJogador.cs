using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    [Header("Alvo a Seguir")]
    public Transform alvo;

    [Header("Configurações da Câmera")]
    public Vector3 offset = new Vector3(0f, 3f, -5f); // Distância (X, Y, Z) em relação ao robô
    public float velocidadeSuave = 5f;

    void LateUpdate()
    {
        if (alvo == null) return;

        // Posição desejada com base na posição do robô + offset
        Vector3 posicaoDesejada = alvo.position + offset;

        // Move a câmera suavemente até à posição desejada
        Vector3 posicaoSuave = Vector3.Lerp(transform.position, posicaoDesejada, velocidadeSuave * Time.deltaTime);
        transform.position = posicaoSuave;

        // Faz a câmera olhar para o robô
        transform.LookAt(alvo.position + Vector3.up * 1.5f);
    }
}