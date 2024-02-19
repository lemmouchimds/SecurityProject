using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace SecurityAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("crypter")]
    public class TestController : ControllerBase
    {
        [EnableCors]
        [HttpGet]
        public Code get(string message, bool gauche)
        {
            string coded = Algorithms.Decaler(message, gauche);
            return new Code(coded);
        }

        [HttpGet("other")]
        public Code GetOther(string text)
        {
            string coded = Algorithms.Crypter(text, 3, 20);
            return new Code(coded);
        }


        [HttpGet("decalageSolutionCrypter")]
        public Code getDecalageSolution(string text, int cle, int taille)
        {
            string coded = Algorithms.Crypter(text, cle, taille);
            return new Code(coded);
        }
    }
}
