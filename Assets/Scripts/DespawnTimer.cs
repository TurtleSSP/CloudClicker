using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Despawn());
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
