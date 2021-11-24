using Aplicacao.CupomModule;
using Aplicacao.Shared;
using AutoMapper;
using Dominio.CupomModule;
using Dominio.ParceiroModule;
using Dominio.Repositories;
using Infra.DAO.ORM;
using Infra.DAO.ORM.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static WebApi.ViewModels.CupomViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly CupomAppServices cupomAppService;
        private readonly ParceiroAppServices parceiroAppService;
        private readonly IMapper mapper;

        public CupomController()
        {
            this.cupomAppService = new CupomAppServices();
            this.parceiroAppService = new ParceiroAppServices();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cupom, CupomListViewModel>();

                cfg.CreateMap<Cupom, CupomDetailsViewModel>();

                cfg.CreateMap<CupomCreateViewModel, Cupom>()
                .ForMember(
                    dest => dest.Parceiro,
                    opt => opt.MapFrom(src => parceiroAppService.GetById(src.ParceiroId, null)));

                cfg.CreateMap<CupomEditViewModel, Cupom>();
            });

            this.mapper = mapperConfig.CreateMapper();
        }

        // GET: api/<CupomController>
        [HttpGet]
        public List<CupomListViewModel> Get()
        {
            var cupons = cupomAppService.Registros;

            var viewModel = mapper.Map<List<CupomListViewModel>>(cupons);

            return viewModel;
        }

        // GET api/<CupomController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var cupom = cupomAppService.GetById(id);

            if (cupom == null)
                return NotFound(id);

            var viewModel = mapper.Map<CupomDetailsViewModel>(cupom);

            return Ok(viewModel);
        }

        // POST api/<CupomController>
        [HttpPost]
        public ActionResult Post(CupomCreateViewModel viewModel)
        {
            Cupom cupom = mapper.Map<Cupom>(viewModel);

            var resultado = cupomAppService.Inserir(cupom);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return CreatedAtAction(nameof(Post), viewModel);

            return NoContent();
        }

        // PUT api/<CupomController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, CupomEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return BadRequest();

            Cupom cupom = mapper.Map<Cupom>(viewModel);

            var resultado = cupomAppService.Editar(id, cupom);

            if (resultado.Resultado == EnumResultado.Sucesso)
                return Ok(viewModel);

            return NoContent();

        }

        // DELETE api/<CupomController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var resultado = cupomAppService.Excluir(id);

            if (resultado == true)
                return Ok(id);

            return NoContent();
        }
    }
}
