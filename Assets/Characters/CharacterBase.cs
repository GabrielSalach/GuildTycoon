using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterBase : MonoBehaviour {
    //Components
    protected Interactable interactable;
    private NavMeshAgent navMeshAgent;
    
    
    [Header("Character Base Attributes")]
    [SerializeField] private string characterName;
    public string CharacterName => characterName;
    // Combat Stats
    protected CombatStats baseCombatStats;
    protected CombatStats currentCombatStats;
    protected Equipment[] equipment = new Equipment[8];

    protected CharacterClass characterClass;
    
    // Pathfinding
    [SerializeField] private float interactionRange;
    [HideInInspector] public UnityEvent onArrivalAtDestination;
    private bool hasArrived;

    protected virtual void Awake() {
        interactable = GetComponent<Interactable>();
        baseCombatStats = characterClass.baseStats.CloneStats();
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

    private void EquipItem(Equipment item, int slot) {
        equipment[slot] = item;
        baseCombatStats += item.bonusStats;
    }
}
