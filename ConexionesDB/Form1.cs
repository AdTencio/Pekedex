using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace ConexionesDB
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listapokemon;

        public Form1()
        {
            InitializeComponent();
        }


        private void dgvPokemones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
            cBoxCampo.Items.Add("Numero");
            cBoxCampo.Items.Add("Nombre");
            cBoxCampo.Items.Add("Descripción");
        }

        private void Cargar()
        {
            PokemonNegocios negocio = new PokemonNegocios();
            try
            {

                listapokemon = negocio.listar();
                dgvPokemones.DataSource = listapokemon;
                ocultarColumnas();
                cargarImagen(listapokemon[0].URLImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void ocultarColumnas() 
        {
            dgvPokemones.Columns["URLImagen"].Visible = false;
            dgvPokemones.Columns["Id"].Visible = false;
        }
        private void dgvPokemones_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPokemones.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;

                cargarImagen(seleccionado.URLImagen);
            }
            
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                picboxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                picboxPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            Cargar();

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            Cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }
        private void eliminar(bool logico = false)
        {
            PokemonNegocios negocio = new PokemonNegocios();
            Pokemon seleccionado;
            try
            {

                DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);
                    
                    Cargar();
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro() 
        {
            if (cBoxCampo.SelectedIndex == -1) //Si no hay nada seleccionado en este campo, tira el mensaje de error. 
            {
                MessageBox.Show("Seleccione el campo, por favor");
                return true;
            }       
            if (cBoxCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el criterio, por favor");
                return true;
            }
            if (cBoxCampo.SelectedItem.ToString() == "Numero")
            {
                if (string.IsNullOrEmpty(txtFiltroAv.Text)) 
                {
                    MessageBox.Show("Debes cargar el filtro para numericos");
                    return true;    
                }
                if (!(solonumeros(txtFiltroAv.Text)))
                {
                    MessageBox.Show("Solo numeros, por favor");
                    return true;
                }
            }

            return false;                           //Devuelve falso una vez que todos los if sean falsos.
        }

        private bool solonumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter))) 
                {
                    return false;
                }
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocios negocio = new PokemonNegocios();

            try
            {
                if (validarFiltro()) //Si validarFiltro devuelve True NO realiza la accion de buscar. Si validarFiltro = false si ejecuta la acción.
                    return;

                string Campo = cBoxCampo.SelectedItem.ToString();
                string Criterio = cBoxCriterio.SelectedItem.ToString();
                string FiltroAv = txtFiltroAv.Text;
                dgvPokemones.DataSource = negocio.filtrar(Campo, Criterio, FiltroAv);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listafiltrada;
            string filtro = txtFiltro.Text;

            if (filtro != "")
            {
                listafiltrada = listapokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listafiltrada = listapokemon;
            }


            dgvPokemones.DataSource = null;
            dgvPokemones.DataSource = listafiltrada;
            ocultarColumnas();
        }

        private void cBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cBoxCampo.SelectedItem.ToString();
            if (opcion == "Numero") 
            {
                cBoxCriterio.Items.Clear();
                cBoxCriterio.Items.Add("Mayor a");
                cBoxCriterio.Items.Add("Menor a");
                cBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                cBoxCriterio.Items.Clear();
                cBoxCriterio.Items.Add("Comienza con");
                cBoxCriterio.Items.Add("Termina con");
                cBoxCriterio.Items.Add("Contiene");

            }


        }
    }
}
