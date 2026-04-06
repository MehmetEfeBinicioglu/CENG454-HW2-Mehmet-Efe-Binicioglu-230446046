// DangerZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private GameObject missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
            if (activeCountdown != null) StopCoroutine(activeCountdown);
            activeCountdown = StartCoroutine(MissileLaunchSequence());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activeCountdown != null) StopCoroutine(activeCountdown);
            
            MissileLauncher launcherScript = missileLauncher.GetComponent<MissileLauncher>();
            if (launcherScript != null) launcherScript.DestroyActiveMissile();

            examManager.ExitDangerZone();
        }
    }

    IEnumerator MissileLaunchSequence()
    {
        yield return new WaitForSeconds(missileDelay);
        
        MissileLauncher launcherScript = missileLauncher.GetComponent<MissileLauncher>();
        if (launcherScript != null)
        {
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
            launcherScript.Launch(playerTransform);
        }
    }
}