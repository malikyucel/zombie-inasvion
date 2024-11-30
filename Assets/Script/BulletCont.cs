using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCont : MonoBehaviour
{
    public GameObject Bullet;
    public Transform player_transform;
    CharCont charCont;

    // Start is called before the first frame update
    void Start()
    {
        charCont = GameObject.Find("CowboyRio_Unity 1").GetComponent<CharCont>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charCont.characterCont)
        {
            if (Input.GetMouseButtonDown(0))
            {
                BulletSpawn();
            }
        }
    }
    void BulletSpawn()
    {
        Instantiate(Bullet, player_transform.position, player_transform.rotation);
    }

}
