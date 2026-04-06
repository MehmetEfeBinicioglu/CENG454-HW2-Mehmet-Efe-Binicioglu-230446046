// MissileHoming.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Mehmet Efe Binicioğlu | Student ID: 230446046

using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 56f;
    [SerializeField] private float turnSpeed = 8f;
    private Transform target;

    public void SetTarget(Transform newTarget) { target = newTarget; }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion tiltedRotation = lookRotation * Quaternion.Euler(90, 0, 45);

        transform.rotation = Quaternion.Slerp(transform.rotation, tiltedRotation, turnSpeed * Time.deltaTime);
    }
}