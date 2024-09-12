using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject m_enemy;
    [SerializeField] Transform m_enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeToSpawn(5));
    }
    IEnumerator timeToSpawn(int p_timeToSpawn)
    {
        yield return new WaitForSeconds(p_timeToSpawn);
        Instantiate(m_enemy, m_enemySpawn.transform.position, Quaternion.identity);
    }
}
