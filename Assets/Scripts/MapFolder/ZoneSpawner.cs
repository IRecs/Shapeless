using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private SeparateZone _separateZone;
    private void Start()
    {
        float step = _separateZone.transform.localScale.x;
        
        for( int x = 0; x < _count; x++ )
        {
            for( int z = 0; z < _count; z++ )
            {
                SeparateZone obj = Instantiate(_separateZone, new Vector3(x *step, 0, z * step), Quaternion.identity);
                obj.Position = new Vector2Int(x, z);
            }
        }
    }
}
