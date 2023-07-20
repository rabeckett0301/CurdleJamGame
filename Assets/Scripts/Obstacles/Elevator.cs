using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IActivatable
{
    [Range(0, 10)]
    [SerializeField] float movementSpeed;

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    private void Start()
    {
        startPoint.SetParent(null);
        endPoint.SetParent(null);
    }

    public void Activate()
    {
        StopAllCoroutines();
        StartCoroutine(StartMovingTowardsEndPoint());
    }

    public void Deactivate()
    {
        StopAllCoroutines();
        StartCoroutine(StartMovingTowardsStartPoint());
    }

    IEnumerator StartMovingTowardsEndPoint()
    {
        while (Vector2.Distance(transform.position, endPoint.position) > 0.05f)
        {
            Vector3 direction = (endPoint.position - transform.position).normalized;

            transform.position += direction * movementSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator StartMovingTowardsStartPoint()
    {
        while (Vector2.Distance(transform.position, startPoint.position) > 0.05f)
        {
            transform.position += new Vector3(0, movementSpeed) * Time.deltaTime;
            yield return null;
        }
    }
}
