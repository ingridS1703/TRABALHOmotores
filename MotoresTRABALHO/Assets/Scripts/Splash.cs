using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(EsperaParaMudar());
        }

        IEnumerator EsperaParaMudar()
        {
            yield return new WaitForSeconds(2f);

            GameManager.Instance.ChangeScene("MenuPrincipal", GameState.MenuPrincipal);
        }
    }
//
