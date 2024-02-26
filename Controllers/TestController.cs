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
        [HttpGet("DecalageCrypt")]
        public Code get(string message, bool gauche)    
        {
            string coded = Algorithms.DecalerCrypter(message, gauche);
            return new Code(coded);
        }

        [HttpGet("decalageSolutionCrypt")]
        public Code getDecalageSolution(string text, int cle)
        {
            string coded = Algorithms.DecalageSolutionCrypt(text, cle, text.Length + 5);
            return new Code(coded);
        }

        [HttpGet("AffineCrypt")]
        public Code getAffine(string message, int a, int b)
        {
            string coded = Algorithms.AffineCrypt(message, a, b);
            return new Code(coded);
        }

        [HttpGet("AffineDecrypt")]
        public Code getAffineDecrypt(string message, int a, int b)
        {
            string coded = Algorithms.AffineDecrypt(message, a, b);
            return new Code(coded);
        }

        [HttpGet("CaesarCrypt")]
        public Code getCaesarCrypt(string message, int shift)
        {
            string coded = Algorithms.CaesarEncrypt(message, shift);
            return new Code(coded);
        }

        [HttpGet("CaesarDecrypt")]
        public Code getCaesarDecrypt(string message, int shift)
        {
            string coded = Algorithms.CaesarDecrypt(message, shift);
            return new Code(coded);
        }

        [HttpGet("Mirroir")]
        public Code getMirroir(string message) 
        {
            string coded = Algorithms.Mirroir(message);
            return new Code(coded);
        }
    }
}
