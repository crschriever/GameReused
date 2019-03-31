using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyIAPManager))]
public class LookAtPointEditor : Editor
{

    void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MyIAPManager myScript = (MyIAPManager)target;
        if (GUILayout.Button("Add Money"))
        {
            MyIAPManager.instance.AddCurrency(500);
        }

        if (GUILayout.Button("Clear Money"))
        {
            MyIAPManager.instance.ClearCurrency();
        }

        if (GUILayout.Button("Clear Purchases"))
        {
            MyIAPManager.instance.ClearPurchases();
        }
    }
}