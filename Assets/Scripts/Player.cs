using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{   
    public LayerMask whatCanbeClickedOn;
    private NavMeshAgent agent;
    public Animator anim;
    public bool Is_walk;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanbeClickedOn))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Is_walk = false;
        }
        else
        {
            Is_walk = true;
        }
        anim.SetBool("Is_walk", Is_walk);
    }
}
