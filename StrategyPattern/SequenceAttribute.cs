using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SequenceAttribute : Attribute
    {
        #region Constructors
        public SequenceAttribute(int sequence)
        {
            this.Sequence = sequence;
        }
        #endregion
        #region Properties
        public int Sequence { get; set; }
        #endregion
    }
}
