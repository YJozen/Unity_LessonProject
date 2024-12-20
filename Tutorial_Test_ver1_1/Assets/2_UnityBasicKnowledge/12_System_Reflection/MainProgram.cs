using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProgram :MonoBehaviour
{
    private void Start()
    {
        for (int i = 1; i <= 2; i++) // クラスの数に応じて範囲を設定
        {
            string className = $"Class{i}";
            Type type = Type.GetType(className);
            if (type != null)
            {
                IMyInterface instance = (IMyInterface)Activator.CreateInstance(type);
                if (instance != null)
                {
                    instance.MyFunction();
                }
                
                MethodInfo method = type.GetMethod("MyFunction");
                if (method != null)
                {
                   method.Invoke(instance, null);
                }
                else
                {
                   Debug.Log($"{className} に MyFunction が見つかりませんでした");
                }
            }
            else
            {
                Debug.Log($"{className} は見つかりませんでした");
            }
        }
    }
}
