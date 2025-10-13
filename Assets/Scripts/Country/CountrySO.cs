using UnityEngine;

[CreateAssetMenu(fileName = "CountrySO")]
public class CountrySO : ScriptableObject
{
    public int ID;
    public Sprite Img;
    public string Name;
    public long Population;
}
