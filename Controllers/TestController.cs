using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace SecurityAPI.Controllers
{
    [EnableCors]
    [ApiController]
    //[Route("crypter")]
    public class TestController : ControllerBase
    {
        [EnableCors]
        [HttpGet("decalage")]
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

        [HttpGet("decalageSolutionDecrypt")]
        public Code getDecalageSolutionDecrypt(string text, int cle)
        {
            string coded = Algorithms.DecalageSolutionDecrypt(text, cle);
            return new Code(coded);
        }

        [HttpGet("affine")]
        public Code getAffine(string message, int a, int b)
        {
            if (Algorithms.ValiderParametres(a, b))
            {
                string coded = Algorithms.AffineSolutionCrypt(message, a, b);
                return new Code(coded);
            }

            return new Code("ERROR");
        }

        [HttpGet("AffineDecrypt")]
        public Code getAffineDecrypt(string message, int a, int b)
        {
            string coded = Algorithms.AffineSolutionDecrypt(message, a, b);
            return new Code(coded);
        }

        [HttpGet("caesar")]
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

        [HttpGet("mirroir")]
        public Code getMirroir(string message) 
        {
            string coded = Algorithms.MirroirPhrase(message);
            return new Code(coded);
        }
    }
}
