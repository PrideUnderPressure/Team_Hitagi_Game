using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;
    public Rigidbody2D rb;

    public float rbX;
    public float rbY;
    
    public SpriteRenderer sR;
    public NavMeshAgent agents;
    public float agentsX;
    public float agentsY;

    public Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = gameObject.GetComponent<Animator>();
        
        agents = gameObject.GetComponent<NavMeshAgent>();
        sR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        agentsX = agents.velocity.x;
        agentsY = agents.velocity.y;
        Flips();
        agent.SetDestination(target.position);
        
        
    }

    void FixedUpdate()
    {
        if (agentsX != 0 || agentsY != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        if (agentsX == 0 && agentsY == 0)
        {
            animator.SetBool("IsRunning", false);
        }
    }
     public void Flips()
    {
        if (agentsX < 0)
        {
            sR.flipX = false;
            sR.flipX = false;
        }
        if (agentsX > 0)
        {
            sR.flipX = true;
            sR.flipX = true;
        }
    }
}
