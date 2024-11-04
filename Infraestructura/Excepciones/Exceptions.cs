using System;

namespace Infraestructura.Excepciones
{
    public class Exceptions
    {
        public class UnprocessableEntity : Exception
        {
            public new static string Message;
            public UnprocessableEntity() { Message = "Revise que los parametros ingresados sean correctos"; }
            public UnprocessableEntity(string message) { Message = message; }
        }

        public class Unauthorized : Exception
        {
            public new static string Message;
            public string Mensaje { get; set; }
            public static int Subcode;
            public Unauthorized() { Message = "Usuario no Autorizado"; }
            public Unauthorized(int subCode, string message) { Subcode = subCode; Message = message; Mensaje = message; }
        }

        public class NotAcceptable : Exception
        {
            public new static string Message;

            public string Mensaje { get; set; }


            public NotAcceptable(string message) { Message = message; Mensaje = message; }
        }

        public class FailedDependency : Exception
        {
            public new static string Message;
            public string Mensaje { get; set; }
            public FailedDependency() { Message = "Ingrese al menos un parametro correcto"; }
            public FailedDependency(string message) { Message = message; Mensaje = message; }
        }

        public class NoContent : Exception
        {
            public new static string Message;
            public string mensaje { get; set; }
            public NoContent() { Message = "No hay elementos para mostrar"; }
            public NoContent(string message) { Message = message; mensaje = message; }
        }

        public class InvalidToken : Exception
        {
            public new static string Message = "Token Invalido";
        }

        public class ExpiredToken : Exception
        {
            public new static string Message = "El Token Expiró";
        }


    }
}