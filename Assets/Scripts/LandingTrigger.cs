// LandingTrigger.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;

public class LandingTrigger : MonoBehaviour
{
    [Header("Manager Connection")]
    public FlightExamManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ucak piste dokundu! Manager'a haber veriliyor...");
            if (manager != null)
            {
                manager.LandingDetected();
            }
        }
    }
}