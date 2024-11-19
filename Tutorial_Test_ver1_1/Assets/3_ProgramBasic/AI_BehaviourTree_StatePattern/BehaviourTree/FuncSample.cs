using UnityEngine;
using System;

public class FuncSample : MonoBehaviour
{
    void Start()
    {
        // 引数がなく、戻り値がint型のFunc
        Func<int> getRandomNumber = () => new System.Random().Next(1, 100);
        int number = getRandomNumber();
        

        // 引数が1つ(string)で、戻り値がbool型のFunc
        Func<string, bool> isValidEmail = (email) => email.Contains("@");
        bool isValid = isValidEmail("example@example.com"); // true

        // 引数が2つ(int, int)で、戻り値がint型のFunc
        Func<int, int, int> add = (a, b) => a + b;
        int sum = add(2, 3); // 5

        //戻り値がない場合は Action デリゲートを使います。
        Action<string> printMessage = (message) => Debug.Log(message);
        printMessage("Hello, World!");
    }


}