using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        StartCoroutine(destroy_bullet());
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    IEnumerator destroy_bullet()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
