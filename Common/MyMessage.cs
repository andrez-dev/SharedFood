using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestoFolder
{
    using System;


    public static class MyMessage
    {
        public static string Error(Exception ex)
        {
            return "<div class='alert alert-danger' role='alert'><button type='button' class='close' data-dismiss='alert'>×</button> <strong>Error: </strong>" + ex.Message + "</div>";
        }

        public static string Error(string message)
        {

            return "<div class='alert alert-danger' role='alert'><button type='button' class='close' data-dismiss='alert'>×</button> <strong>Error: </strong>" + message + "</div>";
        }

        public static string Info(string msg)
        {
            return "<div class='alert alert-info' role='alert'><button type='button' class='close' data-dismiss='alert'>×</button> <strong>Info: </strong>" + msg + "</div>";
        }

        public static string Warning(string msg)
        {
            return "<div class='alert alert-warning' role='alert'><button type='button' class='close' data-dismiss='alert'>×</button> <strong>War: </strong>" + msg + "</div>";
        }

        public static string Success(string msg)
        {
            return "<div class='alert alert-success' role='alert'><button type='button' class='close' data-dismiss='alert'>×</button>" + msg + "</div> ";
        }

        #region Messaging Generic

        public static string GenericInsert()
        {
            return "<div class='alert alert-success' role='alert'>Registro(s) ingresado(s) con exito!</div>";
        }

        public static string GenericUpdate()
        {
            return "<div class='alert alert-success' role='alert'>Registro(s) actualizado(s) con exito</div>";
        }

        public static string GenericDelete()
        {
            return "<div class='alert alert-success' role='alert'>Registro(s) eliminado(s) con exito</div>";
        }

        #endregion

    }


}