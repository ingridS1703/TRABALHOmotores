using UnityEngine;
using UnityEngine.InputSystem;

public class InicializarJogador : MonoBehaviour
{
    [Header("Arraste a Câmera interna do Robô aqui:")]
    [SerializeField] private GameObject cameraDoJogador;

    void Start()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        if (input != null && cameraDoJogador != null)
        {
            // 1. Ativa a câmera física do robô
            cameraDoJogador.SetActive(true);
            int idDoJogador = input.playerIndex;

            // 2. Divide a tela fisicamente ao meio (Split-Screen manual)
            Camera cam = cameraDoJogador.GetComponent<Camera>();
            if (cam != null)
            {
                cameraDoJogador.tag = "MainCamera";

                if (idDoJogador == 0)
                {
                    cam.rect = new Rect(0f, 0f, 0.5f, 1f); // Metade esquerda
                }
                else
                {
                    cam.rect = new Rect(0.5f, 0f, 0.5f, 1f); // Metade direita
                }
            }

            // 3. REMOVE O CONFLITO GLOBAL DO CINEMACHINE
            // Remove qualquer CinemachineBrain antigo que veio quebrado do Prefab
            var brainAntigo = cameraDoJogador.GetComponent<Unity.Cinemachine.CinemachineBrain>();
            if (brainAntigo != null) DestroyImmediate(brainAntigo);

            // Adiciona um CinemachineBrain NOVO e limpo direto na câmera física deste jogador
            var novoBrain = cameraDoJogador.AddComponent<Unity.Cinemachine.CinemachineBrain>();

            // 4. CONFIGURA AS CAMADAS DO CINEMACHINE VIA CÓDIGO (Isolamento Total)
            // Jogador 1 usa Canal 1, Jogador 2 usa Canal 2
            int meuCanalInt = (idDoJogador == 0) ? 1 : 2;
            Unity.Cinemachine.OutputChannels meuCanalCine = (Unity.Cinemachine.OutputChannels)meuCanalInt;

            // Diz para o novo cérebro escutar apenas o seu próprio canal
            novoBrain.ChannelMask = meuCanalCine;

            // Força todas as câmeras virtuais do robô a transmitirem apenas no canal dele
            var vcams = GetComponentsInChildren<Unity.Cinemachine.CinemachineCamera>(true);
            foreach (var vcam in vcams)
            {
                vcam.OutputChannel = meuCanalCine;
                vcam.Follow = this.transform; // Garante que vai seguir este robô específico
                vcam.LookAt = this.transform;  // Garante que vai olhar para este robô específico
            }
        }
    }
}
