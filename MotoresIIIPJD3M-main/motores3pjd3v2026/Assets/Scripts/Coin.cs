using StarterAssets;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISÃO COM A MOEDA: " + other.name);

        if (!other.CompareTag("Player"))
            return;

        ThirdPersonController player =
            other.GetComponentInParent<ThirdPersonController>();

        if (player == null)
            return;

        PlayerObserverManager.NotifyCoinCollected(player);

        Destroy(gameObject);
    }
}