using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLogic : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Rifle;

    public TextMeshPro Text;
    public Animator anim;
    public Animator animEnemy;
    private Transform Enemy;
    public Rotation rot;
    public static bool canFinishing = false;

    public float time = 1.5f;
    private float timespan;

    private bool timerON = false;

    private void Start()
    {
        timespan = time;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFinishing)
        {
            PlayerMovment.canMove = false;
            timerON = true;
            Rifle.SetActive(false);
            Sword.SetActive(true);
            FinishingAction();
        }

        if (timerON)
        {
            timespan -= Time.deltaTime;
            if (timespan < 0)
            {
                Rifle.SetActive(true);
                Sword.SetActive(false);
                PlayerMovment.canMove = true;
                rot.enabled = true;
                timespan = time;
                timerON = false;
            }

            if (timespan < time*0.8)
                Enemy.gameObject.GetComponent<Animator>().enabled = false;
        }

        
    }

    void FinishingAction()
    {
        Text.gameObject.SetActive(false);
        rot.enabled = false;

        Enemy.gameObject.GetComponent<EnemyLogic>().Die();
        Enemy.gameObject.GetComponent<SphereCollider>().enabled = false;
        transform.LookAt(Enemy.position);
        transform.position = Vector3.Lerp( Enemy.position , transform.position, 0);
        transform.position += -transform.forward * 2;
        canFinishing = false;
        anim.SetTrigger("Finishing");
    }

    private void OnTriggerEnter(Collider other)
    {
        canFinishing = true;
        Text.gameObject.SetActive(true);
        Enemy = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        canFinishing = false;
        Text.gameObject.SetActive(false);
    }
}
