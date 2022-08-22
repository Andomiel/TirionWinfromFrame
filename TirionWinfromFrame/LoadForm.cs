using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TirionWinfromFrame
{
    public partial class LoadForm : SplashScreen
    {
        public LoadForm()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if (command == SplashScreenCommand.SetProgress)
            {
                int pos = (int)arg;
                progressBarControl1.Position = pos;
            }
            if (command == SplashScreenCommand.Command2)
            {
                labelStatus.Text = (string)arg;
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
            SetProgress,
            Command2,
            Command3
        }
    }
}