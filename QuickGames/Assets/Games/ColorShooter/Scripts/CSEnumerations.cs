using UnityEngine;

public class CSEnumerations : MonoBehaviour
{
    public enum PrimaryType { Red, Blue, Yellow, Invalid };
    public enum SecondaryType { Orange, Green, Purple };

    // Given SecondaryEnemy and Bullet types
    // func returns (other PrimaryEnemy type) || (PrimaryType.Invalid if incorrect bullet has hit)
    public static PrimaryType OtherColor(PrimaryType primary, SecondaryType secondary)
    {
        switch (secondary)
        {
            case SecondaryType.Orange:
                if (primary == PrimaryType.Red)
                    return PrimaryType.Yellow;
                else if (primary == PrimaryType.Yellow)
                    return PrimaryType.Red;
                else
                    return PrimaryType.Invalid;

            case SecondaryType.Purple:
                if (primary == PrimaryType.Red)
                    return PrimaryType.Blue;
                else if (primary == PrimaryType.Blue)
                    return PrimaryType.Red;
                else
                    return PrimaryType.Invalid;

            case SecondaryType.Green:
                if (primary == PrimaryType.Blue)
                    return PrimaryType.Yellow;
                else if (primary == PrimaryType.Yellow)
                    return PrimaryType.Blue;
                else
                    return PrimaryType.Invalid;

            default:
                return PrimaryType.Invalid;
        }
    }
}
