using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemaPracDos : MonoBehaviour
{
    void Start()
    {
        string[] namesList = {"Areli","Dalet","Daniel","Eduardo","Enola","Gilberto",
                            "Guillermo","Jaime","Jessica","Joaquín","Leonardo","Luis",
                            "Omar","Pablo","Paul","Ricardo","Sergio","Victor"};
        string[] searchNames = {"Enola","David","Melissa","Areli",
                                "Jessica","Daniel","Guillermo","Humberto"};

        foreach (string name in searchNames)
        {
        if(SearchName(namesList,name))
            Debug.Log("El/la alumno/a "+name+" está inscrito/a en el grupo");
        else
            Debug.Log("El/la alumno/a "+name+" no se encuentra en el grupo");
        }
    }

    public bool SearchName(string[] namesList, string name){
        string nameLower = name.ToLower();
        int topIndex = 0, bottomIndex = namesList.Length-1, halfIndex=bottomIndex/2;
        int i = namesList.Length;
        do{
            if (nameLower.CompareTo(namesList[halfIndex].ToLower())==0){
                return true;
            }
            else if (nameLower.CompareTo(namesList[halfIndex].ToLower())>0){
                topIndex =  halfIndex+1; 
            }
            else {
                bottomIndex = halfIndex-1; 
            }
            halfIndex = topIndex + (bottomIndex - topIndex)/2;
        }while((--i)!=0);
        return false;
    }

    public void printList(string[] namesList){
        foreach (string i in namesList) 
        {
            Debug.Log(i);
        }
    }
}
