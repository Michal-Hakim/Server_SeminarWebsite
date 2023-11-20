using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class MarkPerCourseDTO
    {
        public short MarkCodeForTheCourse { get; set; }

        public short CourseCodeForTheMajor { get; set; }

        public short StudentCode { get; set; }

        public double? MarkFirstHalf { get; set; }

        public double? MarkSecondHalf { get; set; }

        public double? MarkFinal { get; set; }
    }
}
