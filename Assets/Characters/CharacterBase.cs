using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterBase : MonoBehaviour {
    //Components
    protected Interactable interactable;
    private NavMeshAgent navMeshAgent;
    
    
    [SerializeField] private string characterName;
    public string CharacterName => characterName;
    // Combat Stats
    [SerializeField] private CombatStats baseCombatStats;
    private CombatStats currentCombatStats;
    
    // Pathfinding
    [SerializeField] private float interactionRange;
    [HideInInspector] public UnityEvent onArrivalAtDestination;
    private bool hasArrived;

    
    protected virtual void Awake() {
        interactable = GetComponent<Interactable>();
        currentCombatStats = baseCombatStats.CloneStats();
        

        navMeshAgent = GetComponent<NavMeshAgent>();
        hasArrived = true;
    }

    /// <summary>
    /// Queues a new destination for the character to go to 
    /// </summary>
    /// <param name="destination">Position the character has to reach</param>
    protected void GoToDestination(Vector3 destination) {
        
        hasArrived = false;
        navMeshAgent.SetDestination(destination);
    }

    /// <summary>
    /// Checks if the character arrived to its destination but LOL ITS WANKY ATM MATE 
    /// </summary>
    private void CheckArrival() {
        if (interactionRange < navMeshAgent.remainingDistance || hasArrived) 
            return;
        navMeshAgent.ResetPath();
        onArrivalAtDestination.Invoke();
        hasArrived = true;
    }

    private void Update() {
        CheckArrival();
    }

    /// <summary>
    /// Displays the stop radius of the character
    /// </summary>
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
