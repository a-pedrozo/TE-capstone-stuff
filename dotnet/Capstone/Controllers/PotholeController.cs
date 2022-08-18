using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("pothole/")]
    [ApiController]
    public class PotholeController : ControllerBase
    {
        private readonly IPotholeDAO potholeDAO;

        public PotholeController(IPotholeDAO potholeDAO)
        {
            this.potholeDAO = potholeDAO;
        }

        [HttpGet]
        public ActionResult GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            if (potholes == null)
            {
                return NotFound("Your list is empty or not found");
            }
            return Ok(potholes);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddPothole(Pothole newPothole)
        {
            newPothole.ReportDate = DateTime.Today; 
            newPothole = potholeDAO.AddPothole(newPothole);

            if (newPothole == null)
            {
                return NotFound("Unable to add pothole--please try again");
            }
            return Ok(newPothole);
        }

        [HttpGet("{potholeId}")]
        public ActionResult GetPothole(int potholeId)
        {
            Pothole pothole = potholeDAO.GetPothole(potholeId);

            if (pothole == null)
            {
                return NotFound("Your pothole is empty or not found");
            }
            return Ok(pothole);
        }


        [HttpDelete("{potholeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeletePothole(int potholeId)
        {
            bool deleted = potholeDAO.DeletePothole(potholeId);

            if(deleted == false)
            {
                return BadRequest("Unable to delete pothole--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult ScheduleInspection(int potholeId, Pothole pothole)
        {
            bool reviewed = potholeDAO.ScheduleInspection(potholeId, pothole.InspectionDate);

            if (reviewed == false)
            {
                return BadRequest("Unable to schedule inspection--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}/un")]
        [Authorize(Roles = "admin")]
        public ActionResult UnScheduleInspection(int potholeId)
        {
            bool reviewed = potholeDAO.UnScheduleInspection(potholeId);

            if(reviewed == false)
            {
                return BadRequest("Unable to unschedule inspection--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}/re")]
        [Authorize(Roles = "admin")]
        public ActionResult ScheduleRepair(int potholeId, Pothole pothole)
        {
            bool reviewed = potholeDAO.ScheduleRepair(potholeId, pothole);

            if (reviewed == false)
            {
                return BadRequest("Unable to schedule repair--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}/unre")]
        [Authorize(Roles = "admin")]
        public ActionResult UnScheduleRepair(int potholeId)
        {
            bool reviewed = potholeDAO.UnScheduleRepair(potholeId);

            if (reviewed == false)
            {
                return BadRequest("Unable to unschedule repair--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}/repair")]
        [Authorize(Roles = "admin")]
        public ActionResult MarkAsRepaired(int potholeId)
        {
            bool reviewed = potholeDAO.MarkAsRepaired(potholeId);

            if (reviewed == false)
            {
                return BadRequest("Unable to mark as repaired--please check pothole ID and try again");
            }
            return Ok();
        }

        [HttpPut("{potholeId}/unrepair")]
        [Authorize(Roles = "admin")]
        public ActionResult MarkAsUnrepaired(int potholeId)
        {
            bool reviewed = potholeDAO.MarkAsUnrepaired(potholeId);

            if (reviewed == false)
            {
                return BadRequest("Unable to mark as unrepaired--please check pothole ID and try again");
            }
            return Ok();
        }
    }
}
