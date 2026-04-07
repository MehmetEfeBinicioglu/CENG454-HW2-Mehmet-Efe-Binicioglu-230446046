// AircraftThreatHandler.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint; 
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Missile"))
        {
            // Sound Effect
            if (hitAudioSource != null) hitAudioSource.Play();

            // Respawn
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero;
            }

            if (examManager != null) examManager.HandleFailure();

            Destroy(collision.gameObject);
        }
    }
}