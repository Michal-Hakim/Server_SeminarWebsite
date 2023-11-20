using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class MajorCoursesDTO
    {
        public short CourseCodeForTheMajor { get; set; }

        public short MajorCode { get; set; }

        public short CourseCode { get; set; }

        public short CourseTeacherCode { get; set; }

        public DateTime CourseStartYear { get; set; }

        public string CourseGrade { get; set; } = null!;
    }
}
