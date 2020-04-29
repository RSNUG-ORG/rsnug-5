using System;
using System.Collections.Generic;
using System.Linq;

namespace rsnug_5
{
    public static class ContandoListasExemplo
    {
        public static object MetodoApi()
        {
            var numeroOrcamentoOuNomeCliente = string.Empty; // Numero recebido na Querystring
            var nomeStatus = string.Empty; // Status recebido na querystring
            var orderBy = string.Empty; // Trata o filtro recebido na querystring
            var ordemDecrescente = false; // Trata filtro recebido na querystring

            var orcamentosPaginado = Orcamento.BuscarOrcamentoPorUsuárioPaginado(); //Simula retorno do serviço

            if (orcamentosPaginado == null || orcamentosPaginado.Data.Count() == 0)
                return NoContent();

            orcamentosPaginado.Data = orcamentosPaginado.Data.Where(i => i.Status.Name.ToLowerInvariant() != "draft");

            if (orcamentosPaginado == null || orcamentosPaginado.Data.Count() == 0)
                return NoContent();

            if (!string.IsNullOrEmpty(numeroOrcamentoOuNomeCliente))
            {
                // ...

                if (orcamentosPaginado == null || orcamentosPaginado.Data.Count() == 0)
                    return NoContent();
            }

            //Filtros de status
            if (!string.IsNullOrEmpty(nomeStatus))
            {
                // ...

                if (orcamentosPaginado == null || orcamentosPaginado.Data.Count() == 0)
                    return NoContent();
            }

            // ...

            if (orcamentosPaginado == null || orcamentosPaginado.Data.Count() == 0)
                return NoContent();

            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = orderBy.ToLowerInvariant();

                if (!ordemDecrescente)
                {
                    // ...
                    orcamentosPaginado.Data = orderBy == "status" ? orcamentosPaginado.Data.Where(o => o.Status != null && o.Status.Name != null).OrderBy(o => o.Status.Name) : orcamentosPaginado.Data;
                    // ...
                }

                else
                {
                    // ...
                    orcamentosPaginado.Data = orderBy == "status" ? orcamentosPaginado.Data.Where(o => o.Status != null && o.Status.Name != null).OrderByDescending(o => o.Status.Name) : orcamentosPaginado.Data;
                    // ...
                }
            }

            //var orcamentosPaginados = orcamentosPaginado.Data
            //    .Skip(tamanhoPagina * index)
            //    .Take(tamanhoPagina);

            return Ok();

        }

        private static object Ok()
        {
            throw new NotImplementedException();
        }

        private static object NoContent()
        {
            throw new NotImplementedException();
        }
    }


    public class Orcamento
    {
        public IEnumerable<Orcamento> Data = new List<Orcamento>()
            {
                new Orcamento(),
                new Orcamento(),
                new Orcamento(),
                new Orcamento(),
                new Orcamento(),
            };

        public int Id { get; set; } = new Random().Next(1, 100);
        public string Descricao { get; set; } = $"Descriação XPTO{new Random().Next(1, 100)}";
        public Status Status { get; set; }

        public static Orcamento BuscarOrcamentoPorUsuárioPaginado(int idUsuario = 0)
        {
            return new Orcamento();
        }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}