using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingProblems : MonoBehaviour
{
    void Start()
    {
        int[] nums = {8,1,2,2,3};
        printArray(SmallerNumbers(nums));
    }

    public int[] SmallerNumbers(int[] nums){
        int[] numsCnt = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if(nums[j]<nums[i])
                    numsCnt[i]++;
            }
        }
        return numsCnt;
    }

    public void printArray(int[] nums){
        foreach (int i in nums) 
        {
            Debug.Log(i);
        }
    }
}
