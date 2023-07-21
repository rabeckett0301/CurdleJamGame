using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraulicPress : MonoBehaviour, IActivatable
{
    [Range(0, 20)]
    [SerializeField] float retractSpeed;
    [Range(-20, 0)]
    [SerializeField] float dropSpeed;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform retractPoint;
    [SerializeField] Transform collisionPoint;

    private void Start()
    {
        startPoint.SetParent(null);
        retractPoint.SetParent(null);
    }

    public void Activate()
    {
        StopAllCoroutines();
        StartCoroutine(StartRetracting());
    }

    public void Deactivate()
    {
        StopAllCoroutines();
        StartCoroutine(Drop());
    }

    IEnumerator StartRetracting()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        while(Vector2.Distance(collisionPoint.position, retractPoint.position) > 0.05f)
        {
            transform.position += new Vector3(0, retractSpeed) * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Drop()
    {
        GetComponent<BoxCollider2D>().enabled = true;

        while (Vector2.Distance(collisionPoint.position, startPoint.position) > 0.05f)
        {
            transform.position += new Vector3(0, dropSpeed) * Time.deltaTime;
            yield return null;
        }

        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
