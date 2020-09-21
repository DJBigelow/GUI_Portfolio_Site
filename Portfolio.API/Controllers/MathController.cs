//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController
    {

        [HttpGet("AddFive")]
        public int AddFive(int num) => num + 5;


        [HttpGet("Add")]
        public MathResult Add(int num1, int num2) 
        {
            var result = new MathResult();
            result.Sum = num1 + num2;
            result.Average = (double)result.Sum / 2;

            return result;
        }
        
    }

    public class MathResult
    {
        public int Sum { get; set; }
        public double Average { get; set; }
    }
}
