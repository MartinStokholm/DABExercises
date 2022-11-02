using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFMS_v2_app.Models;

namespace RFMS_v2_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceInterventionsController : ControllerBase
    {
        private readonly DataContext _context;

        public MaintenanceInterventionsController(DataContext context)
        {
            _context = context;
        }

    }
}
