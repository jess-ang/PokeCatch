using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numeros = {2,10,3,14,6,11,15}, array;
        int target=8;
        array = SumaDos(numeros,target);
        Debug.Log("Input: "+target);
        Debug.Log("Output: ["+array[0]+","+array[1]+"]");
        Debug.Log("Values: "+numeros[array[0]]+"+"+numeros[array[1]]);
    }
    public int[] SumaDos(int[] nums, int target)
    {
        int[] answer = new int[2];
        int addend;
        
        //Obtener el segundo sumando a buscar en la lista
        for (int i = 0; i < nums.Length; i++)
        {
            addend=target-nums[i];            
            for (int j = i+1; j < nums.Length; j++)
            {
                if(addend==nums[j]){
                    answer[0]=i;
                    answer[1]=j;
                    i=nums.Length;
                    break;
                }
            }
        }
        return answer;
    }
    
    public void printArray(int[] nums){
        foreach (int i in nums) 
        {
            Debug.Log(i);
        }
    }
}
