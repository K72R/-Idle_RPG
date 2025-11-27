using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "RPG/Upgrade Config")]
public class UpgradeConfig : ScriptableObject
{
    [System.Serializable]
    public class EnhanceRule
    {
        public ItemData baseItem;
        public ItemData enhancedItem;
        [Range(0f, 1f)]public float successRate;
        public int requiredEnhanceScrollCount;
    }

    [System.Serializable]
    public class FusionRule
    {
        public ItemGradde fromGrade;
        public ItemGradde toGrade;
        [Range(0f, 1f)] public float successRate;
        public int requiredFusionScrollCount;
    }

    public EnhanceRule[] enhanceRules;
    public FusionRule[] fusionRules;
}
