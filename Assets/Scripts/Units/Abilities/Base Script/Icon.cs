[System.Serializable]
public struct Icon
{
    public IconType iconType;
    public int buffAmount;

    public Icon(IconType t, int a)
    {
        iconType = t;
        buffAmount = a;
    }
}
