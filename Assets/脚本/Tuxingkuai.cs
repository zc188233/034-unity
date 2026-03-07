using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuxingkuai : MonoBehaviour
{
    // 储存6个数字的数组
    [SerializeField] private int[] numbers = { 1,2,1,1,2,1};
    
    // 公共方法：通过索引获取单个数字
    public int GetNumber(int index)
    {
        if (index >= 0 && index < numbers.Length)
            return numbers[index];
        return 0;
    }
    
    // 公共方法：获取整个数组
    public int[] GetAllNumbers()
    {
        return numbers;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
