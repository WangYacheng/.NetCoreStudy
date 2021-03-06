using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Dang.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Qiniu.Common;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;

namespace Dang.Common.Qiniu
{
    /// <summary>
    /// 七牛云文件上传服务
    /// </summary>
    public class QiniuUpload : BaseUpload
    {

        private readonly QnySetting _Qny;
        private readonly ILogger<QiniuUpload> _logger;

        public QiniuUpload(QnySetting Qny)
        {
            _Qny = Qny;
            _logger = (ILogger<QiniuUpload>)Dang.Common.MyServiceProvider.ServiceProvider.GetService(typeof(ILogger<QiniuUpload>));
        }

        /// <summary>
        /// 判断图片是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExistFile(string key)
        {
            Mac mac = new Mac(_Qny.qiniuyunAK, _Qny.qiniuyunSK);// AK SK使用
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = _Qny.qiniuyunBucket;

            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 生成上传凭证，参见
            // https://developer.qiniu.com/kodo/manual/upload-token            
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);

            //自动设置区域节点
            Config.AutoZone(_Qny.qiniuyunAK, _Qny.qiniuyunBucket, true);
            UploadManager upload = new UploadManager();
            return true;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="originalFilePath">文件服务器</param>
        /// <param name="_fileExt"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(string originalFilePath, string _fileExt, bool _isThumb = false)
        {
            try
            {
                var file = new System.IO.FileInfo(originalFilePath);
                long fileSize = file.Length; //获得文件大小，以字节为单位
                //检查文件扩展名是否合法
                if (!CheckFileExt(_fileExt))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "不允许上传" + _fileExt + "类型的文件！");
                }
                //检查文件大小是否合法
                if (!CheckFileSize(_fileExt, fileSize))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "文件超过限制的大小！");
                }
                //获取文件流
                FileStream fsRead = file.OpenRead();
                var result = fileSaveAs(fsRead, _fileExt);
                if (result.result)
                {
                    return result;
                }
                else
                {
                    //如果单次上传失败，重试5次
                    for (int i = 0; i < 5; i++)
                    {
                        result = fileSaveAs(fsRead, _fileExt, _isThumb);
                        if (result.result)
                            return result;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("保存上传图片错误", ex);
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="_fileExtName"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(Stream stream, string _fileExt, bool _isThumb = false)
        {
            try
            {
                Mac mac = new Mac(_Qny.qiniuyunAK, _Qny.qiniuyunSK);// AK SK使用
                PutPolicy putPolicy = new PutPolicy();
                putPolicy.Scope = _Qny.qiniuyunBucket;

                // 上传策略有效期(对应于生成的凭证的有效期)          
                putPolicy.SetExpires(3600);
                // 生成上传凭证，参见
                // https://developer.qiniu.com/kodo/manual/upload-token            
                string jstr = putPolicy.ToJsonString();
                string token = Auth.CreateUploadToken(mac, jstr);

                //自动设置区域节点
                Config.AutoZone(_Qny.qiniuyunAK, _Qny.qiniuyunBucket, true);
                UploadManager upload = new UploadManager();

                //生成存储的文件名
                string fileName = Utils.GetRamDateCode() + "_" + Guid.NewGuid().ToString();
                string _fileName = fileName + "." + _fileExt;
                string _fileThumbName = fileName + "_thumb." + _fileExt;
                //重命名文件加上时间戳
                var saveKey = _fileName;
                var saveThumbKey = _fileThumbName;
                string webFileName = _Qny.prefixUrl + "/" + _fileName;
                string webThumbFileName = _Qny.prefixUrl + "/" + _fileThumbName;
                HttpResult result = upload.UploadStream(stream, saveKey, token);
                if (_isThumb)
                {
                    //生成缩略图图片上传
                    //var byteData = Utils.StreamToBytes(stream);
                    var thumbByteData = Thumbnail.MakeThumbnailImage(stream, _fileExt, 300, 300);
                    var result1 = upload.UploadData(thumbByteData, saveThumbKey, token);
                }
                if (result.Code == 200)
                {
                    return (true, webFileName, webThumbFileName, _fileName, result.RefText);
                }
                else
                {
                    //throw new Exception(result.RefText);//上传失败错误信息
                    _logger.LogTrace(result.RefText, "上传失败信息");
                    return (false, string.Empty, string.Empty, string.Empty, result.RefText);
                }
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex, "保存上传文件错误");
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="_fileExtName"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(byte[] byteData, string _fileExt, bool _isThumb = false)
        {
            Mac mac = new Mac(_Qny.qiniuyunAK, _Qny.qiniuyunSK);// AK SK使用
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = _Qny.qiniuyunBucket;

            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 生成上传凭证，参见
            // https://developer.qiniu.com/kodo/manual/upload-token            
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);

            //自动设置区域节点
            Config.AutoZone(_Qny.qiniuyunAK, _Qny.qiniuyunBucket, true);
            UploadManager upload = new UploadManager();

            try
            {
                //生成存储的文件名
                string fileName = Utils.GetRamDateCode() + "_" + Guid.NewGuid().ToString();
                string _fileName = fileName + "." + _fileExt;
                string _thumbFileName = fileName + "_thumb." + _fileExt;

                //重命名文件加上时间戳
                var saveKey = _fileName;
                var saveThumbKey = _thumbFileName;
                string webFileName = _Qny.prefixUrl + "/" + _fileName;
                string webThumbFileName = _Qny.prefixUrl + "/" + _thumbFileName;
                HttpResult result = upload.UploadData(byteData, saveKey, token);
                if (_isThumb)
                {
                    var byteThumbData = Thumbnail.MakeThumbnailImage(byteData, _fileExt, 300, 300);
                    var result1 = upload.UploadData(byteThumbData, saveThumbKey, token);
                }
                if (result.Code == 200)
                {
                    return (true, webFileName, webThumbFileName, _fileName, result.RefText);
                }
                else
                {
                    //throw new Exception(result.RefText);//上传失败错误信息
                    return (false, string.Empty, string.Empty, string.Empty, result.RefText);
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
