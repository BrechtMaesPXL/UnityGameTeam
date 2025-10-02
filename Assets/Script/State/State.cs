using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public interface State
{


    void OnEnter(GameManager gameManager);
    void OnUpdate(GameManager gameManager);

    void OnExit(GameManager gameManager);
}
