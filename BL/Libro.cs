//using ML;
using ML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();


                        SqlParameter[] arreglo = new SqlParameter[7];

                        arreglo[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        arreglo[0].Value = libro.Nombre;

                        arreglo[1] = new SqlParameter("NUmeroDePaginas", SqlDbType.Int);
                        arreglo[1].Value = libro.NumeroPaginas;

                        arreglo[2] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        arreglo[2].Value = libro.FechaPublicacion;

                        arreglo[3] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        arreglo[3].Value = libro.Edicion;

                        arreglo[4] = new SqlParameter("IdAutor", SqlDbType.Int);
                        arreglo[4].Value = libro.Autor.IdAutor;

                        arreglo[5] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        arreglo[5].Value = libro.Editorial.IdEditorial;

                        arreglo[6] = new SqlParameter("IdGenero", SqlDbType.Int);
                        arreglo[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(arreglo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = ("Los datos se ingresados correctamente");
                        }
                    }
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();


                        SqlParameter[] arreglo = new SqlParameter[8];

                        arreglo[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        arreglo[0].Value = libro.IdLibro;

                        arreglo[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        arreglo[1].Value = libro.Nombre;

                        arreglo[2] = new SqlParameter("NUmeroDePaginas", SqlDbType.Int);
                        arreglo[2].Value = libro.NumeroPaginas;

                        arreglo[3] = new SqlParameter("FechaPublicacion", SqlDbType.VarChar);
                        arreglo[3].Value = libro.FechaPublicacion;

                        arreglo[4] = new SqlParameter("Edicion", SqlDbType.VarChar);
                        arreglo[4].Value = libro.Edicion;

                        arreglo[5] = new SqlParameter("IdAutor", SqlDbType.Int);
                        arreglo[5].Value = libro.Autor.IdAutor;

                        arreglo[6] = new SqlParameter("IdEditorial", SqlDbType.Int);
                        arreglo[6].Value = libro.Editorial.IdEditorial;

                        arreglo[7] = new SqlParameter("IdGenero", SqlDbType.Int);
                        arreglo[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(arreglo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = ("Los datos se actualizaron correctamente");
                        }
                    }
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();


                        SqlParameter[] arreglo = new SqlParameter[1];

                        arreglo[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        arreglo[0].Value = IdLibro;

                        cmd.Parameters.AddRange(arreglo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = ("El dato fue eliminado correctamente");
                        }
                    }
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();




                        DataTable libroTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(libroTable);



                        if (libroTable.Rows.Count >0)
                        {
                            result.Objects = new List<object>();


                            foreach (DataRow row in libroTable.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.NumeroPaginas = int.Parse(row[2].ToString());
                                libro.FechaPublicacion=row[3].ToString();
                                libro.Edicion=row[4].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[5].ToString());
                                libro.Autor.NombreAutor = row[6].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[7].ToString());
                                libro.Editorial.NombreEditorial = row[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.NombreGenero = row[10].ToString();

                                result.Objects.Add(libro);
                            }
                        }
                    }
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al mostrar los datos";
            }

            return result;
        }
        public static ML.Result GetAllById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Connection()))
                {
                    var query = "LibroGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        context.Open();
                        SqlParameter[] arreglo = new SqlParameter[1];

                        arreglo[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        arreglo[0].Value = IdLibro;
                        cmd.Parameters.AddRange(arreglo);
                        DataTable libroTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(libroTable);


                        if (libroTable.Rows.Count > 0)
                        {

                            DataRow row =libroTable.Rows[0];
                            
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.NumeroPaginas = int.Parse(row[2].ToString());
                            libro.FechaPublicacion = row[3].ToString();
                            libro.Edicion = row[4].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.NombreAutor = row[6].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[7].ToString());
                            libro.Editorial.NombreEditorial = row[8].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.NombreGenero = row[10].ToString();

                            result.Object = libro; // BOXING

                        }
                    }
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al mostrar los datos";
            }

            return result;
        }


        //Entity
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context=new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    var query = context.LibroGetAll().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Libro libros = new ML.Libro();

                            libros.IdLibro = obj.IdLibro;
                            libros.Nombre = obj.Nombre;
                            libros.NumeroPaginas = (int)obj.NUmeroDePaginas;
                            libros.FechaPublicacion = obj.FechaPublicacion.ToString();
                            libros.Edicion = obj.Edicion;

                            libros.Autor = new ML.Autor();
                            libros.Autor.IdAutor = (int)obj.IdAutor;
                            libros.Autor.NombreAutor = obj.NombreAutor;

                            libros.Editorial = new ML.Editorial();
                            libros.Editorial.IdEditorial = (int)obj.IdEditorial;
                            libros.Editorial.NombreEditorial = obj.NombreEditorial;

                            libros.Genero = new ML.Genero();
                            libros.Genero.IdGenero = (int)obj.IdGenero;
                            libros.Genero.NombreGenero = obj.NombreGenero;

                            result.Objects.Add(libros);
                        }
                    }
                    
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al mostrar los datos";
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    var query = context.LibroGetById(IdLibro).SingleOrDefault();

                    result.Objects = new List<object>();
                    if (query != null)
                    {


                        ML.Libro libros = new ML.Libro();

                        libros.IdLibro = query.IdLibro;
                        libros.Nombre = query.Nombre;
                        libros.NumeroPaginas = (int)query.NUmeroDePaginas;
                        libros.FechaPublicacion = query.FechaPublicacion.ToString();
                        libros.Edicion = query.Edicion;

                        libros.Autor = new ML.Autor();
                        libros.Autor.IdAutor = (int)query.IdAutor;
                        libros.Autor.NombreAutor = query.NombreAutor;

                        libros.Editorial = new ML.Editorial();
                        libros.Editorial.IdEditorial = (int)query.IdEditorial;
                        libros.Editorial.NombreEditorial = query.NombreEditorial;

                        libros.Genero = new ML.Genero();
                        libros.Genero.IdGenero = (int)query.IdGenero;
                        libros.Genero.NombreGenero = query.NombreGenero;

                        result.Object=libros;

                    }

                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al mostrar los datos";
            }

            return result;
        }

        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    int query = context.LibroAdd(libro.Nombre,libro.NumeroPaginas,libro.FechaPublicacion,libro.Edicion,libro.Autor.IdAutor,libro.Editorial.IdEditorial,libro.Genero.IdGenero);

                    if (query >0)
                    {
                        result.Message = "Libro registrado exitosamente";
                    }
                    else
                    {
                        result.Message = "No se pudo registrar el libro";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    int query = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.NumeroPaginas, libro.FechaPublicacion, libro.Edicion, libro.Autor.IdAutor, libro.Editorial.IdEditorial, libro.Genero.IdGenero);

                    if (query > 0)
                    {
                        result.Message = "Libro actualizado exitosamente";
                    }
                    else
                    {
                        result.Message = "No se pudo actualizar el libro";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }

        public static ML.Result DeleteEF(int? IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    int query = context.LibroDelete(IdLibro);
                    if (query > 0)
                    {
                        result.Message = "Libro se elimino exitosamente";
                    }
                    else
                    {
                        result.Message = "No se pudo eliminar el libro";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror al registrar los datos";
            }

            return result;
        }
    }
}
