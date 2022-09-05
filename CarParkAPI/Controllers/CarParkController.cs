using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkAPI.Models;
using CarParkAPI.BLL;
using CarParkAPI.Interfaces;
namespace CarParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarParkController : ControllerBase
    {
        private IParkSpaces ps = new ParkSpacesRepository();
        /// <returns>
        /// 400: BadRequest -> Error Message //and stacktrace
        /// 200: Ok -> Returns ok
        [HttpGet]
        public ActionResult<ParkSpace> GetAvailablity(DateTime from, DateTime to)
        {
            try
            {
                return ps.GetAvailability(from, to);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //+ " " + ex.StackTrace    
            }
        }

        // POST: api/AddReservation
        [HttpPost]
        public ActionResult<UserParkSpace> AddReservation(int UserId,int ParkSpaceId,DateTime date)
        {
            try
            {
                return Ok(ps.AddReservation(UserId, ParkSpaceId, date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //+ " " + ex.StackTrace    
            }
        }
        // Cancel
        [HttpPost]
        public ActionResult<UserParkSpace> CancelReservation(int UserId, int ParkSpaceId, DateTime date)
        {
            try
            {
                return Ok(ps.CancelReservation(UserId, ParkSpaceId, date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //+ " " + ex.StackTrace    
            }
        }
        //Amend
        [HttpPost]
        public ActionResult<UserParkSpace> AmendReservation(int UserId, int ParkSpaceId, DateTime date, int NewParkSpaceId, DateTime Newdate)
        {
            try
            {
                return Ok(ps.AmendReservation(UserId, ParkSpaceId, date, NewParkSpaceId, Newdate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //+ " " + ex.StackTrace    
            }
        }
        //Get Price
        [HttpGet]
        public string GetPrice(DateTime date)
        {
            try
            {
                return ps.GetPrice(date);
            }
            catch (Exception ex)
            {
                return ex.Message; //+ " " + ex.StackTrace    
            }
        }
    }
}
