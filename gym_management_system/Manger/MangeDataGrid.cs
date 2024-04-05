using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Manger
{
    public class MangeDataGrid
    {
        public DataGridView GridRefresh<T>(DataGridView dgv, List<T> data)
        {
            if (data != null)
            {
                if (dgv.InvokeRequired)
                {
                    // If called from a different thread, invoke the method on the UI thread
                    dgv.Invoke(new Action(() =>
                    {
                        dgv.DataSource = data;
                        dgv.ClearSelection();
                    }));
                }
                else
                {
                    // If already on the UI thread, execute directly
                    dgv.DataSource = data;
                    dgv.ClearSelection();
                }
            }

            return dgv;
        }
    }
}
