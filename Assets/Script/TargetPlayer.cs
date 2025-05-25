using UnityEngine;
using UnityEngine.AI;

public class TargetPlayer : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float killDist = 1f;
    
    [SerializeField] Transform player;
    [SerializeField] GameObject gameOverUI;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        agent.SetDestination(player.position);

        float distToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distToPlayer < killDist)
        {
            Debug.Log("Player killed!");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
