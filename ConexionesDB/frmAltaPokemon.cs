using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;


namespace ConexionesDB
{
    public partial class frmAltaPokemon : Form
    {
       
        
        private Pokemon Pokemon = null;
        private OpenFileDialog archivo = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.Pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Pokemon nuevoP = new Pokemon();
            PokemonNegocios negocio = new PokemonNegocios();    


            try
            {
                if (Pokemon == null)
                { 
                    Pokemon = new Pokemon();
                }

                Pokemon.Numero = int.Parse(txtNum.Text);
                Pokemon.Nombre = txtNombre.Text;
                Pokemon.Descripcion = txtDesc.Text;
                Pokemon.URLImagen = textbUrlImagen.Text;
                Pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                Pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                if (Pokemon.Id != 0)
                {
                    negocio.modificar(Pokemon);
                    MessageBox.Show("Modificado exitosamente");
                    
                }
                else
                {
                    negocio.agregar(Pokemon);
                    MessageBox.Show("Agregado exitosamente");
                }
                //Guardo img si la levanto localmente. La 2da condición es para que de verdadero en caso de que la URL no contenga http (Eso indica que fue levantada localm)
                if (archivo != null && !(textbUrlImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["images-folder"]] + archivo.SafeFileName);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
           
            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion"; 
                cboDebilidad.DataSource = elementoNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";
              
                if (Pokemon != null) 
                {
                    txtNum.Text = Pokemon.Numero.ToString();
                    txtNombre.Text = Pokemon.Nombre;
                    txtDesc.Text = Pokemon.Descripcion;                   
                    textbUrlImagen.Text = Pokemon.URLImagen;
                    cargarImagen(Pokemon.URLImagen);
                    cboTipo.SelectedValue = Pokemon.Tipo.Id;
                    cboDebilidad.SelectedValue = Pokemon.Debilidad.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textbUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(textbUrlImagen.Text);
            
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

        private void btnagregarimagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK) 
            {
                textbUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

               
                
            }


        }
    }
}
