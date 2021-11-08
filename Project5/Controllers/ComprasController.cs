using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.Core.Data;
using Facturacion.Core.Entities;

namespace Project5.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ComprasController : Controller
    {
        private FacturacionContext _context;

        public ComprasController(FacturacionContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var compra = _context.Compra.Select(i => new {
                i.Id,
                i.IdCliente,
                i.ValorTotal,
                i.Fecha,
                i.Usuario
            });

            return Json(await DataSourceLoader.LoadAsync(compra, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Compra();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Compra.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values) {
            var model = await _context.Compra.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(Guid key) {
            var model = await _context.Compra.FirstOrDefaultAsync(item => item.Id == key);

            _context.Compra.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Compra model, IDictionary values) {
            string ID = nameof(Compra.Id);
            string ID_CLIENTE = nameof(Compra.IdCliente);
            string VALOR_TOTAL = nameof(Compra.ValorTotal);
            string FECHA = nameof(Compra.Fecha);
            string USUARIO = nameof(Compra.Usuario);

            if(values.Contains(ID)) {
                model.Id = ConvertTo<System.Guid>(values[ID]);
            }

            if(values.Contains(ID_CLIENTE)) {
                model.IdCliente = ConvertTo<System.Guid>(values[ID_CLIENTE]);
            }

            if(values.Contains(VALOR_TOTAL)) {
                model.ValorTotal = Convert.ToDecimal(values[VALOR_TOTAL], CultureInfo.InvariantCulture);
            }

            if(values.Contains(FECHA)) {
                model.Fecha = Convert.ToDateTime(values[FECHA]);
            }

            if(values.Contains(USUARIO)) {
                model.Usuario = Convert.ToString(values[USUARIO]);
            }
        }

        private T ConvertTo<T>(object value) {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            if(converter != null) {
                return (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
            } else {
                // If necessary, implement a type conversion here
                throw new NotImplementedException();
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}