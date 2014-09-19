using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacStrategyPattern
{
    public interface IUser
    {
        int UserId { get; set; }
        void Do();
    }
}
