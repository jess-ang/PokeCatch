using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numeros = {12, 345, 2, 6, 7896, 9111992, 28};
        Debug.Log("Input: [12, 345, 2, 6, 7896, 9111992, 28]");
        Debug.Log("Output: "+CountEvenNums(numeros));
    }
    public int CountEvenNums(int [] nums)
    {
        int cntEven = 0;
        int cntDigits, num;

        foreach(int i in nums)
        {
            num = i;
            for(cntDigits=1; num>9; cntDigits++)
                num/=10;

            if(cntDigits%2 == 0)
                cntEven++;
        }
        return cntEven;
    }
}
