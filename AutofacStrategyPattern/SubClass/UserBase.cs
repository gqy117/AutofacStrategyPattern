﻿namespace AutofacStrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class UserBase : IUser
    {
        public int UserId { get; set; }

        public void DoSomething()
        {
        }
    }
}
