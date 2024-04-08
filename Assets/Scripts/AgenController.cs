using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class AgenController : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    [SerializeField]
    GameObject target;
    public int Score = 0;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            print($"Score = {Score}");
            Score ++;
        }
    }
}
