namespace StrategyPatternTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Autofac;
    using Autofac.Core;
    using StrategyPattern;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AutofacStrategyPattern;
    using FluentAssertions;

    [TestClass]
    public class StrategyHelper
    {
        #region Properties
        //Dependency to inject
        private List<Parameter> ListParameters = new List<Parameter>() { new NamedPropertyParameter("UserId", 1) };

        //Register all the class inherited from "UserBase" class
        private StrategyHelper<UserBase, IUser> StrategyHelperInstance = new StrategyHelper<UserBase, IUser>();

        #endregion

        #region Test Methods
        [TestMethod]
        public void Init_should_add_class_to_AllClasses()
        {
            // Arrange
            Assembly assembly = typeof(IUser).Assembly;

            // Act
            this.StrategyHelperInstance.Init(assembly, ListParameters);

            // Assert
            this.StrategyHelperInstance.AllClasses.Count.Should().BeGreaterThan(0);
        }
        #endregion
    }
}
