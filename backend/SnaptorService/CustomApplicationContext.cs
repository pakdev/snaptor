using SnaptorService.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnaptorService
{
    public sealed class CustomApplicationContext : ApplicationContext
    {
        private IContainer _components;
        private NotifyIcon _notifyIcon;

        public CustomApplicationContext()
        {
            this.InitializeContext();

            var hook = new KeyboardHook();
            hook.KeyPressed += (sender, e) =>
                {
                    MessageBox.Show("pressed");
                };

            hook.RegisterHotKey(ModifierKeys.None, Keys.PrintScreen);
        }

        private void InitializeContext()
        {
            _components = new Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Resources.Raptor,
                Text = "Change me",
                Visible = true
            };
        }
    }
}
