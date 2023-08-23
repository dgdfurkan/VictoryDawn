using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunduzDev
{
    public interface IPoolable
    {
        void OnGetFromPool();
        void OnReturnToPool();
    }
}