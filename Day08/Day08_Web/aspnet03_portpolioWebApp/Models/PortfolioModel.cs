﻿using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace aspnet03_portfoiloWebApp.Models
{
    public class PortfolioModel // 실제 DB에 저장하기 위한 모델 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="구분은 필수 입니다.")]
        [DisplayName("구분")]
        public string Division { get; set; }

        [Required(ErrorMessage ="타이틀은 필수 입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }

        [Required(ErrorMessage ="설명은 필수 입니다.")]
        [DisplayName("설명")]
        public string Description { get; set; }

        [DisplayName("프로젝트 URL")]
        public string? Url { get; set; }

        [DisplayName("파일명")]
        [FileExtensions(Extensions =".png,.jpg,.jpeg", ErrorMessage ="이미지 파일을 선택하세요.")]
        public string? FileName { get; set; }
    }

    // 파일 업로드를 위한 중간단계 모델
    public class TemPortfolioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "구분은 필수 입니다.")]
        [DisplayName("구분")]
        public string Division { get; set; }

        [Required(ErrorMessage = "타이틀은 필수 입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }

        [Required(ErrorMessage = "설명은 필수 입니다.")]
        [DisplayName("설명")]
        public string Description { get; set; }

        [DisplayName("프로젝트 URL")]
        public string? Url { get; set; }

        //[NotMapped]
        [DisplayName("파일명")]    // 실제 이미지를 받아서 저장하기 위한 중간단계 객체 
        public IFormFile? PortfolioImage { get; set; }

        [DisplayName("파일명")]
        [FileExtensions(Extensions = ".png,.jpg,.jpeg", ErrorMessage = "이미지 파일을 선택하세요.")]
        public string? FileName { get; set; }
    }
}
