[System.Serializable]
public struct DataPoint
{
    public System.DateTime date;
    public float value;

    public DataPoint(System.DateTime d, float v)
    {
        date = d;
        value = v;
    }
}