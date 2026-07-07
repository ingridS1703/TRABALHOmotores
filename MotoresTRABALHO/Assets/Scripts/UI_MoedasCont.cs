using UnityEngine;
using TMPro;

public class UI_MoedasCont : MonoBehaviour
{
    [SerializeField] private TMP_Text textoMoedas;

    private void OnEnable()
    {

        PlayerObserverMnager.OnCoinCollected += AtualizarTexto;
    }

    private void OnDisable()
    {

        PlayerObserverMnager.OnCoinCollected -= AtualizarTexto;
    }

    private void AtualizarTexto(int quantidadeDeMoedas)
    {
        textoMoedas.text = "Moedas:  " + quantidadeDeMoedas.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
