using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_EF.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            //ML.Result resultRol = BL.Rol.GetAllEF();
            ML.Libro libro = new ML.Libro(); //Instanciamos para poder usar los datos usuario
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();
            //Guardamos los datos del metodos que queremos llamar  en el objeto
            ML.Result result = BL.Libro.GetAllEF();

            if (result.Correct)
            {
                //usuario.Rol.Roles = resultRol.Objects;
                libro.Libros = result.Objects;
                return View(libro); //Guardamos los datos en la vista 
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View(); ;
            }
        }


        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Result resultAutor = BL.Autor.GetAllEF();
            ML.Result resultGenero = BL.Genero.GetAllEF();
            ML.Result resultEditorial = BL.Editorial.GetAllEF();
            ML.Libro libro = new ML.Libro();

            libro.Autor = new ML.Autor();//inicializando
            libro.Genero = new ML.Genero();//inicializando
            libro.Editorial = new ML.Editorial();//inicializando
            if (IdLibro == null)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                return View(libro);
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutor.Objects;
                    libro.Genero.Generos = resultGenero.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el alummno seleccionado";
                }
                return View(libro);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            if (libro.IdLibro==0)
            {
                result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Mensaje = "No ha registrado el alumno" + result.Message;
                }
            }
            else
            {
                result = BL.Libro.UpdateEF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Mensaje = "No ha registrado el alumno" + result.Message;
                }
            }

            return PartialView("Modal");
        }



        [HttpGet]
        public ActionResult Delete(int? IdLibro)
        {
            ML.Result result = new ML.Result();

            if (IdLibro >= 1)
            {
                result = BL.Libro.DeleteEF(IdLibro.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Mensaje = result.Message;
            }
            return PartialView("Modal");
        }
    }
}