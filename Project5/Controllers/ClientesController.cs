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
using Facturacion.Core;

namespace Project5.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClientesController : Controller
    {
        private FacturacionContext _context;

        public ClientesController(FacturacionContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var cliente = _context.Cliente.Select(i => new {
                i.Id,
                i.Nombres,
                i.Apellidos,
                i.Identificacion,
                i.Celular,
                i.Email,
                i.Edad,
                i.FechaNacimiento
            });

            return Json(await DataSourceLoader.LoadAsync(cliente, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Cliente();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Cliente.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values) {
            var model = await _context.Cliente.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Cliente.FirstOrDefaultAsync(item => item.Id == key);

            _context.Cliente.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Cliente model, IDictionary values) {
            string ID = nameof(Cliente.Id);
            string NOMBRES = nameof(Cliente.Nombres);
            string APELLIDOS = nameof(Cliente.Apellidos);
            string IDENTIFICACION = nameof(Cliente.Identificacion);
            string CELULAR = nameof(Cliente.Celular);
            string EMAIL = nameof(Cliente.Email);
            string EDAD = nameof(Cliente.Edad);
            string FECHA_NACIMIENTO = nameof(Cliente.FechaNacimiento);

            if(values.Contains(ID)) {
                model.Id = ConvertTo<System.Guid>(values[ID]);
            }

            if(values.Contains(NOMBRES)) {
                model.Nombres = Convert.ToString(values[NOMBRES]);
            }

            if(values.Contains(APELLIDOS)) {
                model.Apellidos = Convert.ToString(values[APELLIDOS]);
            }

            if(values.Contains(IDENTIFICACION)) {
                model.Identificacion = Convert.ToString(values[IDENTIFICACION]);
            }

            if(values.Contains(CELULAR)) {
                model.Celular = Convert.ToString(values[CELULAR]);
            }

            if(values.Contains(EMAIL)) {
                model.Email = Convert.ToString(values[EMAIL]);
            }

            if(values.Contains(EDAD)) {
                model.Edad = Convert.ToInt32(values[EDAD]);
            }

            if(values.Contains(FECHA_NACIMIENTO)) {
                model.FechaNacimiento = Convert.ToDateTime(values[FECHA_NACIMIENTO]);
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