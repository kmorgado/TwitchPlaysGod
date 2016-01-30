using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utility;

namespace Unitilities.Tuples
{
        /// <summary>
        /// Tuple class of 2 int
        /// </summary>
        /// <typeparam name="First">First int</typeparam>
        /// <typeparam name="Second">Second int</typeparam>
        [System.Serializable]
        public class SkillTuple : Tuple<int, int>
        {
            public static SkillTuple _default
            {
                get { return new SkillTuple(0, 0); }
            }

            public SkillTuple(int a, int b)
                : base(a, b)
            {
            }
        }
}
