/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace NetCore.Web.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "사용자 아이디를 입력하세요")]
        [MinLength(6, ErrorMessage = "사용자 아이디는 6글자 이상 입력하세요")]
        [System.ComponentModel.DataAnnotations.Display(Name = "사용자 아이디")]
        public string? UserID { get; set; }


        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        [MinLength(6, ErrorMessage = "비밀번호는 6글자 이상 입력하세요")]
        [System.ComponentModel.DataAnnotations.Display(Name = "비밀 번호")]

        public string? Password { get; set; }

    }
}
*/