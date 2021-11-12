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
using Facturacion.Core.Entities;
using Facturacion.Infrastructure.Data;

namespace Project5.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DetalleComprasController : Controller
    {
        private FacturacionContext _context;

        public DetalleComprasController(FacturacionContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var detallecompra = _context.DetalleCompra.Select(i => new {
                i.Id,
                i.IdCompra,
                i.IdProducto,
                i.Cantidad,
                i.ValorProducto
            });

            return Json(await DataSourceLoader.LoadAsync(detallecompra, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new DetalleCompra();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.DetalleCompra.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values) {
            var model = await _context.DetalleCompra.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.DetalleCompra.FirstOrDefaultAsync(item => item.Id == key);

            _context.DetalleCompra.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(DetalleCompra model, IDictionary values) {
            string ID = nameof(DetalleCompra.Id);
            string ID_COMPRA = nameof(DetalleCompra.IdCompra);
            string ID_PRODUCTO = nameof(DetalleCompra.IdProducto);
            string CANTIDAD = nameof(DetalleCompra.Cantidad);
            string VALOR_PRODUCTO = nameof(DetalleCompra.ValorProducto);

            if(values.Contains(ID)) {
                model.Id = ConvertTo<System.Guid>(values[ID]);
            }

            if(values.Contains(ID_COMPRA)) {
                model.IdCompra = ConvertTo<System.Guid>(values[ID_COMPRA]);
            }

            if(values.Contains(ID_PRODUCTO)) {
                model.IdProducto = ConvertTo<System.Guid>(values[ID_PRODUCTO]);
            }

            if(values.Contains(CANTIDAD)) {
                model.Cantidad = Convert.ToInt32(values[CANTIDAD]);
            }

            if(values.Contains(VALOR_PRODUCTO)) {
                model.ValorProducto = Convert.ToDecimal(values[VALOR_PRODUCTO], CultureInfo.InvariantCulture);
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