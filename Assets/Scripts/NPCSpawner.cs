using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;     // Assign your NPC prefab in the Inspector
    public Transform target;         // Assign the target (e.g., player) in the Inspector
    public KeyCode spawnKey = KeyCode.S; // The key to press for spawning an NPC

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnNPC();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("exited the game");
        }
    }

    void SpawnNPC()
    {
        if (npcPrefab != null && target != null)
        {
            GameObject newNPC = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            NPCMovement npcMovement = newNPC.GetComponent<NPCMovement>();
            if (npcMovement != null)
            {
                npcMovement.player = target;
            }
        }
        else
        {
            Debug.LogError("NPC Prefab or Target not assigned.");
        }
    }
}

