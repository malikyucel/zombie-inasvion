using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    [SerializeField]private int DestroyTime = 30;
    [SerializeField]private float speed = 15.0f;
    IEnumerator Destroy_Time()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(Destroy_Time());
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
