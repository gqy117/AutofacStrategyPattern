using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using Factory;

namespace AutofacStrategyPattern
{
    public partial class Form1 : Form
    {
        #region Properties
        //Dependency to inject
        private List<Parameter> ListParameters = new List<Parameter>() { new NamedPropertyParameter("UserId", 1) };
        //Register all the class inherited from "UserBase" class
        public StrategyHelper<UserBase, IUser> StrategyHelper = new StrategyHelper<UserBase, IUser>();
        #endregion
        #region Constructors
        public Form1()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        private void Form1_Load(object sender, EventArgs e)
        {
            //Init Factory
            this.StrategyHelper.Init(Assembly.GetExecutingAssembly(), ListParameters);
            //Execute some method
            this.StrategyHelper.DicClass["User1"].Do();
            this.StrategyHelper.DicClass["User2"].Do();
        }
        #endregion
    }

}
