using UnityEngine;

public class RandomAnimationSelector : MonoBehaviour
{
    private Animator animator;
    private float interval = 5f;
    private float timer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError($"[{nameof(RandomAnimationSelector)}] Nessun Animator trovato sul GameObject ({name})!");
            enabled = false;
            return;
        }
        timer = interval; // forza cambio immediato nel primo Update
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            int randomValue = Random.Range(0, 3); // genera 0,1,2,3
            animator.SetInteger("randomAnimation", randomValue);
            Debug.Log($"[{Time.time:F2}s] randomAnimation = {randomValue}");
        }
    }
}
