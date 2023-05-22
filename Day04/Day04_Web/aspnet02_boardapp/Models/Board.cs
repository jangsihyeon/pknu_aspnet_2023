using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aspnet02_boardapp.Models
{
    public class Board
    {
        [Key]   // PK
        public int Id { get; set; }

        [Required(ErrorMessage ="아이디를 입력하세요.")]      // Not Null // 에러메세지 한글 표시 
        [DisplayName("아이디")]
        public string UserId { get; set; }

        [DisplayName("이름")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "제목을  입력하세요.")]      // Not Null
        [MaxLength(200)]    // = varchar(200)
        [DisplayName("제목")]
        public string Title { get; set; }

        [DisplayName("조회")]
        public int ReadCount { get; set; }

        [DisplayName("작성일")]
        public DateTime PostDate { get; set; }

        [DisplayName("게시글")]
        public string Contents { get; set; }

    }
}
