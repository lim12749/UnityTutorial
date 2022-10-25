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
        //�÷��̾ ������� isGameOver���������ʰ� Update�� Ż����
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
        //���̺꿡 ���� �������� ����
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

        _monster.OnDeath += () => monsters.Remove(_monster); //���Ͱ� ������ ����Ʈ���� ����
        _monster.OnDeath += () => Destroy(_monster.gameObject, 5f); //���Ͱ� ������ 10�ʵڿ� ����
        _monster.OnDeath += () => GameManager.Instace.AddScore(100);

    }
}
