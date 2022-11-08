using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Context;
using Login.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<PacienteController>
        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get()
        {

            try
            {

                return Ok(_context.paciente.ToList());
            }
            catch (Exception exGet)
            {

                return BadRequest(exGet.Message);
            }
        }

        // GET api/<LoteController>/5
        // GET api/<MaterialController>/5
        [HttpGet]
        [Route("GetPacienteById")]
        public async Task<ActionResult<List<Paciente>>> GetPacienteById(int PacienteId)
        {
            var paciente = await _context.paciente.Where(c => c.id == PacienteId).ToListAsync();
            return paciente;
        }


        [HttpGet("{Id}", Name = "GetPaciente")]
        public ActionResult GetId(int id)
        {
            try
            {
                var paciente = _context.paciente.FirstOrDefault(g => g.id == id);
                return Ok(paciente);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<LoteController>
        [HttpPost]
        public ActionResult Post([FromBody] Paciente paciente)
        {
            try

            {

                _context.paciente.Add(paciente);
                _context.SaveChanges();
                return CreatedAtRoute("GetPaciente", new { id = paciente.id }, paciente);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{Id}")]
        public ActionResult Put(int id, [FromBody] Paciente paciente)
        {
            try
            {
                if (paciente.id == id)
                {
                    _context.Entry(paciente).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetPaciente", new { id = paciente.id }, paciente);
                }
                else
                {

                    return BadRequest();
                }


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioTipoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var paciente = _context.paciente.FirstOrDefault(c => c.id == id);
                if (paciente != null)
                {
                    _context.paciente.Remove(paciente);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
