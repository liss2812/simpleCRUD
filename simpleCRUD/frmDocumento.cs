using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    public partial class frmDocumento : Form
    {
        private string action = "";
        public frmDocumento()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            //deja un tab 
            tabs.TabPages.Remove(tabForm);

            //carga los datos en el datagridView
            //deshabilita controles
            fillDataGridView();
            controlsDisable();

        }

        //utilizado para mostrar los registros en el datagridview
        public void fillDataGridView()
        {
            //instancia de la clase documento| Documento
            Documento documento = new Documento();

            clearDataGridView();

            dtgDocumentos.Columns.Add("documentoid", "DOCUMENTO ID");
            dtgDocumentos.Columns.Add("titulo", "TITULO");
            dtgDocumentos.Columns.Add("contenido", "CONTENIDO");
            dtgDocumentos.Columns.Add("fechapublicacion", "FECHA PUBLICACION");
            dtgDocumentos.Columns.Add("descripcion", "DESCRIPCION");

            //llamado al medoto getBooks() de la clase Book
            MySqlDataReader dataReader = documento.getAllDocumentos();

            //leer el resultado y mostrarlo en el datagridview
            while(dataReader.Read())
            {
                dtgDocumentos.Rows.Add(
                        dataReader.GetValue(0),
                        dataReader.GetValue(1),
                        dataReader.GetValue(2),
                        dataReader.GetValue(3),
                        dataReader.GetValue(4)
                       );
            }
        }

        public void clearDataGridView()
        {
            dtgDocumentos.Columns.Clear();
            dtgDocumentos.Rows.Clear();
        }
        //deshabilitar los controles de formulario
        public void controlsDisable()
        {
            txtDocumentoId.Enabled = false;
            txtTitulo.Enabled = false;
            txtContenido.Enabled = false;
            txtDescripcion.Enabled = false;
            dtFecchaPublicacion.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        //habilitar los controles de formulario
        public void controlsEnable()
        {
            txtDocumentoId.Enabled = false;
            txtTitulo.Enabled = true;
            txtContenido.Enabled = true;
            txtDescripcion.Enabled = true;
            dtFecchaPublicacion.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        //limpiar el contenido de los controles
        public void clearControls()
        {
            txtDocumentoId.Text = "";
            txtTitulo.Text = "";
            txtContenido.Text = "";
            txtDescripcion.Text = "";
            dtFecchaPublicacion.Text = "";
        }

          
       
        private void dtgDocumentos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tabs.TabPages.Remove(tabData);//ocultar el tab de el datagridview
            tabs.TabPages.Add(tabForm); //mostrar el formulario para los datos
            tabs.TabPages[0].Text = "EDIT DOCUMENTO";

            action = "edit";
            controlsEnable();

            txtDocumentoId.Visible = true;
            txtDocumentoId.ReadOnly = true;
            lblId.Visible = true;

            //cargar datos en controles
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //mediante este boton se programara para guardar y editar
        }

      

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //codigo del boton salir
            string mensaje = "¿Está seguró que desea salir?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void lNew_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Add(tabForm);//mostrar el formulario
            tabs.TabPages.Remove(tabData); //ocultar el  tab del dataagridview
            tabs.TabPages[0].Text = "Nuevo Documento"; //agregar texto al tab

            txtDocumentoId.Visible = false;
            lblId.Visible = false;
            txtTitulo.Focus(); //enviar enfoque al titulo
            action = "new";
            controlsEnable();
            clearControls();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguró que desea cancelar?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearControls();
                controlsDisable();


                tabs.TabPages.Remove(tabForm);
                tabs.TabPages.Add(tabData);
                tabs.TabPages[0].Text = "LISTA DOCUMENTOS";
            }
        }

        private void tabForm_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {
        
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {

        }
    }

}
