using System.Collections.Generic;
using UnityEngine;

public class ListinsertionSort : MonoBehaviour
{
    List<int> numberList = new List<int> {7, 1, 9, 6, 0};


void Start()
{
    Debug.Log("Original List: " + ListToString(numberList));
    
    InListinsertionSort(numberList);
    
    Debug.Log("Sorted List: " + ListToString(numberList));
}

string ListToString(List<int> list)
{
    return string.Join(", ", list);
}

void InListinsertionSort(List<int> list)
{
    int n = list.Count;
    for (int i = 1; i < n; i++)
    {
        int key = list[i];
        int j = i - 1;

        while (j >= 0 && list [j] > key)
        {
            list [j + 1] = list[j];
            j = j - 1;
        }
        list [j + 1] = key;
    }
}
}