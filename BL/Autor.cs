using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    var query = context.AutorGetAll().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = obj.IdAutor;
                            autor.NombreAutor = obj.NombreAutor;

                            result.Objects.Add(autor);
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
    }
}
