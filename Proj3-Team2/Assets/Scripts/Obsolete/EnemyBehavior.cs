using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("ASSIGNED IN INSPECTOR")]
    [SerializeField] private float changeMin;
    [SerializeField] private float changeMax;
    [SerializeField] private float speed;
    [SerializeField] private float xMax, xMin, zMax, zMin;

    [Header("GENERATED VALUES")]
    [SerializeField] private float x;
    [SerializeField] private float z;
    [SerializeField] private float change;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Time.time >= change) //randomly changes direction on a random timer
        {
            x = Random.Range(xMin, xMax);
            z = Random.Range(zMin, zMax);
            change = Time.time + Random.Range(changeMin, changeMax);
        }
        DetermineDirection();
    }

    private void DetermineDirection()
    {
        rb.velocity = new Vector3(x * speed, 0, z * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wallZ")) //if elemental collides with a horizontal wall, changes z direction of elemental
        {
            z = -z;
            DetermineDirection();
        }
        else if (other.CompareTag("wallX")) //if elemental collides with a vertical wall, changes x direction of elemental
        {
            x = -x;
            DetermineDirection();
        }
    }
}
