// MissileLauncher.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource; // Fırlatma Sesi

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
        // TODO (Task 3-A): instantiate the missile at launchPoint
        // TODO (Task 3-B): give the missile its target 
        // TODO (Task 3-C): play launch audio and return the spawned missile 
    {
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        
        MissileHoming homingScript = activeMissile.GetComponent<MissileHoming>();
        if (homingScript != null) homingScript.SetTarget(target);

        if (launchAudioSource != null) launchAudioSource.Play();
        
        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null) Destroy(activeMissile);
    }
}