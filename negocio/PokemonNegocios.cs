using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;

namespace negocio
{
    public class PokemonNegocios
    {
        public List<Pokemon> listar() {
            
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security = True";
                comando.CommandType =System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, URLImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad And P.Activo = 1";
                comando.Connection = conexion;

                conexion.Open(); //abrir conexion
                lector = comando.ExecuteReader(); //Leer lo ejecutado

                while (lector.Read()) 
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                   //Forma 1 de manejar el error que salta cuando intento leer un dato null que en BD no acepta null.
                   // if (!(lector.IsDBNull(lector.GetOrdinal("URLImagen"))))
                   //     aux.URLImagen = (string)lector["URLImagen"];
                   //Forma 2:
                   if (!(lector["URLImagen"] is DBNull))
                        aux.URLImagen = (string)lector["URLImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];    
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }

                conexion.Close(); //Cerramos la conexion               
                return lista; //Retornamos la lista
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void agregar(Pokemon pnuevo)
        {
            accesoadatos datos = new accesoadatos();
            try
            {
                datos.setearConsulta("insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, URLImagen) values (" + pnuevo.Numero + ", '" + pnuevo.Nombre + "','" + pnuevo.Descripcion + "',1,@IdTipo,@IdDebilidad,@URLImagen )"); //forma 1 con concatenacion. Forma 2 con parametros.
                datos.setearParametro("@IdTipo", pnuevo.Tipo.Id); //Llamo la funcion que recibe los parametros para ejecutar en la linea de arriba.
                datos.setearParametro("@IdDebilidad", pnuevo.Debilidad.Id);
                datos.setearParametro("@URLImagen", pnuevo.URLImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
           
        }
        public void modificar(Pokemon modificarp)
        {
            accesoadatos datos = new accesoadatos();
            try
             {
                datos.setearConsulta("Update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @Url, IdTipo = @IdTipo, IdDebilidad = @IdDeb where Id = @Id");
                datos.setearParametro("@numero", modificarp.Numero);
                datos.setearParametro("@nombre", modificarp.Nombre);
                datos.setearParametro("@Descripcion", modificarp.Descripcion);
                datos.setearParametro("@URL", modificarp.URLImagen);
                datos.setearParametro("@IdTipo", modificarp.Tipo.Id);
                datos.setearParametro("@IdDeb", modificarp.Debilidad.Id);
                datos.setearParametro("ID", modificarp.Id);

                datos.ejecutarAccion();

            }
             catch (Exception ex)
             {

                 throw ex;
             }
            finally 
            { 
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                accesoadatos datos = new accesoadatos();
                datos.setearConsulta("delete from POKEMONS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
        public void eliminarLogico(int id)
        {
            try
            {
                accesoadatos datos = new accesoadatos();
                datos.setearConsulta("Update POKEMONS set Activo = 0 Where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, object filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            accesoadatos datos = new accesoadatos();

            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, URLImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad And P.Activo = 1 And ";
                

                if (campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "Numero = " + filtro;
                            break;
                        default: break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                        default: break;
                    }
                }
                else 
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;
                        default: break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                    if (!(datos.Lector["URLImagen"] is DBNull))
                        aux.URLImagen = (string)datos.Lector["URLImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
    
    
    





}
