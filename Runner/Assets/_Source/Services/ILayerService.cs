using Core;
using UnityEngine;

namespace Service
{
    public interface ILayerService : IGameService
    {
        bool CheckLayersEquality(LayerMask objectLayer, LayerMask requiredLayer);
    }
}