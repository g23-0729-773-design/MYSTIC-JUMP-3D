using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform player; // Kusa itong mapupunan kapag nag-play ang game

    [Header("Offset Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public Vector3 cameraRotation = new Vector3(30f, 0f, 0f);

    [Header("Smooth Movement")]
    public float smoothSpeed = 10f;

    void Start()
    {
        AutoFindPlayer();
    }

    void LateUpdate()
    {
        if (player == null)
        {
            AutoFindPlayer();
            if (player == null) return;
        }

        // Posisyon at rotation ng camera
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(cameraRotation);
    }

    void AutoFindPlayer()
    {
        // 1. Hahanapin gamit ang PlayerController script
        MonoBehaviour playerScript = FindObjectOfType<MonoBehaviour>();
        if (playerScript != null && playerScript.GetType().Name.ToLower().Contains("player"))
        {
            player = playerScript.transform;
            return;
        }

        // 2. Hahanapin gamit ang Tag na "Player"
        GameObject taggedPlayer = GameObject.FindGameObjectWithTag("Player");
        if (taggedPlayer != null)
        {
            player = taggedPlayer.transform;
            return;
        }

        // 3. Hahanapin gamit ang pangalang "Player"
        GameObject namedPlayer = GameObject.Find("Player");
        if (namedPlayer != null)
        {
            player = namedPlayer.transform;
        }
    }
}