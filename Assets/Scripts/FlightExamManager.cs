// FlightExamManager.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    
    [Header("Audio Events")]
    [SerializeField] private AudioSource warningAudio;
    [SerializeField] private AudioSource successAudio;

    private bool isDead = false;
    private bool threatCleared = true;

    public void EnterDangerZone()
    {
        isDead = false;
        threatCleared = false;
        
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;

        if (missionText != null) 
            missionText.text = "Objective: Survive and Escape the Valley!";

        // ALARM
        if (warningAudio != null && !warningAudio.isPlaying) 
            warningAudio.Play();
    }

    public void ExitDangerZone()
    {
        if (!isDead)
        {
            threatCleared = true;
            statusText.text = "Threat Cleared! Proceed to Landing.";
            statusText.color = Color.green;

            if (missionText != null) 
                missionText.text = "Objective: Land Safely at Landing Zone";
            if (warningAudio != null) warningAudio.Stop();
            if (successAudio != null) successAudio.Play();
        }
    }

    public void HandleFailure()
    {
        isDead = true; 
        
        statusText.text = "CRITICAL HIT! AIRCRAFT DESTROYED";
        statusText.color = Color.red;

        if (missionText != null) 
            missionText.text = "STATUS: Respawning at Base...";

        if (warningAudio != null) warningAudio.Stop();
    }
}