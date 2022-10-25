using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("SpawnInfo")]
    public Monster MonsterObj;
    public Transform[] SpawnPoint;

    public List<Monster> monsters = new List<Monster>();
    public int wave=0;

    private void Update()
    {
        //플레이어가 죽은경우 isGameOver스폰하지않고 Update를 탈출함
        if (GameManager.Instace != null&& GameManager.Instace.isGameOver)
        {
            return;
        }

        if (monsters.Count <= 0)
        {
            SpawnWave();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIManager.Instance
    }

    private void SpawnWave()
    {
        //웨이브에 맞춰 적생성할 예정
        wave++;

        int spawnCount = Mathf.RoundToInt(wave * 1.5f);

        for(int i=0; i<spawnCount; i++)
        {
            CreateMonster();    
        }
;    }
    public void CreateMonster()
    {

        Transform _spawnPoint = SpawnPoint[UnityEngine.Random.Range(0, SpawnPoint.Length)];

        Monster _monster = Instantiate(MonsterObj, _spawnPoint.position, _spawnPoint.rotation);

        _monster.Setup(100f, 10f, 3f);

        monsters.Add(_monster);

        _monster.OnDeath += () => monsters.Remove(_monster); //몬스터가 죽으면 리스트에서 지움
        _monster.OnDeath += () => Destroy(_monster.gameObject, 5f); //몬스터가 죽으면 10초뒤에 죽음
        _monster.OnDeath += () => GameManager.Instace.AddScore(100);

    }
}
