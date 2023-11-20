using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository_DTO
{
    public class AttendencePerCourseDTO
    {
        public short AttendenceCodeForTheCourse { get; set; }

        public short LessonCode { get; set; }

        public short StudentCode { get; set; }

        public bool StudentPresentInLesson { get; set; }
    }
}
