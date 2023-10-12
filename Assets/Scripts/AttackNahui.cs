using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform imageTarget1;
    public Transform imageTarget2;
    public float attackDistance = 0.1f;
    public Animator characterAnimator;

    private void Awake()
    {
        if (characterAnimator == null)
        {
            Debug.LogError("No Animator assigned on: " + gameObject.name);
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(imageTarget1.position, imageTarget2.position);

        if (distance < attackDistance)
        {
            characterAnimator.SetTrigger("AttackEnemyCactus");
        }
        else
        {
            characterAnimator.ResetTrigger("StopAttacking");
        }
    }
}