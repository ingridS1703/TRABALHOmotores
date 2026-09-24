using StarterAssets;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        ThirdPersonController player =
            other.GetComponentInParent<ThirdPersonController>();

        if (player == null)
            return;

        PlayerObserverManager.NotifyStarCollected(player);

        Star[] remainingStars =
            FindObjectsByType<Star>(FindObjectsSortMode.None);

        if (remainingStars.Length == 1)
        {
            PlayerObserverManager.NotifyAllStarsCollected();
        }

        Destroy(gameObject);
    }
}