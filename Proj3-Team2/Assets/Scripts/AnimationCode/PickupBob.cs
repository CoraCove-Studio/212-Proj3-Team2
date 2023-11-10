using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBob : MonoBehaviour
{
    [SerializeField] float bobbingSpeed = 1.0f;
    [SerializeField] float bobbingAmount = 1.0f;

    private float timer = 0.0f;
    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        timer += Time.deltaTime * bobbingSpeed;
        if (timer > 1.0f) timer -= 1.0f;
        float xPos = startPosition.x + Mathf.Sin(timer * Mathf.PI * 2) * bobbingAmount;
        float yPos = startPosition.y + Mathf.Cos(timer * Mathf.PI * 2) * bobbingAmount;
        transform.position = new Vector3(xPos, yPos, startPosition.z);

    }
}
