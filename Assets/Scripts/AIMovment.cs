using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIMovment : MonoBehaviour
{
    // Random Point generator
    public static Vector3 Random_Point_Get(Vector3 Start_Point, float Radius)
    {
        Vector3 Dir = Random.insideUnitSphere * Radius;

        Dir += Start_Point;
        NavMeshHit Hit_;
        Vector3 Final_Pos = Vector3.zero;

        if (NavMesh.SamplePosition(Dir, out Hit_, Radius, 1))
        {
            Final_Pos = Hit_.position;
        }
        return Final_Pos;
    }

    [SerializeField]
    private float Radius = 20;

    NavMeshAgent MrBean;

    Vector3 Next_Position;

    // Start is called before the first frame update
    void Start()
    {
        MrBean = GetComponent<NavMeshAgent>();
        Next_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Next_Position, transform.position) <= 1.5f)
        {
            Next_Position = Random_Point_Get(transform.position, Radius);
            MrBean.SetDestination(Next_Position);
        }
    }

}
