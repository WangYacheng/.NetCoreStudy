using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dang.Common.Helpers
{
    public class Upload
    {
        //图片大小KB
        const int imageSize = 10240;
        //附件大小KB
        const int attachSize = 51200;

        private readonly string upLoadPath = string.Empty;

        private readonly IConfiguration _configuration;
        private readonly ILogger<Upload> _logger;

        public Upload(IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = (ILogger<Upload>)Dang.Common.MyServiceProvider.ServiceProvider.GetService(typeof(ILogger<Upload>));
            upLoadPath = $"/upload/{DateTime.Now.ToString("yyyyMM")}/{DateTime.Now.ToString("dd")}/";
        }

        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <returns>上传后文件信息</returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message) fileSaveAs(string basePath, string originalFilePath, string fileExt, bool isThumb = true)
        {
            try
            {
                var file = new FileInfo(originalFilePath);

                long fileSize = file.Length; //获得文件大小，
                string fileName = Helpers.Snowflake.Instance().GetId() + "." + fileExt;
                string newFileName = "app_" + fileName; //随机生成新的文件名
                string newThumbFileName = "app_thumb_" + fileName; //随机生成新的文件名
                string fullUpLoadPath = Path.Combine(basePath, "upload", DateTime.Now.ToString("yyyyMM"), DateTime.Now.ToString("dd")); //上传目录的物理路径
                string newFilePath = upLoadPath + newFileName; //上传后的路径
                string newThumbFilePath = upLoadPath + newThumbFileName; //上传后的路径

                //检查文件扩展名是否合法
                if (!CheckFileExt(fileExt))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "不允许上传" + fileExt + "类型的文件！");
                }
                //检查文件大小是否合法
                if (!CheckFileSize(fileExt, fileSize))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "文件超过限制的大小！");
                }

                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath))
                {
                    Directory.CreateDirectory(fullUpLoadPath);
                }
                //保存文件
                var targetFilePath = fullUpLoadPath + Path.DirectorySeparatorChar + newFileName;
                file.MoveTo(targetFilePath);

                if (isThumb)
                {
                    //生成图片缩略图
                    var targetThumbFilePath = fullUpLoadPath + Path.DirectorySeparatorChar + newThumbFileName;
                    Thumbnail.MakeThumbnailImage(targetFilePath, targetThumbFilePath, 300, 300);
                    return (true, newFilePath, newThumbFilePath, newFileName, string.Empty);
                }
                else
                {
                    return (true, newFilePath, string.Empty, newFileName, string.Empty);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "保存上传图片错误");
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }

        }

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        private bool IsImage(string _fileExt)
        {
            var al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            //检查危险文件
            string[] excExt = { "asp", "aspx", "ashx", "asa", "asmx", "asax", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = ("jpg,png,bmp,jpeg,gif,amr,mp3,wav").Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <param name="_fileSize">文件大小(B)</param>
        private bool CheckFileSize(string _fileExt, long _fileSize)
        {
            //判断是否为图片文件
            if (IsImage(_fileExt))
            {
                if (imageSize > 0 && _fileSize > imageSize * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (attachSize > 0 && _fileSize > attachSize * 1024)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
