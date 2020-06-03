﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Logica;
using Capa_Diseño;
using Capa_Diseño.Consultas;

namespace Capa_Diseño.Mantenimiento
{
    public partial class Frm_Producto : Form
    {

        Logica logic = new Logica();
        string scampo;

        public Frm_Producto()
        {
            InitializeComponent();
            scampo = logic.siguiente("productos", "codigo_producto");
            Txt_IdP.Text = scampo;
            Cbo_estado.Items.Add("Activo");
            Cbo_estado.Items.Add("Inactivo");
            bloquearTXT();
        }

        void bloquearTXT()
        {
            TextBox[] txtBox = { Txt_IdP, Txt_nombre, Txt_Direccion, Txt_Nit, Txt_Telefono }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = false;
            }
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = false;
            }
        }
        //Metodo para validar los txt que no esten vacios
        private int validarTXT(TextBox[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (string.IsNullOrEmpty(list[i].Text))
                {
                    MessageBox.Show("Debe completar la informacion en el campo " + list[i].Name);
                    return 0;
                }
            }
            return 1;
        }

        void limpiarTXT(TextBox[] txtBox, ComboBox[] comboBo)
        {
            //Aqui se limpian los txt
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Text = "";
            }
            //Aqui colocamos el siguiente codigo de la tabla y su llave primaria 
            scampo = logic.siguiente("maestroactivos", "COD");
            Txt_IdP.Text = scampo;
            if (Cbo_estado.Text != "")
            {
                Cbo_estado.Text = "Activo";
            }
            else
            {
                Cbo_estado.Text = "Inactivo";
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            TextBox[] txtBox = { Txt_IdP, Txt_nombre, Txt_Direccion, Txt_Nit, Txt_Telefono }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < txtBox.Length; i++)
            {
                txtBox[i].Enabled = true;
            }
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            for (int i = 0; i < comboBox.Length; i++)
            {
                comboBox[i].Enabled = true;
            }
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            //Primero debemos de validar si los txt vienen vacios
            TextBox[] txtBox = { Txt_IdP, Txt_nombre, Txt_Direccion, Txt_Nit, Txt_Telefono }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                //Aqui se declara la tabla donde se ira a modificar y en el segundoa arreglo, se debe de colocar los nombre de los campos.
                string[] valores = { "proveedores", Txt_IdP.Text, Txt_nombre.Text, Txt_Direccion.Text, Txt_Nit.Text, Txt_Telefono.Text };
                string[] campos = { "proveedores", "codigo_proveedor", "nombre_proveedor", "direccion_proveedor", "telefono_proveedor", "nit_proveedor", "estado_proveedor" };
                if (logic.Modificar(valores, campos) == null)
                    MessageBox.Show("Ocurrio un error al modificar los datos.");
                else
                {
                    MessageBox.Show("Datos modificados exitosamente.");
                    limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                    bloquearTXT();
                }
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //Primero debemos de validar si los txt vienen vacios
            TextBox[] txtBox = { Txt_IdP, Txt_nombre, Txt_Direccion, Txt_Nit, Txt_Telefono }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            if (validarTXT(txtBox) == 0)
                return;
            else
            {
                if (Cbo_estado.Text == "Activo")
                {
                    Cbo_estado.Text = "1";
                }
                else
                {
                    Cbo_estado.Text = "0";
                }
                //Aqui se declara la tabla donde se ira a insertar y los txt que se guardaran en el orden de la tabla
                string[] valores = { "proveedores", Txt_IdP.Text, Txt_nombre.Text, Txt_Direccion.Text, Txt_Nit.Text, Txt_Telefono.Text };
                if (logic.Insertar(valores) == null)
                    MessageBox.Show("Ocurrio un error al guardar los datos.");
                else
                {
                    MessageBox.Show("Datos guardados exitosamente.");
                    limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                    bloquearTXT();
                }
            }
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            //COMBO QUE USARAN 
            ComboBox[] comboBox = { Cbo_estado }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //ComboBox[] comboBox = {comboBox1, comboBox2, etc}   Aqui podemos declarar los combo 
            TextBox[] txtBox = { Txt_IdP, Txt_nombre, Txt_Direccion, Txt_Nit, Txt_Telefono }; //COLOCAR TODOS LOS TEXTBOX QUE SE UTILZIARAN
            //Aqui se declara la tabla que se ira a eliminar, el codigo por medio del txt y el nombre de la llave primaria.
            string[] valores = { "maestroactivos", Txt_IdP.Text, "pkidmaestroactivos" };
            if (logic.Eliminar(valores) == null)
                MessageBox.Show("Ocurrio un error al borrar los datos.");
            else
            {
                MessageBox.Show("Datos eliminados exitosamente.");
                limpiarTXT(txtBox, comboBox); //Si usamos combo, debemos de enviarselo aqui a la funcion y declarar a la funcion que recibe
                bloquearTXT();
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaProveedor concep = new Frm_ConsultaProveedor();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {

                Txt_IdP.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                Txt_Direccion.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[2].Value.ToString();
                Txt_Nit.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[3].Value.ToString();
                Txt_Telefono.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                     Cells[4].Value.ToString();
                Cbo_estado.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                    Cells[5].Value.ToString();

            }
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaLinea concep = new Frm_ConsultaLinea();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                Txt_Direccion.Text = concep.Dgv_consultaBodega.Rows[concep.Dgv_consultaBodega.CurrentRow.Index].
                      Cells[0].Value.ToString();
            }

            Txt_Direccion.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaMarca concep = new Frm_ConsultaMarca();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                Txt_Nit.Text = concep.Dgv_consultaBodega.Rows[concep.Dgv_consultaBodega.CurrentRow.Index].
                      Cells[0].Value.ToString();
            }

            Txt_Nit.Enabled = false;
        }
    }
}
