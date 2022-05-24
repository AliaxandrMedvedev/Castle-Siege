using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : TowerBuilder
{

    [SerializeField] private int _minTowerSize;
    [SerializeField] private int _maxTowerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;

    private List<Block> _blocks;

    public UnityAction<int> SizeUpdated;

    private void Start()
    {
        int _towerSize = Random.Range(_minTowerSize, _maxTowerSize);  // ������ �����
        _blocks = Build(_towerSize, _buildPoint, _block, _colors);

        foreach (var block in _blocks)      // �������� �� ������� ���� ������
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;  // ������� �� ������� �����

        _blocks.Remove(hitedBlock);            // �������� �� ������

        foreach (var block in _blocks)          // �������� ���� ������ ���� �� 1
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y * 2, block.transform.position.z);
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }
}
