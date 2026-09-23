using UnityEngine;

public class SeguirCameraSimples : MonoBehaviour
{
    public Transform alvoRobo;
    public Vector3 offset = new Vector3(0f, 3f, -5f);

    void LateUpdate()
    {
        if (alvoRobo == null) return;

        // Acompanha a posição exata do robô
        transform.position = alvoRobo.position + offset;
        transform.LookAt(alvoRobo.position + Vector3.up * 1.5f);
    }
}
