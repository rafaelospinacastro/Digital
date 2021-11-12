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
    public class ProductoController : Controller
    {
        private FacturacionContext _context;

        public ProductoController(FacturacionContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var producto = _context.Producto.Select(i => new {
                i.Id,
                i.Nombre,
                i.Sigla,
                i.Codigo,
                i.Descripcion,
                i.Cantidad,
                i.PrecioActual
            });

            return Json(await DataSourceLoader.LoadAsync(producto, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Producto();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Producto.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values) {
            var model = await _context.Producto.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Producto.FirstOrDefaultAsync(item => item.Id == key);

            _context.Producto.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Producto model, IDictionary values) {
            string ID = nameof(Producto.Id);
            string NOMBRE = nameof(Producto.Nombre);
            string SIGLA = nameof(Producto.Sigla);
            string CODIGO = nameof(Producto.Codigo);
            string DESCRIPCION = nameof(Producto.Descripcion);
            string CANTIDAD = nameof(Producto.Cantidad);
            string PRECIO_ACTUAL = nameof(Producto.PrecioActual);

            if(values.Contains(ID)) {
                model.Id = ConvertTo<System.Guid>(values[ID]);
            }

            if(values.Contains(NOMBRE)) {
                model.Nombre = Convert.ToString(values[NOMBRE]);
            }

            if(values.Contains(SIGLA)) {
                model.Sigla = Convert.ToString(values[SIGLA]);
            }

            if(values.Contains(CODIGO)) {
                model.Codigo = Convert.ToString(values[CODIGO]);
            }

            if(values.Contains(DESCRIPCION)) {
                model.Descripcion = Convert.ToString(values[DESCRIPCION]);
            }

            if(values.Contains(CANTIDAD)) {
                model.Cantidad = Convert.ToInt32(values[CANTIDAD]);
            }

            if(values.Contains(PRECIO_ACTUAL)) {
                model.PrecioActual = Convert.ToDecimal(values[PRECIO_ACTUAL], CultureInfo.InvariantCulture);
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