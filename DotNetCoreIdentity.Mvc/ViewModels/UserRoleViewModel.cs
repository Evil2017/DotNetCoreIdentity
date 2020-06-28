﻿using DotNetCoreIdentity.Mvc.Models;
using DotNetCoreIdentity.Mvc.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreIdentity.Mvc.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
        }

        public string UserId { get; set; }
        public string RoleId { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }

    public class AlbumCreateViewModel
    {
        [Display(Name = "专辑名")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(100, ErrorMessage = "{0}的长度不可超过{1}")]
        public string Title { get; set; }

        [Display(Name = "艺人")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(100, ErrorMessage = "{0}的长度不可超过{1}")]
        public string Artist { get; set; }

        [Display(Name = "发行日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}是必填项"), Range(0.01, 100, ErrorMessage = "{0}的价格必须在{1}和{2}之间")]
        public decimal Price { get; set; }

        [Display(Name = "封面地址")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(200, ErrorMessage = "{0}的长度不可超过{1}")]
        // [DataType(DataType.Url)]
        [ValidUrl(ErrorMessage = "这个URL不正确")]
        public string CoverUrl { get; set; }
    }

    public class AlbumUpdateViewModel
    {
        [Display(Name = "专辑名")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(100, ErrorMessage = "{0}的长度不可超过{1}")]
        public string Title { get; set; }

        [Display(Name = "艺人")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(100, ErrorMessage = "{0}的长度不可超过{1}")]
        public string Artist { get; set; }

        [Display(Name = "发行日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "价格")]
        [Required(ErrorMessage = "{0}是必填项"), Range(0.01, 100, ErrorMessage = "{0}的价格必须在{1}和{2}之间")]
        public decimal Price { get; set; }

        [Display(Name = "封面地址")]
        [Required(ErrorMessage = "{0}是必填项"), MaxLength(200, ErrorMessage = "{0}的长度不可超过{1}")]
        public string CoverUrl { get; set; }
    }
}
