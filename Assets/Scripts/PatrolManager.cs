using UnityEngine;

public static class PatrolManager
{
    private static int currentPatrolPoint = 0;

    public static void PatrolLogic(Transform targetTransform, Transform[] patrolPoints, float walkSpeed)
    {
        Vector3 moveToPoint = patrolPoints[currentPatrolPoint].position;
        targetTransform.position = Vector3.MoveTowards(targetTransform.position, moveToPoint, walkSpeed * Time.deltaTime);

        if (Vector3.Distance(targetTransform.position, moveToPoint) < 0.01f)
        {
            currentPatrolPoint++;
            if (currentPatrolPoint > patrolPoints.Length - 1)
            {
                currentPatrolPoint = 0;
            }
        }
    }

}