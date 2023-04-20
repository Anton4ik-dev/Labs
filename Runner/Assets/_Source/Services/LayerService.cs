using UnityEngine;

namespace Service
{
    public class LayerService : ILayerService
    {
        public bool CheckLayersEquality(LayerMask objectLayer, LayerMask requiredLayer) => ((1 << objectLayer) & requiredLayer) > 0;
    }
}