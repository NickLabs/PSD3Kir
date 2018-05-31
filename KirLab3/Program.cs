using System;
using KirLab3.Presenters;
using KirLab3.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KirLab3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Presenter presenter = new Presenter(new Form1(), new Model());
            try
            {
                presenter.Run();
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}
