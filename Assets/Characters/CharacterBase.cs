using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterBase : MonoBehaviour {
    //Components
    protected Interactable interactable;
    private Rigidbody rigidBody;
    private NavMeshAgent navMeshAgent;
    
    
    [SerializeField] private string characterName;
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
        
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        navMeshAgent = GetComponent<NavMeshAgent>();
        hasArrived = true;
    }

    public void GoToDestination(Transform destination) {
        hasArrived = false;
        navMeshAgent.SetDestination(destination.position);
    }

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

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
