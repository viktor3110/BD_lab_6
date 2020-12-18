using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab6.Models;
using Lab6.ViewModels;

namespace Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDiskController : ControllerBase
    {
        private readonly DiskRentalContext db;

        public ClientDiskController(DiskRentalContext applicationContext)
        {
            db = applicationContext;
        }
        // GET: api/<ClientDiskController>
        [HttpGet]
        public IEnumerable<RentalRecordViewModel> Get()
        {
            var clientDisks = db.RentalRecords.ToList();
            List<RentalRecordViewModel> clientDiskViewModels = new List<RentalRecordViewModel>();
            foreach (var clientDisk in clientDisks)
            {
                clientDiskViewModels.Add(new RentalRecordViewModel
                {
                    Id = clientDisk.Id,
                    DiscName = db.Discs.Where(elem => elem.Id == clientDisk.DiscId).First().Name,
                    ClientFIO = db.Clients.Where(item => item.Id == clientDisk.ClientId).First().FIO,
                    EmployeeFIO = db.Employees.Where(item => item.Id == clientDisk.EmployeeId).First().FIO,
                    PaymentCheck = clientDisk.PaymentCheck == 0 ? "Нет" : "Да",
                    ReturnCheck = clientDisk.ReturnCheck == 0 ? "Нет" : "Да",
                    DateOfReturn = clientDisk.DateOfReturn,
                    DateOfRent = clientDisk.DateOfRent
                });
            }
            return clientDiskViewModels;
        }

        // GET api/<ClientDiskController>/5
        [HttpGet("{id}")]
        public RentalRecord Get(int id)
        {
            return db.RentalRecords.Where(item => item.Id == id).First();
        }

        // GET api/values
        [HttpGet("client")]
        public IEnumerable<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        // GET api/values
        [HttpGet("disk")]
        public IEnumerable<Disc> GetDisks()
        {
            return db.Discs.ToList();
        }

        // GET api/values
        [HttpGet("empl")]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        // POST api/<ClientDiskController>
        [HttpPost]
        public IActionResult Post([FromBody] RentalRecord model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Id = db.RentalRecords.Select(item => item.Id).Max() + 1;
            db.RentalRecords.Add(model);
            db.SaveChanges();
            return Ok(model);
        }

        // PUT api/<ClientDiskController>/5
        [HttpPut]
        public IActionResult Put([FromBody] RentalRecord model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            RentalRecord clientDisk = db.RentalRecords.Where(item => item.Id == model.Id).First();
            clientDisk.DiscId = model.DiscId;
            clientDisk.ClientId = model.ClientId;
            clientDisk.EmployeeId = model.EmployeeId;
            clientDisk.PaymentCheck = model.PaymentCheck;
            clientDisk.ReturnCheck = model.ReturnCheck;
            clientDisk.DateOfReturn = model.DateOfReturn;
            clientDisk.DateOfRent = model.DateOfRent;
            db.SaveChanges();
            return Ok(model);
        }

        // DELETE api/<ClientDiskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id = -1)
        {
            if (id == -1)
            {
                return BadRequest();
            }
            RentalRecord clientDisk = db.RentalRecords.Where(item => item.Id == id).First();
            db.RentalRecords.Remove(clientDisk);
            db.SaveChanges();
            return Ok(id);
        }
    }
}
