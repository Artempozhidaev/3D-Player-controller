using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject enemy;
    public Animator animator;
    public static EnemyLogic Instance;
    bool _timerON = false;
    public float time = 5;
    float timespan;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        onSpawn();
    }

    private void onSpawn()
    {
        animator = GetComponent<Animator>();
        gameObject.GetComponent<SphereCollider>().enabled = true;
        animator.enabled = true;
        timespan = time;
        _timerON = false;
    }
    private void Update()
    {
        if (_timerON)
        {
            if ((timespan -= Time.deltaTime) < 0)
            {
                transform.position = GetRandomPosition(10, 10);
                onSpawn();
            }
        }
    }

    private Vector3 GetRandomPosition(float x, float z)
    {
        float get_x = Random.Range(-x, x);
        float get_z = Random.Range(-z, z);
        Vector3 position = new Vector3(get_x, 0, get_z);
        return position;
    }

    public void Die()
    {
        _timerON = true;
    }
}
