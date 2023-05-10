using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterfliesKiller : MonoBehaviour
{
    private List<BreadButterfly> _aliveButterflies;
    [SerializeField] private float _killButterfliesDistance = 5.0f;
    
    void Start()
    {
        // Collecting killable butterflies to be killed
        _aliveButterflies = new List<BreadButterfly>();
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Killable");
        foreach (var butterflyObj in tmp)
        {
            _aliveButterflies.Add(butterflyObj.GetComponent<BreadButterfly>());
        }
    }
    
    void Update()
    {
        if (_aliveButterflies.Count == 0) return;
        for (int i = _aliveButterflies.Count - 1; i >= 0; i--)
        {
            BreadButterfly butterfly = _aliveButterflies[i];
            float distanceToKiller = Vector3.Distance(transform.position, butterfly.BonePosition);
            if (distanceToKiller < _killButterfliesDistance)
            {
                butterfly.Kill();
                _aliveButterflies.RemoveAt(i);
            }
        }
    }
}
