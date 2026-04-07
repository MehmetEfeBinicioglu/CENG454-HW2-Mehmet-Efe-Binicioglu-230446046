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
    [SerializeField] private AudioSource warningAudio; // Danger Zone Warning Sound Effect
    [SerializeField] private AudioSource successAudio; // Mission Accomplished Sound Effect

    private bool isDead = false;
    private bool threatCleared = false; 

    void Start()
    {
        statusText.text = "MISSION START: Fly to Danger Zone";
        statusText.color = Color.white;
        if (missionText != null) missionText.text = "Objective: Takeoff";
    }

    public void EnterDangerZone()
    {
        if (isDead) return;
        
        threatCleared = false; 
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;
        if (missionText != null) missionText.text = "Objective: Survive and Escape!";
        
        if (warningAudio != null && !warningAudio.isPlaying) warningAudio.Play();
    }

    public void ExitDangerZone()
    {
        if (isDead) return;

        threatCleared = true; 
        statusText.text = "Threat Cleared! Ready to Land!";
        statusText.color = Color.green;
        if (missionText != null) missionText.text = "Objective: Return and Land";
        if (warningAudio != null) warningAudio.Stop();
    }

    public void LandingDetected()
    {
        if (isDead) return;

        if (threatCleared)
        {
            statusText.text = "MISSION ACCOMPLISHED!";
            statusText.color = Color.cyan;
            
            if (successAudio != null && !successAudio.isPlaying) successAudio.Play();
            
            Debug.Log("Final Mission Loop Completed Successfully!");
        }
        else
        {
            statusText.text = "MISSION FAILED!";
            statusText.color = Color.yellow;
        }
    }

    public void HandleFailure()
    {
        isDead = true;
        statusText.text = "AIRCRAFT DESTROYED!";
        statusText.color = Color.red;
        
        if (warningAudio != null) warningAudio.Stop();
    }
}