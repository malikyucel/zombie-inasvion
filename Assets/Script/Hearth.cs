using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
