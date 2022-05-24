using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    private List<Block> _blocks;

    public List<Block> Build(int towerSize, Transform buildPoint, Block block, Color[] colors)
    {
        _blocks = new List<Block>();
        Transform currentPoint = buildPoint;
        for (int i = 0; i < towerSize; i++)
        {
            Block newBlock = Instantiate(block,
                                         new Vector3(buildPoint.position.x,
                                                     currentPoint.position.y + block.transform.localScale.y * 2,
                                                     buildPoint.position.z),
                                         Quaternion.identity,
                                         buildPoint);

            _blocks.Add(newBlock);
            newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

}
