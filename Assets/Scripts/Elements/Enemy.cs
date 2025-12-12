using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool _iswalking=false;
    public float enemySpeed = 6f;
    private Player _player;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    public Transform zPrefab;
    public Transform newZ;


    public void StartEnemy(Player player)
      {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, Random.Range(-180,180), 0);
        CreatAndAnimateZ();
      }
    public void DeleteTextZ()
    {
        newZ.DOKill();
        Destroy(newZ.gameObject);
    }
    private void CreatAndAnimateZ()
    {
        newZ=Instantiate(zPrefab,transform);
        newZ.position= transform.position + Vector3.up*2;
        newZ.rotation = Quaternion.Euler(0, 0, 0);
        newZ.localScale = Vector3.zero;
        newZ.DOMoveY(newZ.transform.position.y + 0.6f,1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
        newZ.DOScale(Vector3.one, 1f).SetLoops(-1, LoopType.Restart);

    }

    private void Update()
    {
        if (_player.isAppleCollected)
        { 
           
            navMeshAgent.destination=_player.transform.position;
            if (!_iswalking)
            {
                _iswalking = true;
                _animator.SetTrigger("Enemy Walk");
                DeleteTextZ();
            }
        }

        
    }
    

    public void Stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Enemy Idle");
        

    }
}
