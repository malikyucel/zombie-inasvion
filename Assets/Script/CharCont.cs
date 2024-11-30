using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class CharCont : MonoBehaviour
{
    private CharacterController characterController;
    public bool characterCont = true;
    [SerializeField] private float _speed = 2.4f;
    [SerializeField] private float rotateSpeed;
    [SerializeField] public GameObject[] weaponry;
    private ZombieCont zombieCont;
    public GameObject Zombie;

    Vector3 _movement ;

    Animator animator;

    private int health = 100;
    public int currenthealth;
    public healthBar healthBar;
    public Text Health_Number;

    private int bullet = 30;
    public Text bulletText;
    public Text ClipText;
    public Text buulet_clip_text;
    private int Clip = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        zombieCont = Zombie.GetComponent<ZombieCont>();

        currenthealth = health;
        Health_Number.text = "Health: " + currenthealth;
        healthBar.SetMaxHealth(health);
    }
    private void Update()
    {
        Rotate();
        AnimationEndMovement();
        buulet_clip_text.text = bullet + " / " + Clip;
    }
    IEnumerator Shood()
    {
        characterCont = false;
        animator.Play("Shoot");
        weaponry[0].SetActive(false);
        weaponry[1].SetActive(false);
        weaponry[2].SetActive(false);
        weaponry[3].SetActive(false);
        weaponry[4].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        characterCont = true;
    }
    void TakeDamega(int damage)
    {
        currenthealth -= damage;
        Health_Number.text = "Health: " + currenthealth;
        healthBar.SetHealt(currenthealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie") && currenthealth <= 0)
        {
            animator.Play("Dead");
            characterCont = false;
        }
        else if (other.gameObject.CompareTag("Zombie") && currenthealth > 0)
        {
            int RandomHealth = Random.Range(1, 3);
            TakeDamega(RandomHealth);
        }
        else if (other.gameObject.CompareTag("RedZombie") && currenthealth > 0)
        {
            int RandomHealth = Random.Range(3, 6);
            TakeDamega(RandomHealth);
        }
        if (other.gameObject.CompareTag("Clip"))
        {
            Clip++;
            ClipText.text = "Clip: " + Clip;
            Destroy(other.gameObject);
        }
    }
    void AnimationEndMovement()
    {
        if (bullet == 0 && Clip > 0)
        {
            bullet = 30;
            Clip--;
            ClipText.text = "Clip: " + Clip;
            bulletText.text = "Bullet: " + bullet;
        }
        if (Input.GetKey(KeyCode.Mouse0) && characterCont && bullet > 0)
        {
            StartCoroutine(Shood());
            bullet--;
            bulletText.text = "Bullet " + bullet;
        }
        else if (characterCont)
        {
            Movement();
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _speed = 8.0f;
                    animator.Play("Runing");
                    weaponry[0].SetActive(false);
                    weaponry[1].SetActive(false);
                    weaponry[2].SetActive(true);
                    weaponry[3].SetActive(false);
                    weaponry[4].SetActive(false);

                }
                else
                {
                    weaponry[0].SetActive(false);
                    weaponry[1].SetActive(true);
                    weaponry[2].SetActive(false);
                    weaponry[3].SetActive(false);
                    weaponry[4].SetActive(false);
                    _speed = 2.4f;
                    animator.Play("Walk");
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                weaponry[0].SetActive(false);
                weaponry[1].SetActive(false);
                weaponry[2].SetActive(false);
                weaponry[3].SetActive(true);
                weaponry[4].SetActive(false);
                animator.Play("Back");
                _speed = 2.0f;
            }
            else
            {
                animator.Play("Idle");
                weaponry[0].SetActive(true);
                weaponry[1].SetActive(false);
                weaponry[2].SetActive(false);
                weaponry[3].SetActive(false);
                weaponry[4].SetActive(false);
            }
        }
    }
    void Rotate()
    {
        // Rotate
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed , 0);
    }
    void Movement()
    {
        // Movet
        _movement = transform.TransformDirection(Vector3.forward);
        float curretSpeed = _speed * Input.GetAxis("Vertical");
        characterController.SimpleMove(_movement * curretSpeed);
    }
}