using Capa_Diseño.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Diseño.Mantenimiento;

namespace Capa_Diseño
{
    public partial class Menu : Form
    {
        private int childFormNumber = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        bool ventanalinea = false;
        Frm_Linea linea = new Frm_Linea();

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Linea);
            if (ventanalinea == false || frmC == null)
            {
                if (frmC == null)
                {
                    linea= new Frm_Linea();
                }

                linea.MdiParent = this;
                linea.Show();
                Application.DoEvents();
                ventanalinea = true;
            }
            else
            {
                linea.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanamarca = false;
        Frm_Marca marca = new Frm_Marca();

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Marca);
            if (ventanamarca == false || frmC == null)
            {
                if (frmC == null)
                {
                    marca = new Frm_Marca();
                }

                marca.MdiParent = this;
                marca.Show();
                Application.DoEvents();
                ventanamarca = true;
            }
            else
            {
                marca.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaprov = false;
        Frm_Proveedores proveedor = new Frm_Proveedores();
        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Proveedores);
            if (ventanaprov == false || frmC == null)
            {
                if (frmC == null)
                {
                    proveedor = new Frm_Proveedores();
                }

                proveedor.MdiParent = this;
                proveedor.Show();
                Application.DoEvents();
                ventanaprov = true;
            }
            else
            {
                proveedor.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanabod = false;
        Frm_Bodegas bodega = new Frm_Bodegas();

        private void bodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Bodegas);
            if (ventanabod == false || frmC == null)
            {
                if (frmC == null)
                {
                    bodega = new Frm_Bodegas();
                }

                bodega.MdiParent = this;
                bodega.Show();
                Application.DoEvents();
                ventanabod = true;
            }
            else
            {
                bodega.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
