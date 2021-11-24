using Aplicacao.CupomModule;
using Aplicacao.Shared;
using AutoMapper;
using Dominio.ParceiroModule;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : ControllerBase
    {
        private readonly ParceiroAppServices parceiroServices;
        private readonly IMapper mapper;

        public ParceiroController()
        {
            this.parceiroServices = new ParceiroAppServices();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parceiro, ParceiroListViewModel>();
                    
                cfg.CreateMap<Parceiro, ParceiroDetailsViewModel>();

                cfg.CreateMap<ParceiroCreateViewModel, Parceiro>();

                cfg.CreateMap<ParceiroEditViewModel, Parceiro>();
            });

            this.mapper = config.CreateMapper();
        }

        // GET: api/<ParceiroController>
        [HttpGet]
        public List<ParceiroListViewModel> Get()
        {
            var parceiros = parceiroServices.Registros;

            var viewModel = mapper.Map<List<ParceiroListViewModel>>(parceiros);

            return viewModel;
        }

        // GET api/<ParceiroController>/5
        [HttpGet("{id}")]
        public ActionResult<ParceiroDetailsViewModel> Get(int id)
        {
            
            var parceiro = parceiroServices.GetById(id);

            if (parceiro == null)
                return NotFound(id);

            
            var viewModel = mapper.Map<ParceiroDetailsViewModel>(parceiro);

            return Ok(viewModel);
        }

        // POST api/<ParceiroController>
        [HttpPost]
        public ActionResult Post(ParceiroCreateViewModel viewModel)
        {
            Parceiro parceiro = mapper.Map<Parceiro>(viewModel);

            var resultado = parceiroServices.Inserir(parceiro);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return CreatedAtAction(nameof(Post), viewModel);

            return NoContent();
        }

        // PUT api/<ParceiroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ParceiroEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            var parceiro = mapper.Map<Parceiro>(viewModel);

            var resultado = parceiroServices.Editar(id, parceiro);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return Ok(viewModel);

            return NoContent();
        }

        // DELETE api/<ParceiroController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var resultado = parceiroServices.Excluir(id);

            if (resultado == true)
                return Ok(id);

            return NoContent();

        }
    }
}
