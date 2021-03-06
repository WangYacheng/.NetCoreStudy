using Dang.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dang.Common.Local
{
    public class LocalUpload : BaseUpload
    {
        private readonly string upLoadPath = string.Empty;

        private readonly IConfiguration _configuration;
        private readonly ILogger<LocalUpload> _logger;

        public LocalUpload(IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = (ILogger<LocalUpload>)Dang.Common.MyServiceProvider.ServiceProvider.GetService(typeof(ILogger<LocalUpload>));
            upLoadPath = $"/upload/{DateTime.Now.ToString("yyyyMM")}/{DateTime.Now.ToString("dd")}/";
        }

        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <returns>上传后文件信息</returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(string basePath, string originalFilePath, string fileExt, bool isThumb = true)
        {
            try
            {
                var file = new FileInfo(originalFilePath);
                long fileSize = file.Length; //获得文件大小，
                var fileKey = Guid.NewGuid().ToString();
                string fileName = fileKey + "." + fileExt;
                string newFileName = fileName; //随机生成新的文件名
                string newThumbFileName = fileKey + "_thumb." + fileExt; //随机生成新的文件名
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
        /// 文件上传方法
        /// </summary>
        /// <returns>上传后文件信息</returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(string basePath, Stream stream, string fileExt, bool isThumb = true)
        {
            try
            {
                //var file = File.cre.co(originalFilePath);
                //long fileSize = file.Length; //获得文件大小，
                long fileSize = stream.ReadByte();

                var fileKey = Guid.NewGuid().ToString();
                string fileName = fileKey + "." + fileExt;
                string newFileName = fileName; //随机生成新的文件名
                string newThumbFileName = fileKey + "_thumb." + fileExt; //随机生成新的文件名
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
                Utils.StreamToFile(stream, targetFilePath);

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
    }
}
