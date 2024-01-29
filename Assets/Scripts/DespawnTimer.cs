using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    [SerializeField] float despawnTime = 2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
