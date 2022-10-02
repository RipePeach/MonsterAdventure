using UnityEngine;
[System.Serializable]
public class Dialogue
{
 // имя персонажа или название диалога
 public string name;
 // Предложения в диалоге в юнити
 [TextArea(3, 10)]
 public string[] sentences; //массив всех предложений
}
