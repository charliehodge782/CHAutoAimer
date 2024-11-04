using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public List <GameObject> enemiesInRange;
    public GameObject projectilePrefab;
    public Transform firingPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TargetAndShootLowestHealthEnemy();
        }
    }

    void TargetAndShootLowestHealthEnemy()
    {
        if (enemiesInRange.Count == 0) return;

        enemiesInRange = enemiesInRange.OrderBy(enemy => enemy.GetComponent<Health>().currentHealth).ToList();

        GameObject targetEnemy = enemiesInRange[0];

        if (targetEnemy.GetComponent<Health>().currentHealth > 0)
        {
            ShootAtTarget(targetEnemy);
        }
        else
        {
            enemiesInRange.Remove(targetEnemy);
        }
    }

    void ShootAtTarget(GameObject target)
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity);
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();

        if(projectileScript != null)
        {
            projectileScript.SetTarget(target.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy") && enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}