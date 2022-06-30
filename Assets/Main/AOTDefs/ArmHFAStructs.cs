using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AOTDefs
{
    public struct NotHFA
    {
        public float x;
        public float y;
        public int z;
    }

    public struct EmbedHFA
    {
        public static float z;
        public Vector2 x;
        public float y;
    }

    public struct EmbedHFA2
    {
        public Vector2 x;
        public Vector2 y;
    }
}
