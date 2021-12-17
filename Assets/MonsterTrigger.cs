using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private MonsterController.MonsterState toState;

    private MonsterController monster;
        
    void Start()
    {
        monster = FindObjectOfType<MonsterController>();

        if (!monster)
        {
            Debug.LogWarning("Monster could not be found");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monster.ChangeState(toState);
        }
    }
}
