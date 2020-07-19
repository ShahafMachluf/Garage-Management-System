using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagement.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            SystemStartingForm startUp = new SystemStartingForm();
            do
            {
                startUp.ShowDialog();
            }
            while (startUp.DialogResult == DialogResult.Abort);
            if (startUp.DialogResult == DialogResult.OK)
            {
                MainForm form = new MainForm(startUp.EnvironmentSelection == "MongoDB", startUp.Collection);
                form.ShowDialog();
            }
        }
    }
}