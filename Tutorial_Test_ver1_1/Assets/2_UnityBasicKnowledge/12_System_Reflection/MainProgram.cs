using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProgram :MonoBehaviour
{
    private void Start()
    {
        for (int i = 1; i <= 2; i++) // ƒNƒ‰ƒX‚Ì”‚É‰ž‚¶‚Ä”ÍˆÍ‚ðÝ’è
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
                   Debug.Log($"{className} ‚É MyFunction ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
                }
            }
            else
            {
                Debug.Log($"{className} ‚ÍŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
            }
        }
    }
}
