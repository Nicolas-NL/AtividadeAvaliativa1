using Microsoft.AspNetCore.Mvc;
using AtividadeAvaliativa1.Models;
using AtividadeAvaliativa1.Models.Enuns;

namespace AtividadeAvaliativa1.Controllers
{
     [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        
        };

        
     [HttpGet("{nome}")]
    public IActionResult Get(String Nome)
    {
         Personagem PersoSele = personagens.FirstOrDefault(p => p.Nome == Nome);
       
       if(PersoSele == null){

        return NotFound("Personagem Não Existe");        
       }
       else{
        return Ok(PersoSele);
       }
        
     }

    [HttpPost("PostValidacao")]
    public IActionResult AddPersonagem(Personagem novoPersonagem)
    {
        if(novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
        return BadRequest("Defesa não pode ter o valor igual a 10 ou menor e Inteligencia não pode ser maior que 30.");

        personagens.Add(novoPersonagem);
        return Ok(personagens);
    }
       [HttpPost("PostValidacaoMago")]
    public IActionResult AddPersonagemMago(Personagem novoPersonagem, ClasseEnum classe)
    {

        if(ClasseEnum.Mago == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
        return BadRequest("Inteligencia não pode ser menor que 35.");

        personagens.Add(novoPersonagem);
        return Ok(personagens);
    }

     [HttpGet("GetClerigoMago")]
    public IActionResult GetClerigoMago()
    {

     /* List<Personagem> listaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);*/
      List<Personagem> listaFinal = personagens.OrderBy(p => p.PontosVida).ToList();
      personagens.RemoveAll(pers => pers.Classe == ClasseEnum.Cavaleiro);

       return Ok(personagens);
     }

     [HttpGet("GetEstatisticas")]
    public IActionResult GetEstatisticas()
    {

     /* List<Personagem> listaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);*/
       return Ok("Quantidade de personagens: " + personagens.Count + " Somatoria da Inteligencia de Todos os personagens: " +personagens.Sum(p => p.Inteligencia));

     }
          [HttpGet("GetbyClasse/{Classe}")]
    public IActionResult GetByClasse(ClasseEnum classe)
    {

     List<Personagem> listaBusca = personagens.FindAll(p => p.Classe == classe);
       return Ok(listaBusca);

     }


    }
}