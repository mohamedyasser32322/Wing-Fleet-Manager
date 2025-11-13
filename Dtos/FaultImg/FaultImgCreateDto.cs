using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.FaultImg
{
    public class FaultImgCreateDto
    {
        [Required, Url]
        public string ImgPath { get; set; }
    }
}
