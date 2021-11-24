using Aplicacao.FuncionarioModule;
using Aplicacao.Shared;
using AutoMapper;
using Dominio.PessoaModule;
using Infra.Extensions.Methods;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        FuncionarioAppServices funcionarioServices;
        IMapper mapper;

        public FuncionarioController()
        {
            this.funcionarioServices = new FuncionarioAppServices();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Funcionario, FuncionarioListViewModel>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => (Cargo)src.Cargo)); ;

                cfg.CreateMap<Funcionario, FuncionarioDetailsViewModel>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => (int)src.Cargo));

                cfg.CreateMap<FuncionarioCreateViewModel, Funcionario>()
                .ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Foto.Base64ToImage()))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => (Cargo)src.Cargo));

                cfg.CreateMap<FuncionarioEditViewModel, Funcionario>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => (Cargo)src.Cargo));
            }
            );

            this.mapper = config.CreateMapper();
        }

        // GET: api/<FuncionarioController>
        [HttpGet]
        public List<FuncionarioListViewModel> Get()
        {
            var parceiros = funcionarioServices.Registros;

            var viewModel = mapper.Map<List<FuncionarioListViewModel>>(parceiros);

            return viewModel;
        }

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public ActionResult<FuncionarioDetailsViewModel> Get(int id)
        {
            var funcionario = funcionarioServices.GetById(id);

            if (funcionario == null)
                return NotFound(id);


            var viewModel = mapper.Map<FuncionarioDetailsViewModel>(funcionario);

            return Ok(viewModel);
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public ActionResult Post(FuncionarioCreateViewModel viewModel)
        {
            Funcionario funcionario = mapper.Map<Funcionario>(viewModel);

            var resultado = funcionarioServices.Inserir(funcionario);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return CreatedAtAction(nameof(Post), viewModel);

            return NoContent();
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ParceiroEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            var parceiro = mapper.Map<Funcionario>(viewModel);

            var resultado = funcionarioServices.Editar(id, parceiro);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return Ok(viewModel);

            return NoContent();
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var resultado = funcionarioServices.Excluir(id);

            if (resultado == true)
                return Ok(id);

            return NoContent();
        }
    }
}
