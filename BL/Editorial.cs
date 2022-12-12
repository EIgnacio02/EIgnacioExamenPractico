using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioPruebaTecnicaEntities context = new DL_EF.EIgnacioPruebaTecnicaEntities())
                {
                    var query = context.EditorialGetAll().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.NombreEditorial = obj.NombreEditorial;

                            result.Objects.Add(editorial);
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
