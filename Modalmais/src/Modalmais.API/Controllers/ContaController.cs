﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modalmais.API.DTOs;
using Modalmais.Business.Interfaces.Repository;
using Modalmais.Business.Models;
using Modalmais.Infra.Data;
using System;
using System.Threading.Tasks;

namespace Modalmais.API.Controllers
{
    [Route("api/v1/clientes")]
    public class ContaCorrenteController : MainController
    {

        protected readonly IClienteRepository _clienteRepository;

        public ContaCorrenteController(IMapper mapper,
                                       DbContext context,
                                       IClienteRepository clienteRepository
                                       ) : base(mapper, context)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarCliente(ClienteRequest clienteRequest)
        {
            var cliente = _mapper.Map<Cliente>(clienteRequest);

            if (!cliente.ValidarUsuario()) return new BadRequestObjectResult(cliente.ListaDeErros);

            await _context.Clientes.InsertOneAsync(cliente);

            return new CreatedResult(nameof(AdicionarCliente), "");

        }

        [HttpGet]
        public async Task<IActionResult> ListaClientes()
        {

            var ListaClientes = await _clienteRepository.ObterTodos();

            return new OkObjectResult(ListaClientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ClienteById(string id)
        {

            var Cliente = await _clienteRepository.ObterPorId(id);

            if (Cliente != null) return new BadRequestObjectResult("Id não encontrado");

            return new OkObjectResult(Cliente);
        }



        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public bool ValidarDocumento(IFormFile documentorecebido)
        {

            var numero = new Random().Next(1, 3);

            return numero % 2 == 0 ? true : false;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public string SalvarDocumento(IFormFile documentorecebido)
        {

            ////armazena fake

            var nomenclaturaPadrao = "_" + Guid.NewGuid().ToString();
            var urlFake = $"https://i.ibb.co/{documentorecebido.FileName}{nomenclaturaPadrao}";

            return urlFake;
        }


    }

}
